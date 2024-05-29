using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Configuration.Products.Technology;

public class GameConfigurationTests
{
    [Fact]
    public void Should_Configure_Games()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        using var context = new TestDbContext(options);

        // Ensure database is created and seeded
        context.Database.EnsureCreated();

        // Act
        var games = context.Games.ToList();

        // Assert
        Assert.Equal(2, games.Count);
        Assert.Contains(games, g => g.Id == 5 && g.Name == "Marvel's Spider-Man: Miles Morales Standard Edition Sony PS5");
        Assert.Contains(games, g => g.Id == 6 && g.Name == "God of War Ragnarök Standard Edition Sony PS5");

        var game5 = games.FirstOrDefault(g => g.Id == 5);
        Assert.NotNull(game5);
        Assert.Equal("Sony", game5!.SpecificationObjectValue?.Brand);
        Assert.Equal(30.99M, game5.PriceObjectValue?.Price);
        Assert.Equal("1-year warranty", game5.WarrantyObjectValue?.WarrantyLength);
        Assert.True(game5.FlagsObjectValue?.IsBestSeller ?? false);
        Assert.Equal("June", game5.DataObjectValue?.ReleaseMonth);
        Assert.Equal("Spider man", game5.GeneralFeaturesObjectValue?.Collection);
        Assert.Equal(60, game5.RequirementObjectValue?.MinimumRamRequirementInMb);
        Assert.Equal("Physical", game5.MediaSpecificationObjectValue?.Format);

        var game6 = games.FirstOrDefault(g => g.Id == 6);
        Assert.NotNull(game6);
        Assert.Equal("Sony", game6!.SpecificationObjectValue?.Brand);
        Assert.Equal(38.99M, game6.PriceObjectValue?.Price);
        Assert.Equal("1-year warranty", game6.WarrantyObjectValue?.WarrantyLength);
        Assert.True(game6.FlagsObjectValue?.IsBestSeller ?? false);
        Assert.Equal("July", game6.DataObjectValue?.ReleaseMonth);
        Assert.Equal("God of War", game6.GeneralFeaturesObjectValue?.Collection);
        Assert.Equal(60, game6.RequirementObjectValue?.MinimumRamRequirementInMb);
        Assert.Equal("Physical", game6.MediaSpecificationObjectValue?.Format);
    }
}
