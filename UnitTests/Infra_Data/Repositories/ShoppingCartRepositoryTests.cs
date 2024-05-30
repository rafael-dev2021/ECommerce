using Domain.Entities;
using Domain.Entities.Cart;
using Infra_Data.Context;
using Infra_Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System.Security.Claims;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Repositories;

public class ShoppingCartRepositoryTests
{
    private static AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"TestDatabase-{Guid.NewGuid()}")
            .Options;

        return new AppDbContext(options);
    }

    private static IHttpContextAccessor GetHttpContextAccessor(bool isAuthenticated)
    {
        var httpContextAccessor = Substitute.For<IHttpContextAccessor>();
        var httpContext = new DefaultHttpContext();
        var session = Substitute.For<ISession>();

        session.Id.Returns(Guid.NewGuid().ToString());
        httpContext.Session = session;

        if (isAuthenticated)
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(
            [
                new(ClaimTypes.NameIdentifier, "test-user-id")
            ], "mock"));

            httpContext.User = user;
        }

        httpContextAccessor.HttpContext.Returns(httpContext);

        return httpContextAccessor;
    }

    [Fact]
    public void ShoppingCartId_ShouldReturnUserId_WhenUserIsAuthenticated()
    {
        var context = GetInMemoryDbContext();
        var httpContextAccessor = GetHttpContextAccessor(true);
        var repository = new ShoppingCartRepository(context, httpContextAccessor);

        var shoppingCartId = repository.ShoppingCartId;

        Assert.Equal("user-test-user-id", shoppingCartId);
    }

    [Fact]
    public void ShoppingCartItems_Get_ShouldReturnItemsForCorrectShoppingCartId()
    {
        var context = GetInMemoryDbContext();
        var httpContextAccessor = GetHttpContextAccessor(true);
        var repository = new ShoppingCartRepository(context, httpContextAccessor);

        var category = new Category(1, "Category1", "image.jpg", true);
        var product = new Product(1, "Product1", "Description1", [], 10, 1);
        var shoppingCartItem = new ShoppingCartItem();
        shoppingCartItem.SetShoppingCartId("user-test-user-id");
        shoppingCartItem.SetQuantity(2);
        shoppingCartItem.Product = product;
        shoppingCartItem.Category = category;


        context.Products.Add(product);
        context.Categories.Add(category);
        context.ShoppingCartItems.Add(shoppingCartItem);
        context.SaveChanges();

        var items = repository.ShoppingCartItems;

        Assert.Single(items);
        Assert.Equal(product.Id, items.First().ProductId);
        Assert.Equal(category.Id, items.First().CategoryId);
        Assert.Equal(2, items.First().Quantity);
    }

    [Fact]
    public async Task GetShoppingCartItemsAsync_ShouldReturnItemsForCorrectShoppingCartId()
    {
        var context = GetInMemoryDbContext();
        var httpContextAccessor = GetHttpContextAccessor(true);
        var repository = new ShoppingCartRepository(context, httpContextAccessor);

        var category = new Category(1, "Category1", "image.jpg", true);
        var product = new Product(1, "Product1", "Description1", [], 10, 1);
        var shoppingCartItem = new ShoppingCartItem();
        shoppingCartItem.SetShoppingCartId("user-test-user-id");
        shoppingCartItem.SetQuantity(2);
        shoppingCartItem.Product = product;
        shoppingCartItem.Category = category;


        context.Products.Add(product);
        context.Categories.Add(category);
        context.ShoppingCartItems.Add(shoppingCartItem);
        await context.SaveChangesAsync();

        var items = await repository.GetShoppingCartItemsAsync();

        Assert.Single(items);
        Assert.Equal(product.Id, items.First().ProductId);
        Assert.Equal(category.Id, items.First().CategoryId);
        Assert.Equal(2, items.First().Quantity);
    }

    [Fact]
    public async Task AddItemToCartAsync_ShouldAddNewItem()
    {
        var context = GetInMemoryDbContext();
        var httpContextAccessor = GetHttpContextAccessor(true);
        var repository = new ShoppingCartRepository(context, httpContextAccessor);

        var category = new Category(1, "Category1", "image.jpg", true);
        var product = new Product(1, "Product1", "Description1", [], 10, 1);

        context.Products.Add(product);
        context.Categories.Add(category);
        await context.SaveChangesAsync();

        await repository.AddItemToCartAsync(product, category);

        var items = await repository.GetShoppingCartItemsAsync();
        Assert.Single(items);
        var item = items.First();
        Assert.Equal(product.Id, item.ProductId);
        Assert.Equal(category.Id, item.CategoryId);
        Assert.Equal(1, item.Quantity);
    }

    [Fact]
    public async Task RemoveItemToCartAsync_ShouldRemoveItem()
    {
        var context = GetInMemoryDbContext();
        var httpContextAccessor = GetHttpContextAccessor(true);
        var repository = new ShoppingCartRepository(context, httpContextAccessor);

        var category = new Category(1, "Category1", "image.jpg", true);
        var product = new Product(1, "Product1", "Description1", [], 10, 1);

        await repository.AddItemToCartAsync(product, category);
        await repository.AddItemToCartAsync(product, category);

        var quantity = await repository.RemoveItemToCartAsync(product, category);

        Assert.Equal(1, quantity);

        quantity = await repository.RemoveItemToCartAsync(product, category);

        Assert.Equal(0, quantity);
    }

    [Fact]
    public async Task GetTotalCartItemsAsync_ShouldReturnCorrectTotal()
    {
        var context = GetInMemoryDbContext();
        var httpContextAccessor = GetHttpContextAccessor(true);
        var repository = new ShoppingCartRepository(context, httpContextAccessor);

        var category = new Category(1, "Category1", "image.jpg", true);
        var product = new Product(1, "Product1", "Description1", [], 10, 1);

        var shoppingCartItem1 = new ShoppingCartItem();
        shoppingCartItem1.SetShoppingCartId("user-test-user-id");
        shoppingCartItem1.SetQuantity(2);
        shoppingCartItem1.Product = product;
        shoppingCartItem1.Category = category;

        var shoppingCartItem2 = new ShoppingCartItem();
        shoppingCartItem2.SetShoppingCartId("user-test-user-id");
        shoppingCartItem2.SetQuantity(2);
        shoppingCartItem2.Product = product;
        shoppingCartItem2.Category = category;


        context.ShoppingCartItems.AddRange(shoppingCartItem1, shoppingCartItem2);
        await context.SaveChangesAsync();

        var totalItems = await repository.GetTotalCartItemsAsync();

        Assert.Equal(4, totalItems);
    }

    [Fact]
    public async Task ClearShoppingCartAsync_ShouldRemoveAllItems()
    {
        var context = GetInMemoryDbContext();
        var httpContextAccessor = GetHttpContextAccessor(true);
        var repository = new ShoppingCartRepository(context, httpContextAccessor);

        var category = new Category(1, "Category1", "image.jpg", true);
        var product = new Product(1, "Product1", "Description1", [], 10, 1);
        var shoppingCartItem = new ShoppingCartItem();
        shoppingCartItem.SetUserId("user-test-user-id");
        shoppingCartItem.SetQuantity(2);
        shoppingCartItem.Product = product;
        shoppingCartItem.Category = category;

        context.ShoppingCartItems.Add(shoppingCartItem);
        await context.SaveChangesAsync();

        await repository.ClearShoppingCartAsync();

        var itemsAfterClearing = await context.ShoppingCartItems.Where(x => x.UserId == "user-test-user-id").ToListAsync();
        Assert.Empty(itemsAfterClearing);

        var items = await repository.GetShoppingCartItemsAsync();
        Assert.Empty(items);
    }

    [Fact]
    public async Task RemoveItemAsync_ShouldRemoveItem()
    {
        var context = GetInMemoryDbContext();
        var httpContextAccessor = GetHttpContextAccessor(true);
        var repository = new ShoppingCartRepository(context, httpContextAccessor);

        var category = new Category(1, "Category1", "image.jpg", true);
        var product = new Product(1, "Product1", "Description1", [], 10, 1);
        var shoppingCartItem = new ShoppingCartItem();
        shoppingCartItem.SetShoppingCartId("user-test-user-id");
        shoppingCartItem.SetQuantity(2);
        shoppingCartItem.Product = product;
        shoppingCartItem.Category = category;

        context.ShoppingCartItems.Add(shoppingCartItem);
        await context.SaveChangesAsync();

        var removedCount = await repository.RemoveItemAsync(product);

        Assert.Equal(1, removedCount);
    }
}
