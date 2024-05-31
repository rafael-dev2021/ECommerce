using System.Security.Claims;
using Domain.Entities;
using Domain.Entities.Cart;
using Domain.Interfaces;
using Infra_Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories;

public class ShoppingCartRepository(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
    : IShoppingCartItemRepository
{
    public string ShoppingCartId
    {
        get
        {
            var userId = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var sessionId = httpContextAccessor.HttpContext?.Session.Id;

            return userId != null ? $"user-{userId}" : $"session-{sessionId}";
        }
    }

    public IEnumerable<ShoppingCartItem> ShoppingCartItems
    {
        get
        {
            return appDbContext.ShoppingCartItems
                .Include(x => x.Product)
                .Include(x => x.Category)
                .Where(x => x.ShoppingCartId == ShoppingCartId)
                .ToList();
        }
        set
        {
            var existingItems = appDbContext.ShoppingCartItems
                .Where(x => x.ShoppingCartId == ShoppingCartId)
                .ToList();
            appDbContext.ShoppingCartItems.RemoveRange(existingItems);

            appDbContext.ShoppingCartItems.AddRange(value);

            appDbContext.SaveChanges();
        }
    }

    public Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItemsAsync()
    {
        return Task.FromResult(ShoppingCartItems);
    }

    public async Task AddItemToCartAsync(Product product, Category category)
    {
        var addItem = await appDbContext.ShoppingCartItems
            .SingleOrDefaultAsync(x => x.ProductId == product.Id && x.ShoppingCartId == ShoppingCartId);

        if (addItem == null)
        {
            if (product.Stock > 0)
            {
                addItem = new ShoppingCartItem();
                addItem.SetShoppingCartId(ShoppingCartId);
                addItem.SetQuantity(1);
                addItem.SetProductId(product.Id);
                addItem.SetCategoryId(category.Id);
                addItem.SetUserId(ShoppingCartId);

                await appDbContext.ShoppingCartItems.AddAsync(addItem);
            }
        }
        else
        {
            if (product.Stock - addItem.Quantity > 0)
            {
                addItem.SetQuantity(addItem.Quantity + 1);
            }
        }

        await appDbContext.SaveChangesAsync();
    }

    public async Task<int> RemoveItemToCartAsync(Product product, Category category)
    {
        var removeItem = await appDbContext.ShoppingCartItems
            .SingleOrDefaultAsync(x => x.ProductId == product.Id && x.ShoppingCartId == ShoppingCartId);

        var quantities = 0;

        if (removeItem == null) return quantities;

        if (removeItem.Quantity > 1)
        {
            removeItem.SetQuantity(removeItem.Quantity - 1);
            quantities = removeItem.Quantity;
        }
        else
        {
            appDbContext.ShoppingCartItems.Remove(removeItem);
            quantities = 0;
        }

        await appDbContext.SaveChangesAsync();

        return quantities;
    }

    public async Task<int> GetTotalCartItemsAsync()
    {
        return (await GetShoppingCartItemsAsync()).Sum(item => item.Quantity);
    }

    public async Task ClearShoppingCartAsync()
    {
        var cartItems = await appDbContext.ShoppingCartItems
            .Where(x => x.UserId == ShoppingCartId)
            .ToListAsync();

        appDbContext.ShoppingCartItems.RemoveRange(cartItems);
        await appDbContext.SaveChangesAsync();
    }

    public async Task<decimal> GetTotalAmountCartAsync()
    {
        var total = await appDbContext.ShoppingCartItems
            .AsNoTracking()
            .Where(x => x.ShoppingCartId == ShoppingCartId)
            .Select(x => x.Quantity * x.Product.PriceObjectValue.Price)
            .SumAsync();
        return total;
    }

    public async Task<int> RemoveItemAsync(Product product)
    {
        var remove = await appDbContext.ShoppingCartItems
            .SingleOrDefaultAsync(x => x.Product.Id == product.Id && x.ShoppingCartId == ShoppingCartId);
        appDbContext.ShoppingCartItems.Remove(remove);
        return await appDbContext.SaveChangesAsync();
    }
}