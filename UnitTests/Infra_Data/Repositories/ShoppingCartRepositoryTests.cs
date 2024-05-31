using System.Security.Claims;
using Domain.Entities;
using Domain.Entities.Cart;
using Domain.Entities.ObjectValues.ProductObjectValue;
using Infra_Data.Context;
using Infra_Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Repositories;

public abstract class ShoppingCartRepositoryTests
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
                new Claim(ClaimTypes.NameIdentifier, "test-user-id")
            ], "mock"));

            httpContext.User = user;
        }

        httpContextAccessor.HttpContext.Returns(httpContext);

        return httpContextAccessor;
    }

    public class ShoppingCartItemsTests
    {
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

            var shoppingCartItems = items as ShoppingCartItem[] ?? items.ToArray();
            Assert.Single(shoppingCartItems);
            Assert.Equal(product.Id, shoppingCartItems.First().ProductId);
            Assert.Equal(category.Id, shoppingCartItems.First().CategoryId);
            Assert.Equal(2, shoppingCartItems.First().Quantity);
        }

        [Fact]
        public void ShoppingCartItems_Set_ShouldReplaceExistingItems()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var httpContextAccessor = GetHttpContextAccessor(true);
            var repository = new ShoppingCartRepository(context, httpContextAccessor);

            var category1 = new Category(1, "Category1", "image.jpg", true);
            var product1 = new Product(1, "Product1", "Description1", [], 10, 1);
            var shoppingCartItem1 = new ShoppingCartItem();
            shoppingCartItem1.SetShoppingCartId("user-test-user-id");
            shoppingCartItem1.SetQuantity(2);
            shoppingCartItem1.Product = product1;
            shoppingCartItem1.Category = category1;

            var category2 = new Category(2, "Category2", "image2.jpg", true);
            var product2 = new Product(2, "Product2", "Description2", [], 20, 2);
            var shoppingCartItem2 = new ShoppingCartItem();
            shoppingCartItem2.SetShoppingCartId("user-test-user-id");
            shoppingCartItem2.SetQuantity(3);
            shoppingCartItem2.Product = product2;
            shoppingCartItem2.Category = category2;

            context.Products.Add(product1);
            context.Categories.Add(category1);
            context.ShoppingCartItems.Add(shoppingCartItem1);
            context.SaveChanges();

            // Act
            var newShoppingCartItems = new List<ShoppingCartItem> { shoppingCartItem2 };
            repository.ShoppingCartItems = newShoppingCartItems;

            // Assert
            var items = repository.ShoppingCartItems.ToList();
            Assert.Single(items);
            Assert.Equal(product2.Id, items.First().ProductId);
            Assert.Equal(category2.Id, items.First().CategoryId);
            Assert.Equal(3, items.First().Quantity);
        }
    }

    public class GetShoppingCartItemsAsyncTests
    {
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

            var shoppingCartItems = items as ShoppingCartItem[] ?? items.ToArray();
            Assert.Single(shoppingCartItems);
            Assert.Equal(product.Id, shoppingCartItems.First().ProductId);
            Assert.Equal(category.Id, shoppingCartItems.First().CategoryId);
            Assert.Equal(2, shoppingCartItems.First().Quantity);
        }
    }

    public class AddItemToCartAsyncTests
    {
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
            var shoppingCartItems = items as ShoppingCartItem[] ?? items.ToArray();
            Assert.Single(shoppingCartItems);
            var item = shoppingCartItems.First();
            Assert.Equal(product.Id, item.ProductId);
            Assert.Equal(category.Id, item.CategoryId);
            Assert.Equal(1, item.Quantity);
        }
    }

    public class RemoveItemToCartAsyncTests
    {
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
    }

    public class GetTotalCartItemsAsyncTests
    {
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
    }

    public class ShoppingCartItemIdTests
    {
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
        public void ShoppingCartId_ShouldReturnSessionId_WhenUserIsNotAuthenticated()
        {
            var context = GetInMemoryDbContext();
            var httpContextAccessor = GetHttpContextAccessor(false);
            var repository = new ShoppingCartRepository(context, httpContextAccessor);

            var shoppingCartId = repository.ShoppingCartId;

            Assert.StartsWith("session-", shoppingCartId);
            Assert.Equal($"session-{httpContextAccessor.HttpContext?.Session.Id}", shoppingCartId);
        }
    }

    public class ClearShoppingCartAsyncTests
    {
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

            var itemsAfterClearing =
                await context.ShoppingCartItems.Where(x => x.UserId == "user-test-user-id").ToListAsync();
            Assert.Empty(itemsAfterClearing);

            var items = await repository.GetShoppingCartItemsAsync();
            Assert.Empty(items);
        }
    }

    public class RemoveItemAsyncTests
    {
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

    public class GetTotalAmountCartAsyncTests
    {
        [Fact]
        public async Task GetTotalAmountCartAsync_ShouldReturnCorrectTotalAmount()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var httpContextAccessor = GetHttpContextAccessor(true);
            var repository = new ShoppingCartRepository(context, httpContextAccessor);

            var category = new Category(1, "Category1", "image.jpg", true);

            var product1 = new Product(1, "Product1", "Description1", [], 10, 1);
            var price1 = new PriceObjectValue();
            price1.SetPrice(10.0m);
            product1.SetPriceObjectValue(price1);

            var product2 = new Product(2, "Product2", "Description2", [], 20, 2);
            var price2 = new PriceObjectValue();
            price2.SetPrice(20.0m);
            product2.SetPriceObjectValue(price2);

            var shoppingCartItem1 = new ShoppingCartItem();
            shoppingCartItem1.SetShoppingCartId("user-test-user-id");
            shoppingCartItem1.SetQuantity(2);
            shoppingCartItem1.Product = product1;
            shoppingCartItem1.Category = category;

            var shoppingCartItem2 = new ShoppingCartItem();
            shoppingCartItem2.SetShoppingCartId("user-test-user-id");
            shoppingCartItem2.SetQuantity(3);
            shoppingCartItem2.Product = product2;
            shoppingCartItem2.Category = category;

            context.Products.AddRange(product1, product2);
            context.Categories.Add(category);
            context.ShoppingCartItems.AddRange(shoppingCartItem1, shoppingCartItem2);
            await context.SaveChangesAsync();

            // Act
            var totalAmount = await repository.GetTotalAmountCartAsync();

            // Assert
            Assert.Equal(80.0m, totalAmount);
        }
    }
}