using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Configuration.Products.Fashion;

public class ShoesConfigurationTests
{
    [Fact]
    public void Should_Configure_Shoes()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        using var context = new TestDbContext(options);

        // Ensure database is created and seeded
        context.Database.EnsureCreated();

        // Act
        var shoes = context.Shoes.ToList();

        // Assert
        Assert.Equal(2, shoes.Count);
        Assert.Contains(shoes, s => s.Id == 9 && s.Name == "Nike Streak-fly");
        Assert.Contains(shoes, s => s.Id == 10 && s.Name == "Suede Classic XXI Sneakers");

        var shoe9 = shoes.FirstOrDefault(s => s.Id == 9);
        Assert.NotNull(shoe9);
        Assert.Equal("Nike", shoe9!.SpecificationObjectValue?.Brand);
        Assert.Equal(71.99M, shoe9.PriceObjectValue?.Price);
        Assert.Equal("1-year warranty", shoe9.WarrantyObjectValue?.WarrantyLength);
        Assert.True(shoe9.FlagsObjectValue?.IsDailyOffer ?? false);
        Assert.Equal("June", shoe9.DataObjectValue?.ReleaseMonth);
        Assert.Equal("Woman", shoe9.CommonPropertiesObjectValue?.Gender);
        Assert.Equal("Leather", shoe9.MaterialObjectValue?.MaterialsFromAbroad);

        var shoe10 = shoes.FirstOrDefault(s => s.Id == 10);
        Assert.NotNull(shoe10);
        Assert.Equal("Puma", shoe10!.SpecificationObjectValue?.Brand);
        Assert.Equal(75.99M, shoe10.PriceObjectValue?.Price);
        Assert.Equal("1-year warranty", shoe10.WarrantyObjectValue?.WarrantyLength);
        Assert.False(shoe10.FlagsObjectValue?.IsDailyOffer ?? false);
        Assert.Equal("October", shoe10.DataObjectValue?.ReleaseMonth);
        Assert.Equal("Man", shoe10.CommonPropertiesObjectValue?.Gender);
        Assert.Equal("Leather", shoe10.MaterialObjectValue?.MaterialsFromAbroad);
    }
}