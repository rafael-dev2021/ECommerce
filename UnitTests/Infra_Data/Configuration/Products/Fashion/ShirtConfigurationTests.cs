using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Configuration.Products.Fashion;

public class ShirtConfigurationTests
{
    [Fact]
    public void Should_Configure_Shirt()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        using var context = new TestDbContext(options);

        // Ensure database is created and seeded
        context.Database.EnsureCreated();

        // Act
        var shirts = context.Shirts.ToList();

        // Assert
        Assert.Equal(2, shirts.Count);
        Assert.Contains(shirts, s => s.Id == 7 && s.Name == "Top Nike Swoosh Woman");
        Assert.Contains(shirts, s => s.Id == 8 && s.Name == "Adi color classics firebird track jacket");

        var shirt7 = shirts.FirstOrDefault(s => s.Id == 7);
        Assert.NotNull(shirt7);
        Assert.Equal("Nike", shirt7!.SpecificationObjectValue?.Brand);
        Assert.Equal(16.99M, shirt7.PriceObjectValue?.Price);
        Assert.Equal("1-year warranty", shirt7.WarrantyObjectValue?.WarrantyLength);
        Assert.False(shirt7.FlagsObjectValue?.IsDailyOffer ?? false);
        Assert.Equal("June", shirt7.DataObjectValue?.ReleaseMonth);
        Assert.Equal("T-shirt", shirt7.MainFeaturesObjectValue?.TypeOfClothing);
        Assert.Equal("Woman", shirt7.CommonPropertiesObjectValue?.Gender);
        Assert.Equal("Polyester", shirt7.OtherFeaturesObjectValue?.Composition);

        var shirt8 = shirts.FirstOrDefault(s => s.Id == 8);
        Assert.NotNull(shirt8);
        Assert.Equal("Adidas", shirt8!.SpecificationObjectValue?.Brand);
        Assert.Equal(64.99M, shirt8.PriceObjectValue?.Price);
        Assert.Equal("1-year warranty", shirt8.WarrantyObjectValue?.WarrantyLength);
        Assert.True(shirt8.FlagsObjectValue?.IsDailyOffer ?? false);
        Assert.Equal("March", shirt8.DataObjectValue?.ReleaseMonth);
        Assert.Equal("T-shirt", shirt8.MainFeaturesObjectValue?.TypeOfClothing);
        Assert.Equal("Woman", shirt8.CommonPropertiesObjectValue?.Gender);
        Assert.Equal("Cotton", shirt8.OtherFeaturesObjectValue?.MainMaterial);
    }
}
