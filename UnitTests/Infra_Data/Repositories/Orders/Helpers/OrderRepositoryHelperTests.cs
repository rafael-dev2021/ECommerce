using System.Linq.Expressions;
using Domain.Entities.Cart;
using Domain.Entities.ObjectValues.ProductObjectValue;
using Domain.Entities.Orders;
using Domain.Entities.Payments;
using Domain.Entities.Payments.Enums;
using Domain.Entities.Payments.ObjectValues;
using Domain.Interfaces;
using Infra_Data.Context;
using Infra_Data.Repositories.Orders.Helpers;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit;
using Assert = Xunit.Assert;
using Product = Domain.Entities.Product;

namespace UnitTests.Infra_Data.Repositories.Orders.Helpers;

public class OrderRepositoryHelperTests
{
    private static AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"TestDatabase-{Guid.NewGuid()}")
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task FindOrdersByDateAsync_ShouldReturnFilteredOrders()
    {
        // Arrange
        var appDbContext = GetInMemoryDbContext();
        var shoppingCartItemRepository = Substitute.For<IShoppingCartItemRepository>();
        var helper = new OrderRepositoryHelper(appDbContext, shoppingCartItemRepository);

        var order1 = new Order();
        order1.SetId(1);
        order1.SetConfirmedOrder(new DateTime(2022, 1, 1));

        var order2 = new Order();
        order2.SetId(2);
        order2.SetConfirmedOrder(new DateTime(2022, 1, 5));

        var order3 = new Order();
        order3.SetId(3);
        order3.SetConfirmedOrder(new DateTime(2022, 1, 10));

        var orders = new List<Order>
        {
            order1,
            order2,
            order3
        };

        appDbContext.Orders.AddRange(orders);
        await appDbContext.SaveChangesAsync();

        DateTime? minDate = new DateTime(2022, 1, 5);
        DateTime? maxDate = new DateTime(2022, 1, 10);

        Expression<Func<Order, DateTime>> datePropertySelector = o => o.ConfirmedOrder;

        // Act
        var result = await helper.FindOrdersByDateAsync(minDate, maxDate, datePropertySelector);

        // Assert
        Assert.NotNull(result);
        var enumerable = result as Order[] ?? result.ToArray();
        Assert.Equal(2, enumerable.Length);
        Assert.DoesNotContain(enumerable, o => o.Id == 1);
        Assert.Contains(enumerable, o => o.Id == 2);
        Assert.Contains(enumerable, o => o.Id == 3);
    }

    public class ProcessCartItemTests
    {
        [Fact]
        public async Task ProcessCartItem_ShouldProcessItem_WhenStockIsSufficient()
        {
            // Arrange
            var appDbContext = GetInMemoryDbContext();
            var shoppingCartItemRepository = Substitute.For<IShoppingCartItemRepository>();
            var helper = new OrderRepositoryHelper(appDbContext, shoppingCartItemRepository);

            var product = new Product(1, "Product 1", "Description 1", [], 10, 1);
            var priceObjectValue = new PriceObjectValue();
            priceObjectValue.SetPrice(50m);
            product.SetPriceObjectValue(priceObjectValue);
            await appDbContext.Products.AddAsync(product);
            await appDbContext.SaveChangesAsync();

            var cartItem = new ShoppingCartItem
            {
                Id = 1,
                ProductId = product.Id,
                Product = product,
                Quantity = 2,
                ShoppingCartId = "cart1"
            };

            var paymentMethod = new PaymentMethod();
            var order = new Order();
            order.SetId(1);
            order.SetPaymentMethod(paymentMethod);

            // Act
            await helper.ProcessCartItem(order, cartItem);

            // Assert
            var processedItem =
                appDbContext.OrdersDetails.FirstOrDefault(od => od.OrderId == order.Id && od.ProductId == product.Id);
            Assert.NotNull(processedItem);
            Assert.Equal(cartItem.Quantity, processedItem.Quantity);
            Assert.Equal(priceObjectValue.Price, processedItem.Price);
        }

        [Fact]
        public async Task ProcessCartItem_ShouldThrowException_WhenStockIsInsufficient()
        {
            // Arrange
            var appDbContext = GetInMemoryDbContext();
            var shoppingCartItemRepository = Substitute.For<IShoppingCartItemRepository>();
            var helper = new OrderRepositoryHelper(appDbContext, shoppingCartItemRepository);

            var product = new Product(1, "Product 1", "Description 1", [], 1, 1);
            await appDbContext.Products.AddAsync(product);
            await appDbContext.SaveChangesAsync();

            var cartItem = new ShoppingCartItem
            {
                Id = 1,
                ProductId = product.Id,
                Product = product,
                Quantity = 2,
                ShoppingCartId = "cart1"
            };

            var order = new Order();
            order.SetId(1);
            order.SetPaymentMethod(new PaymentMethod());

            // Act & Assert
            var exception =
                await Assert.ThrowsAsync<Exception>(async () => await helper.ProcessCartItem(order, cartItem));
            Assert.Equal("Product stock not available.", exception.Message);
        }
    }

    public class GetProductByIdTests
    {
        [Fact]
        public async Task GetProductById_ShouldReturnProduct_WhenProductIdExists()
        {
            // Arrange
            const int productId = 1;
            var product = new Product();
            product.SetId(productId);
            var dbContext = GetInMemoryDbContext();
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            var helper = new OrderRepositoryHelper(dbContext, Substitute.For<IShoppingCartItemRepository>());

            // Act
            var retrievedProduct = await helper.GetProductById(productId);

            // Assert
            Assert.NotNull(retrievedProduct);
            Assert.Equal(productId, retrievedProduct.Id);
        }

        [Fact]
        public async Task GetProductById_ShouldThrowException_WhenProductNotFound()
        {
            // Arrange
            const int productId = 1;
            var dbContext = GetInMemoryDbContext();
            var helper = new OrderRepositoryHelper(dbContext, Substitute.For<IShoppingCartItemRepository>());

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await helper.GetProductById(productId));
        }
    }

    public class ConfirmOrderTests
    {
        [Fact]
        public void ConfirmOrder_ShouldApprovePayment_WhenPaymentIsApproved()
        {
            // Arrange
            var order = new Order();
            var paymentMethod = Substitute.For<PaymentMethod>();
            var paymentStatusObjectValue = new PaymentStatusObjectValue();
            paymentStatusObjectValue.PaymentApproved();
            var paymentMethodObjectValue = new PaymentMethodObjectValue();
            paymentMethodObjectValue.SetPaymentStatusObjectValue(paymentStatusObjectValue);

            // Use reflection to set the PaymentMethodObjectValue property
            typeof(PaymentMethod).GetProperty(nameof(PaymentMethod.PaymentMethodObjectValue))
                ?.SetValue(paymentMethod, paymentMethodObjectValue);

            order.SetPaymentMethod(paymentMethod);

            // Act
            OrderRepositoryHelper.ConfirmOrder(order, EPaymentMethod.CreditCard);

            // Assert
            Assert.Equal(EPaymentStatus.Approved, paymentMethodObjectValue.PaymentStatusObjectValue.EPaymentStatus);
        }

        [Fact]
        public void ConfirmOrder_ShouldThrowException_WhenPaymentIsDeclined()
        {
            // Arrange
            var order = new Order();
            var paymentMethod = Substitute.For<PaymentMethod>();
            var paymentStatusObjectValue = new PaymentStatusObjectValue();
            paymentStatusObjectValue.PaymentDeclined();
            var paymentMethodObjectValue = new PaymentMethodObjectValue();
            paymentMethodObjectValue.SetPaymentStatusObjectValue(paymentStatusObjectValue);

            // Use reflection to set the PaymentMethodObjectValue property
            typeof(PaymentMethod).GetProperty(nameof(PaymentMethod.PaymentMethodObjectValue))
                ?.SetValue(paymentMethod, paymentMethodObjectValue);

            order.SetPaymentMethod(paymentMethod);

            // Act & Assert
            var exception =
                Assert.Throws<Exception>(() => OrderRepositoryHelper.ConfirmOrder(order, EPaymentMethod.CreditCard));
            Assert.Equal("Payment was declined.", exception.Message);
        }
    }
}