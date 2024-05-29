using Domain.Entities.Payments;
using Infra_Data.Configuration.Payments;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Configuration.Payments;

public class CardConfigurationTests
{
    [Fact]
    public void Should_Configure_Card()
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
        var cardConfiguration = new CardConfiguration();
        cardConfiguration.Configure(modelBuilder.Entity<Card>());

        // Assert
        var entityType = modelBuilder.Model.FindEntityType(typeof(Card));
        Assert.NotNull(entityType);

        // Primary Key
        var primaryKey = entityType.FindPrimaryKey();
        Assert.NotNull(primaryKey);
        Assert.Equal("Id", primaryKey.Properties[0].Name);

        // Properties
        var cardNumberProperty = entityType.FindProperty("CardNumber");
        Assert.NotNull(cardNumberProperty);
        Assert.Equal(19, cardNumberProperty.GetMaxLength());
        Assert.False(cardNumberProperty.IsNullable);

        var cardHolderNameProperty = entityType.FindProperty("CardHolderName");
        Assert.NotNull(cardHolderNameProperty);
        Assert.Equal(50, cardHolderNameProperty.GetMaxLength());
        Assert.False(cardHolderNameProperty.IsNullable);

        var cardExpirationDateProperty = entityType.FindProperty("CardExpirationDate");
        Assert.NotNull(cardExpirationDateProperty);
        Assert.Equal(5, cardExpirationDateProperty.GetMaxLength());
        Assert.False(cardExpirationDateProperty.IsNullable);

        var cardCvvProperty = entityType.FindProperty("CardCvv");
        Assert.NotNull(cardCvvProperty);
        Assert.Equal(4, cardCvvProperty.GetMaxLength());
        Assert.False(cardCvvProperty.IsNullable);

        var ssnProperty = entityType.FindProperty("Ssn");
        Assert.NotNull(ssnProperty);
        Assert.Equal(15, ssnProperty.GetMaxLength());
        Assert.True(ssnProperty.IsNullable);
    }
}
