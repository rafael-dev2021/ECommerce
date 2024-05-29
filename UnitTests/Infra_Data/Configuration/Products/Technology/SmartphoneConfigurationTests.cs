using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Configuration.Products.Technology;

public class SmartphoneConfigurationTests
{
    [Fact]
    public void Should_Configure_Smartphones()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        using var context = new TestDbContext(options);

        // Ensure database is created and seeded
        context.Database.EnsureCreated();

        // Act
        var smartphones = context.Smartphones.ToList();

        // Assert
        Assert.Equal(4, smartphones.Count);
        Assert.Contains(smartphones, s => s.Id == 1 && s.Name == "Samsung Galaxy S23 Ultra 512GB Unlocked - Black");
        Assert.Contains(smartphones, s => s.Id == 2 && s.Name == "Samsung Galaxy S23 Ultra 256GB - Violet");
        Assert.Contains(smartphones, s => s.Id == 3 && s.Name == "Apple iPhone 15 Pro (512 GB) - Titanium Blue");
        Assert.Contains(smartphones, s => s.Id == 4 && s.Name == "Apple iPhone 15 Pro (128 GB) - Titanium White");

        var smartphone1 = smartphones.FirstOrDefault(s => s.Id == 1);
        Assert.NotNull(smartphone1);
        Assert.Equal("Samsung", smartphone1.SpecificationObjectValue?.Brand);
        Assert.Equal(2179.99M, smartphone1.PriceObjectValue?.Price);
        Assert.Equal("1-year warranty", smartphone1.WarrantyObjectValue?.WarrantyLength);
        Assert.True(smartphone1.FlagsObjectValue?.IsDailyOffer ?? false);
        Assert.Equal("June", smartphone1.DataObjectValue?.ReleaseMonth);
        Assert.Equal("Dynamic AMOLED 2X 120 Hz", smartphone1.DisplayObjectValue?.DisplayType);
        Assert.Equal(12, smartphone1.StorageObjectValue?.RamGb);
        Assert.Equal("WCDMA (UMTS) / GSM / 5G", smartphone1.FeatureObjectValue?.CellNetworkTechnology);
        Assert.Equal("Android", smartphone1.PlatformObjectValue?.OperatingSystem);
        Assert.Equal(163.4, smartphone1.DimensionObjectValue?.HeightInches);
        Assert.Equal("Li-Ion", smartphone1.BatteryObjectValue?.BatteryType);

        var smartphone2 = smartphones.FirstOrDefault(s => s.Id == 2);
        Assert.NotNull(smartphone2);
        Assert.Equal("Samsung", smartphone2.SpecificationObjectValue?.Brand);
        Assert.Equal(1624.99M, smartphone2.PriceObjectValue?.Price);
        Assert.Equal("1-year warranty", smartphone2.WarrantyObjectValue?.WarrantyLength);
        Assert.True(smartphone2.FlagsObjectValue?.IsDailyOffer ?? false);
        Assert.Equal("August", smartphone2.DataObjectValue?.ReleaseMonth);
        Assert.Equal("Dynamic AMOLED 2X", smartphone2.DisplayObjectValue?.DisplayType);
        Assert.Equal(8, smartphone2.StorageObjectValue?.RamGb);
        Assert.Equal("WCDMA (UMTS) / GSM / 5G", smartphone2.FeatureObjectValue?.CellNetworkTechnology);
        Assert.Equal("Android", smartphone2.PlatformObjectValue?.OperatingSystem);
        Assert.Equal(163.4, smartphone2.DimensionObjectValue?.HeightInches);
        Assert.Equal("Lithium Ion", smartphone2.BatteryObjectValue?.BatteryType);

        var smartphone3 = smartphones.FirstOrDefault(s => s.Id == 3);
        Assert.NotNull(smartphone3);
        Assert.Equal("Apple", smartphone3.SpecificationObjectValue?.Brand);
        Assert.Equal(2035.99M, smartphone3.PriceObjectValue?.Price);
        Assert.Equal("1-year warranty", smartphone3.WarrantyObjectValue?.WarrantyLength);
        Assert.True(smartphone3.FlagsObjectValue?.IsDailyOffer ?? false);
        Assert.Equal("Februery", smartphone3.DataObjectValue?.ReleaseMonth); 
        Assert.Equal("Super Retina XDR", smartphone3.DisplayObjectValue?.DisplayType);
        Assert.Equal(8, smartphone3.StorageObjectValue?.RamGb);
        Assert.Equal("WCDMA (UMTS) / GSM / 5G", smartphone3.FeatureObjectValue?.CellNetworkTechnology);
        Assert.Equal("iOS", smartphone3.PlatformObjectValue?.OperatingSystem);
        Assert.Equal(160.9, smartphone3.DimensionObjectValue?.HeightInches);
        Assert.Equal("Lithium Ion", smartphone3.BatteryObjectValue?.BatteryType);

        var smartphone4 = smartphones.FirstOrDefault(s => s.Id == 4);
        Assert.NotNull(smartphone4);
        Assert.Equal("Apple", smartphone4.SpecificationObjectValue?.Brand);
        Assert.Equal(1624.99M, smartphone4.PriceObjectValue?.Price);
        Assert.Equal("1-year warranty", smartphone4.WarrantyObjectValue?.WarrantyLength);
        Assert.True(smartphone4.FlagsObjectValue?.IsDailyOffer ?? false);
        Assert.Equal("March", smartphone4.DataObjectValue?.ReleaseMonth);
        Assert.Equal("Super Retina XDR", smartphone4.DisplayObjectValue?.DisplayType);
        Assert.Equal(8, smartphone4.StorageObjectValue?.RamGb);
        Assert.Equal("WCDMA (UMTS) / GSM / 5G", smartphone4.FeatureObjectValue?.CellNetworkTechnology);
        Assert.Equal("iOS", smartphone4.PlatformObjectValue?.OperatingSystem);
        Assert.Equal(160.9, smartphone4.DimensionObjectValue?.HeightInches);
        Assert.Equal("Lithium Ion", smartphone4.BatteryObjectValue?.BatteryType);
    }
}
