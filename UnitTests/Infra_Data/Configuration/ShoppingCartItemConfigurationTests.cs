using Domain.Entities.Cart;
using Infra_Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Configuration;

public class ShoppingCartItemConfigurationTests
{
    [Fact]
    public void Should_Configure_ShoppingCartItem()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        using var context = new TestDbContext(options);

        var modelBuilder = new ModelBuilder();
        var shoppingCartItemConfiguration = new ShoppingCartItemConfiguration();

        // Act
        shoppingCartItemConfiguration.Configure(modelBuilder.Entity<ShoppingCartItem>());

        // Assert
        var entityType = modelBuilder.Model.FindEntityType(typeof(ShoppingCartItem));
        Assert.NotNull(entityType);

        var primaryKey = entityType.FindPrimaryKey();
        Assert.NotNull(primaryKey);
        Assert.Equal("Id", primaryKey.Properties[0].Name);

        var shoppingCartIdProperty = entityType.FindProperty("ShoppingCartId");
        Assert.NotNull(shoppingCartIdProperty);
        Assert.Equal(200, shoppingCartIdProperty.GetMaxLength());

        var productNavigation = entityType.FindNavigation("Product");
        Assert.NotNull(productNavigation);

        var foreignKey = entityType.GetForeignKeys()
            .SingleOrDefault(fk => fk.Properties.Any(p => p.Name == "ProductId"));
        Assert.NotNull(foreignKey);
        Assert.Equal(DeleteBehavior.Restrict, foreignKey.DeleteBehavior);
    }
}
