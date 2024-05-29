using Domain.Entities.Orders;
using Infra_Data.Configuration.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Configuration.Orders;

public class OrderConfigurationTests
{
    [Fact]
    public void Should_Configure_Order()
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
        var orderConfiguration = new OrderConfiguration();
        orderConfiguration.Configure(modelBuilder.Entity<Order>());

        // Assert
        var entityType = modelBuilder.Model.FindEntityType(typeof(Order));
        Assert.NotNull(entityType);

        // Primary Key
        var primaryKey = entityType.FindPrimaryKey();
        Assert.NotNull(primaryKey);
        Assert.Equal("Id", primaryKey.Properties[0].Name);

        // Properties
        var totalOrderProperty = entityType.FindProperty("TotalOrder");
        Assert.NotNull(totalOrderProperty);
        Assert.Equal(18, totalOrderProperty.GetPrecision());
        Assert.Equal(2, totalOrderProperty.GetScale());

        // Owned Types
        var deliveryAddressOwnership = entityType.FindNavigation(nameof(Order.DeliveryAddress));
        Assert.NotNull(deliveryAddressOwnership);
        var deliveryAddressEntityType = deliveryAddressOwnership.TargetEntityType;

        AssertProperty(deliveryAddressEntityType, "ZipCode", 11);
        AssertProperty(deliveryAddressEntityType, "Address", 60);
        AssertProperty(deliveryAddressEntityType, "Complement", 60);
        AssertProperty(deliveryAddressEntityType, "State", 30);
        AssertProperty(deliveryAddressEntityType, "City", 30);
        AssertProperty(deliveryAddressEntityType, "Neighborhood", 30);
        AssertProperty(deliveryAddressEntityType, "Country", 30);

        var userDeliveryOwnership = entityType.FindNavigation(nameof(Order.UserDelivery));
        Assert.NotNull(userDeliveryOwnership);
        var userDeliveryEntityType = userDeliveryOwnership.TargetEntityType;

        AssertProperty(userDeliveryEntityType, "FirstName", 15);
        AssertProperty(userDeliveryEntityType, "LastName", 15);
        AssertProperty(userDeliveryEntityType, "Email", 50);
        AssertProperty(userDeliveryEntityType, "Phone", 16);
        AssertProperty(userDeliveryEntityType, "Ssn", 15);
    }

    private static void AssertProperty(IMutableEntityType entityType, string propertyName, int maxLength)
    {
        var property = entityType.FindProperty(propertyName);
        Assert.NotNull(property);
        Assert.Equal(maxLength, property.GetMaxLength());
        Assert.False(property.IsNullable);
    }
}
