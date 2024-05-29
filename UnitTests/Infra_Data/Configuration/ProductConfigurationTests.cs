using Domain.Entities;
using Infra_Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Configuration;

public class ProductConfigurationTests
{
    [Fact]
    public void Should_Configure_Product()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        using var context = new TestDbContext(options);

        var modelBuilder = new ModelBuilder();
        var productConfiguration = new ProductConfiguration();

        // Act
        productConfiguration.Configure(modelBuilder.Entity<Product>());

        // Assert
        var entityType = modelBuilder.Model.FindEntityType(typeof(Product));
        Assert.NotNull(entityType);

        // Primary Key
        var primaryKey = entityType.FindPrimaryKey();
        Assert.NotNull(primaryKey);
        Assert.Equal("Id", primaryKey.Properties[0].Name);

        // Properties
        var nameProperty = entityType.FindProperty("Name");
        Assert.NotNull(nameProperty);
        Assert.Equal(60, nameProperty.GetMaxLength());
        Assert.False(nameProperty.IsNullable);

        var descriptionProperty = entityType.FindProperty("Description");
        Assert.NotNull(descriptionProperty);
        Assert.Equal(10000, descriptionProperty.GetMaxLength());
        Assert.False(descriptionProperty.IsNullable);

        var imagesUrlProperty = entityType.FindProperty("ImagesUrl");
        Assert.NotNull(imagesUrlProperty);
        Assert.Equal(800, imagesUrlProperty.GetMaxLength());
        Assert.False(imagesUrlProperty.IsNullable);

        // Foreign Key
        var foreignKey = entityType.GetForeignKeys()
            .SingleOrDefault(fk => fk.Properties.Any(p => p.Name == "CategoryId"));
        Assert.NotNull(foreignKey);
        Assert.Equal("CategoryId", foreignKey.Properties[0].Name);

        // Owned Types
        var dataObjectValueOwnership = entityType.FindNavigation(nameof(Product.DataObjectValue));
        Assert.NotNull(dataObjectValueOwnership);
        var dataObjectValueEntityType = dataObjectValueOwnership.TargetEntityType;
        var releaseMonthProperty = dataObjectValueEntityType.FindProperty("ReleaseMonth");
        Assert.NotNull(releaseMonthProperty);
        Assert.Equal(12, releaseMonthProperty.GetMaxLength());
        Assert.False(releaseMonthProperty.IsNullable);

        var releaseYearProperty = dataObjectValueEntityType.FindProperty("ReleaseYear");
        Assert.NotNull(releaseYearProperty);
        Assert.Equal(4, releaseYearProperty.GetMaxLength());
        Assert.False(releaseYearProperty.IsNullable);

        var warrantyObjectValueOwnership = entityType.FindNavigation(nameof(Product.WarrantyObjectValue));
        Assert.NotNull(warrantyObjectValueOwnership);
        var warrantyObjectValueEntityType = warrantyObjectValueOwnership.TargetEntityType;
        var warrantyLengthProperty = warrantyObjectValueEntityType.FindProperty("WarrantyLength");
        Assert.NotNull(warrantyLengthProperty);
        Assert.Equal(30, warrantyLengthProperty.GetMaxLength());
        Assert.False(warrantyLengthProperty.IsNullable);

        var warrantyInformationProperty = warrantyObjectValueEntityType.FindProperty("WarrantyInformation");
        Assert.NotNull(warrantyInformationProperty);
        Assert.Equal(30, warrantyInformationProperty.GetMaxLength());
        Assert.False(warrantyInformationProperty.IsNullable);

        // Similar assertions for SpecificationObjectValue, PriceObjectValue, and CommonPropertiesObjectValue...

        // Example for PriceObjectValue
        var priceObjectValueOwnership = entityType.FindNavigation(nameof(Product.PriceObjectValue));
        Assert.NotNull(priceObjectValueOwnership);
        var priceObjectValueEntityType = priceObjectValueOwnership.TargetEntityType;
        var priceProperty = priceObjectValueEntityType.FindProperty("Price");
        Assert.NotNull(priceProperty);
        Assert.Equal(18, priceProperty.GetPrecision());
        Assert.Equal(2, priceProperty.GetScale());
        Assert.False(priceProperty.IsNullable);
    }
}
