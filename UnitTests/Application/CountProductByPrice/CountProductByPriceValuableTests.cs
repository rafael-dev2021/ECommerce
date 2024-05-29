using Application.Services.CountProductByPrice;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.CountProductByPrice;

public class CountProductByPriceValuableTests
{
    [Fact]
    public void CountProductByPriceValuable_ShouldCreateInstanceWithDefaultValues()
    {
        // Arrange & Act
        var countProductByPriceValuable = new CountProductByPriceValuable();

        // Assert
        Assert.Equal(0, countProductByPriceValuable.CountPriceIsHigherThanTwoThousand);
        Assert.Equal(0, countProductByPriceValuable.CountPriceIsBetweenTwoHundredAndAThousand);
        Assert.Equal(0, countProductByPriceValuable.CountPriceIsLowerThanOneHundred);
    }

    [Fact]
    public void CountProductByPriceValuable_ShouldSetValuesCorrectly()
    {
        // Arrange
        var countPriceIsHigherThanTwoThousand = 10;
        var countPriceIsBetweenTwoHundredAndAThousand = 20;
        var countPriceIsLowerThanOneHundred = 30;

        // Act
        var countProductByPriceValuable = new CountProductByPriceValuable
        {
            CountPriceIsHigherThanTwoThousand = countPriceIsHigherThanTwoThousand,
            CountPriceIsBetweenTwoHundredAndAThousand = countPriceIsBetweenTwoHundredAndAThousand,
            CountPriceIsLowerThanOneHundred = countPriceIsLowerThanOneHundred
        };

        // Assert
        Assert.Equal(countPriceIsHigherThanTwoThousand, countProductByPriceValuable.CountPriceIsHigherThanTwoThousand);
        Assert.Equal(countPriceIsBetweenTwoHundredAndAThousand, countProductByPriceValuable.CountPriceIsBetweenTwoHundredAndAThousand);
        Assert.Equal(countPriceIsLowerThanOneHundred, countProductByPriceValuable.CountPriceIsLowerThanOneHundred);
    }
}
