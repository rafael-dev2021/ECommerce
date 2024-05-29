using Application.Services.Discounts;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Discounts;

public class CalculateDiscountValuableTests
{
    [Fact]
    public void CalculateDiscountValuable_SetDiscountPercentage_ShouldSetCorrectValue()
    {
        // Arrange
        decimal expectedDiscountPercentage = 10.5m;
        var calculateDiscountValuable = new CalculateDiscountValuable
        {
            // Act
            DiscountPercentage = expectedDiscountPercentage
        };

        // Assert
        Assert.Equal(expectedDiscountPercentage, calculateDiscountValuable.DiscountPercentage);
    }

    [Fact]
    public void CalculateDiscountValuable_SetInTwelveInstallmentWithoutInterest_ShouldSetCorrectValue()
    {
        // Arrange
        decimal expectedValue = 500m;
        var calculateDiscountValuable = new CalculateDiscountValuable();

        // Act
        calculateDiscountValuable.InTwelveInstallmentWithoutInterest = expectedValue;

        // Assert
        Assert.Equal(expectedValue, calculateDiscountValuable.InTwelveInstallmentWithoutInterest);
    }

    [Fact]
    public void CalculateDiscountValuable_SetInThreeInstallmentWithInterest_ShouldSetCorrectValue()
    {
        // Arrange
        decimal expectedValue = 200m;
        var calculateDiscountValuable = new CalculateDiscountValuable();

        // Act
        calculateDiscountValuable.InThreeInstallmentWithInterest = expectedValue;

        // Assert
        Assert.Equal(expectedValue, calculateDiscountValuable.InThreeInstallmentWithInterest);
    }

    [Fact]
    public void CalculateDiscountValuable_SetInSixInstallmentWithoutInterest_ShouldSetCorrectValue()
    {
        // Arrange
        decimal expectedValue = 400m;
        var calculateDiscountValuable = new CalculateDiscountValuable
        {
            // Act
            InSixInstallmentWithoutInterest = expectedValue
        };

        // Assert
        Assert.Equal(expectedValue, calculateDiscountValuable.InSixInstallmentWithoutInterest);
    }
}
