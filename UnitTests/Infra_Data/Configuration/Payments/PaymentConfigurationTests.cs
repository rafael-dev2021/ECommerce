using Domain.Entities.Payments;
using Infra_Data.Configuration.Payments;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Configuration.Payments;

public class PaymentConfigurationTests
{
    [Fact]
    public void Should_Configure_Payment()
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
        var paymentConfiguration = new PaymentConfiguration();
        paymentConfiguration.Configure(modelBuilder.Entity<Payment>());

        // Assert
        var entityType = modelBuilder.Model.FindEntityType(typeof(Payment));
        Assert.NotNull(entityType);

        // Primary Key
        var primaryKey = entityType.FindPrimaryKey();
        Assert.NotNull(primaryKey);
        Assert.Equal("Id", primaryKey.Properties[0].Name);

        // Properties
        var amountProperty = entityType.FindProperty("Amount");
        Assert.NotNull(amountProperty);
        Assert.Equal(18, amountProperty.GetPrecision());
        Assert.Equal(2, amountProperty.GetScale());

        var ssnProperty = entityType.FindProperty("Ssn");
        Assert.NotNull(ssnProperty);
        Assert.Equal(15, ssnProperty.GetMaxLength());

        // Owned Types
        var paymentMethodNavigation = entityType.FindNavigation("PaymentMethodObjectValue");
        Assert.NotNull(paymentMethodNavigation);
        var paymentMethodEntityType = paymentMethodNavigation.TargetEntityType;

        var paymentMethodProperty = paymentMethodEntityType.FindProperty("PaymentMethod");
        Assert.NotNull(paymentMethodProperty);
        Assert.False(paymentMethodProperty.IsNullable);

        var paymentStatusNavigation = paymentMethodEntityType.FindNavigation("PaymentStatusObjectValue");
        Assert.NotNull(paymentStatusNavigation);
        var paymentStatusEntityType = paymentStatusNavigation.TargetEntityType;

        var paymentStatusProperty = paymentStatusEntityType.FindProperty("PaymentStatus");
        Assert.NotNull(paymentStatusProperty);
        Assert.False(paymentStatusProperty.IsNullable);
    }
}
