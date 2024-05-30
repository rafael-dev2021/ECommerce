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
    private readonly AppDbContext _appDbContext = appDbContext;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public string ShoppingCartId
    {
        get
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var sessionId = _httpContextAccessor.HttpContext?.Session.Id;

            return userId != null ? $"user-{userId}" : $"session-{sessionId}";
        }
    }

    public IEnumerable<ShoppingCartItem> ShoppingCartItems
    {
        get
        {
            return _appDbContext.ShoppingCartItems
                .Include(x => x.Product)
                .Include(x => x.Category)
                .Where(x => x.ShoppingCartId == ShoppingCartId)
                .ToList();
        }
        set
        {
            var existingItems = _appDbContext.ShoppingCartItems
                .Where(x => x.ShoppingCartId == ShoppingCartId)
                .ToList();
            _appDbContext.ShoppingCartItems.RemoveRange(existingItems);

            _appDbContext.ShoppingCartItems.AddRange(value);

            _appDbContext.SaveChanges();
        }
    }

    public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItemsAsync()
    {
        return ShoppingCartItems ??= await _appDbContext.ShoppingCartItems
            .Where(x => x.ShoppingCartId == ShoppingCartId)
            .Include(x => x.Product)
            .Include(c => c.Category)
            .ToListAsync();
    }

    public async Task AddItemToCartAsync(Product product, Category category)
    {
        var addItem = await _appDbContext.ShoppingCartItems
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

                await _appDbContext.ShoppingCartItems.AddAsync(addItem);
            }
        }
        else
        {
            if (product.Stock - addItem.Quantity > 0)
            {
                addItem.SetQuantity(addItem.Quantity + 1);
            }
        }

        await _appDbContext.SaveChangesAsync();
    }

    public async Task<int> RemoveItemToCartAsync(Product product, Category category)
    {
        var removeItem = await _appDbContext.ShoppingCartItems
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
            _appDbContext.ShoppingCartItems.Remove(removeItem);
            quantities = 0;
        }

        await _appDbContext.SaveChangesAsync();

        return quantities;
    }

    public async Task<int> GetTotalCartItemsAsync()
    {
        var total = 0;
        foreach (var item in await GetShoppingCartItemsAsync())
        {
            total += item.Quantity;
        }

        return total;
    }

    public async Task ClearShoppingCartAsync()
    {
        var cartItems = await _appDbContext.ShoppingCartItems
            .Where(x => x.UserId == ShoppingCartId)
            .ToListAsync();

        _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
        await _appDbContext.SaveChangesAsync();
    }


    public async Task<decimal> GetTotalAmountCartAsync()
    {
        var total = await _appDbContext.ShoppingCartItems
            .AsNoTracking()
            .Where(x => x.ShoppingCartId == ShoppingCartId)
            .Select(x => x.Quantity * x.Product.PriceObjectValue.Price)
            .SumAsync();
        return total;
    }

    public async Task<int> RemoveItemAsync(Product product)
    {
        var remove = await _appDbContext.ShoppingCartItems
            .SingleOrDefaultAsync(x => x.Product.Id == product.Id && x.ShoppingCartId == ShoppingCartId);
        _appDbContext.ShoppingCartItems.Remove(remove);
        return await _appDbContext.SaveChangesAsync();
    }
}