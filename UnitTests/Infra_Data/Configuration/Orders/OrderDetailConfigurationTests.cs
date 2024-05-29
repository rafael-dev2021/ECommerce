using Domain.Entities.Orders;
using Infra_Data.Configuration.Orders;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Configuration.Orders;

public class OrderDetailConfigurationTests
{
    [Fact]
    public void Should_Configure_OrderDetail()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        using var context = new TestDbContext(options);

        // Ensure database is created
        context.Database.EnsureCreated();

        // Act
        var modelBuilder = new ModelBuilder();
        var orderDetailConfiguration = new OrderDetailConfiguration();
        orderDetailConfiguration.Configure(modelBuilder.Entity<OrderDetail>());

        // Assert
        var entityType = modelBuilder.Model.FindEntityType(typeof(OrderDetail));
        Assert.NotNull(entityType);

        // Primary Key
        var primaryKey = entityType.FindPrimaryKey();
        Assert.NotNull(primaryKey);
        Assert.Equal("Id", primaryKey.Properties[0].Name);

        // Properties
        var priceProperty = entityType.FindProperty("Price");
        Assert.NotNull(priceProperty);
        Assert.Equal(18, priceProperty.GetPrecision());
        Assert.Equal(2, priceProperty.GetScale());

        // Foreign Keys
        var orderForeignKey = entityType.GetForeignKeys().SingleOrDefault(fk => fk.Properties.Any(p => p.Name == "OrderId"));
        Assert.NotNull(orderForeignKey);
        Assert.Equal("OrderId", orderForeignKey.Properties[0].Name);

        var paymentMethodForeignKey = entityType.GetForeignKeys().SingleOrDefault(fk => fk.Properties.Any(p => p.Name == "PaymentMethodId"));
        Assert.NotNull(paymentMethodForeignKey);
        Assert.Equal("PaymentMethodId", paymentMethodForeignKey.Properties[0].Name);
        Assert.Equal(DeleteBehavior.NoAction, paymentMethodForeignKey.DeleteBehavior);
    }
}
