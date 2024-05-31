using Application.Dtos.ObjectsValues.ProductObjectValue;
using Application.Services.Discounts;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Discounts;

public class CalculateDiscountServiceTests
{
    private readonly CalculateDiscountService _calculateDiscountService = new();

    [Fact]
    public void DiscountPercentage_ShouldReturnZero_WhenHistoryPriceIsZero()
    {
        // Arrange
        var price = new PriceDtoObjectValue(100.0m, 0.0m);

        // Act
        var result = _calculateDiscountService.DiscountPercentage(price);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void DiscountPercentage_ShouldCalculateDiscountPercentage()
    {
        // Arrange
        var price = new PriceDtoObjectValue(100.0m, 1120.0m);

        // Act
        var result = _calculateDiscountService.DiscountPercentage(price);

        // Assert
        Assert.Equal(91.07142857142857142857142857m, result);
    }

    [Fact]
    public void InSixInstallmentWithoutInterest_ShouldCalculateInstallmentValueWithoutInterest()
    {
        // Arrange
        var price = new PriceDtoObjectValue(600.0m, 0.0m);

        // Act
        var result = _calculateDiscountService.InSixInstallmentWithoutInterest(price);

        // Assert
        Assert.Equal(100.0m, result);
    }

    [Fact]
    public void InThreeInstallmentWithInterest_ShouldCalculateInstallmentValueWithInterest()
    {
        // Arrange
        var price = new PriceDtoObjectValue(300.0m, 0.0m);

        // Act
        var result = _calculateDiscountService.InThreeInstallmentWithInterest(price);

        // Assert
        Assert.Equal(103.0m, result);
    }


    [Fact]
    public void InTwelveInstallmentWithoutInterest_ShouldCalculateInstallmentValueWithoutInterest()
    {
        // Arrange
        var price = new PriceDtoObjectValue(1200.0m, 0.0m);

        // Act
        var result = _calculateDiscountService.InTwelveInstallmentWithoutInterest(price);

        // Assert
        Assert.Equal(100.0m, result);
    }
}
