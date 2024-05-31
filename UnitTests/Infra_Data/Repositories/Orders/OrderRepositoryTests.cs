using Domain.Entities.Deliveries;
using Domain.Entities.Orders;
using Domain.Entities.Payments;
using Domain.Entities.Payments.Enums;
using Domain.Entities.Payments.ObjectValues;
using Domain.Interfaces;
using Infra_Data.Context;
using Infra_Data.Repositories.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NSubstitute;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Repositories.Orders;

public class OrderRepositoryTests
{
    private static AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"TestDatabase_{Guid.NewGuid()}")
            .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        var context = new AppDbContext(options);
        return context;
    }

    private static IShoppingCartItemRepository GetMockShoppingCartItemRepository()
    {
        return Substitute.For<IShoppingCartItemRepository>();
    }

    [Fact]
    public async Task GetEntitiesAsync_ShouldReturnOrders()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var shoppingCartItemRepository = GetMockShoppingCartItemRepository();
        var repository = new OrderRepository(context, shoppingCartItemRepository);

        var order1 = new Order();
        order1.SetId(1);
        order1.SetOrderDetails([new OrderDetail()]);
        order1.SetDeliveryAddress(new DeliveryAddress());
        order1.SetUserDelivery(new UserDelivery());

        var paymentMethod1 = new PaymentMethod();
        paymentMethod1.SetPaymentMethodObjectValue(new PaymentMethodObjectValue());
        paymentMethod1.SetCreditCard(new CreditCard());
        paymentMethod1.SetDebitCard(new DebitCard());
        order1.SetPaymentMethod(paymentMethod1);

        var order2 = new Order();
        order2.SetId(2);
        order2.SetOrderDetails([new OrderDetail()]);
        order2.SetDeliveryAddress(new DeliveryAddress());
        order2.SetUserDelivery(new UserDelivery());

        var paymentMethod2 = new PaymentMethod();
        paymentMethod2.SetPaymentMethodObjectValue(new PaymentMethodObjectValue());
        paymentMethod2.SetCreditCard(new CreditCard());
        paymentMethod2.SetDebitCard(new DebitCard());
        order2.SetPaymentMethod(paymentMethod2);

        context.Orders.AddRange(new List<Order> { order1, order2 });
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetEntitiesAsync();

        // Assert
        var enumerable = result as Order[] ?? result.ToArray();
        Assert.Equal(2, enumerable.Length);
        Assert.Contains(enumerable, o => o.Id == 1);
        Assert.Contains(enumerable, o => o.Id == 2);
    }

    [Fact]
    public void GetPagingListOrders_ShouldReturnFilteredOrders()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var shoppingCartItemRepository = GetMockShoppingCartItemRepository();
        var repository = new OrderRepository(context, shoppingCartItemRepository);

        var order1 = new Order();
        order1.SetId(1);
        order1.UserDelivery.SetFirstName("Alice");

        var order2 = new Order();
        order2.SetId(2);
        order2.UserDelivery.SetFirstName("Bob");

        context.Orders.AddRange(new List<Order> { order1, order2 });
        context.SaveChanges();

        // Act
        var result = repository.GetPagingListOrders("Alice").ToList();

        // Assert
        Assert.Single(result);
        Assert.Contains(result, o => o.UserDelivery.FirstName == "Alice");
    }

    [Fact]
    public async Task GetOrdersDetailsAsync_ShouldReturnEmptyList()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var shoppingCartItemRepository = GetMockShoppingCartItemRepository();
        var repository = new OrderRepository(context, shoppingCartItemRepository);

        // Act
        var result = await repository.GetOrdersDetailsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task FindByOrderConfirmDateAsync_ShouldReturnOrders()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var shoppingCartItemRepository = GetMockShoppingCartItemRepository();
        var repository = new OrderRepository(context, shoppingCartItemRepository);

        var order1 = new Order();
        order1.SetId(1);
        order1.SetConfirmedOrder(DateTime.Now.AddDays(-1));

        var order2 = new Order();
        order2.SetId(2);
        order2.SetConfirmedOrder(DateTime.Now);

        context.Orders.AddRange(new List<Order> { order1, order2 });
        await context.SaveChangesAsync();

        // Act
        var result = await repository.FindByOrderConfirmDateAsync(DateTime.Now.AddDays(-2), DateTime.Now);

        // Assert
        var enumerable = result as Order[] ?? result.ToArray();
        Assert.Equal(2, enumerable.Length);
        Assert.Contains(enumerable, o => o.Id == 1);
        Assert.Contains(enumerable, o => o.Id == 2);
    }

    [Fact]
    public async Task FindByOrderDispatchedDateAsync_ShouldReturnOrders()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var shoppingCartItemRepository = GetMockShoppingCartItemRepository();
        var repository = new OrderRepository(context, shoppingCartItemRepository);

        var order1 = new Order();
        order1.SetId(1);
        order1.SetDispatchedOrder(DateTime.Now.AddDays(-1));

        var order2 = new Order();
        order2.SetId(2);
        order2.SetDispatchedOrder(DateTime.Now);

        context.Orders.AddRange(new List<Order> { order1, order2 });
        await context.SaveChangesAsync();

        // Act
        var result = await repository.FindByOrderDispatchedDateAsync(DateTime.Now.AddDays(-2), DateTime.Now);

        // Assert
        var enumerable = result as Order[] ?? result.ToArray();
        Assert.Equal(2, enumerable.Length);
        Assert.Contains(enumerable, o => o.Id == 1);
        Assert.Contains(enumerable, o => o.Id == 2);
    }

    [Fact]
    public async Task FindByOrderRequestReceivedDateAsync_ShouldReturnOrders()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var shoppingCartItemRepository = GetMockShoppingCartItemRepository();
        var repository = new OrderRepository(context, shoppingCartItemRepository);

        var order1 = new Order();
        order1.SetId(1);
        order1.SetRequestReceived(DateTime.Now.AddDays(-1));

        var order2 = new Order();
        order2.SetId(2);
        order2.SetRequestReceived(DateTime.Now);

        context.Orders.AddRange(new List<Order> { order1, order2 });
        await context.SaveChangesAsync();

        // Act
        var result = await repository.FindByOrderRequestReceivedDateAsync(DateTime.Now.AddDays(-2), DateTime.Now);

        // Assert
        var enumerable = result as Order[] ?? result.ToArray();
        Assert.Equal(2, enumerable.Length);
        Assert.Contains(enumerable, o => o.Id == 1);
        Assert.Contains(enumerable, o => o.Id == 2);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOrder()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var shoppingCartItemRepository = GetMockShoppingCartItemRepository();
        var repository = new OrderRepository(context, shoppingCartItemRepository);

        var order = new Order();
        order.SetId(1);

        context.Orders.Add(order);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public async Task CreateOrder_ShouldAddOrder()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var shoppingCartItemRepository = GetMockShoppingCartItemRepository();
        var repository = new OrderRepository(context, shoppingCartItemRepository);

        var order = new Order();
        order.SetId(3);

        var creditCard = new CreditCard();
        creditCard.SetCardNumber("4111111111111111");
        creditCard.SetCardHolderName("Test Holder");
        creditCard.SetCardExpirationDate("12/25");
        creditCard.SetCardCvv("123");
        creditCard.SetSsn("123-45-6789");

        var paymentMethod = new PaymentMethod();
        paymentMethod.SetCreditCard(creditCard);

        order.SetPaymentMethod(paymentMethod);

        // Act
        await repository.CreateOrder(order, EPaymentMethod.CreditCard);

        // Assert
        var orderInDb = await context.Orders.FindAsync(3);
        Assert.NotNull(orderInDb);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateOrder()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var shoppingCartItemRepository = GetMockShoppingCartItemRepository();
        var repository = new OrderRepository(context, shoppingCartItemRepository);

        var order = new Order();
        order.SetId(1);

        context.Orders.Add(order);
        await context.SaveChangesAsync();

        order.SetDispatchedOrder(DateTime.Now);

        // Act
        var result = await repository.UpdateAsync(order);

        // Assert
        Assert.Equal(DateTime.Now, result.DispatchedOrder, TimeSpan.FromMinutes(1));
    }
    
    [Fact]
    public async Task DeleteAsync_ShouldRemoveOrder()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var shoppingCartItemRepository = GetMockShoppingCartItemRepository();
        var repository = new OrderRepository(context, shoppingCartItemRepository);

        var order = new Order();
        order.SetId(1);

        context.Orders.Add(order);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.DeleteAsync(order);

        // Assert
        Assert.Equal(1, result.Id);

        var orderInDb = await context.Orders.FindAsync(1);
        Assert.Null(orderInDb);
    }
}