using Application.Dtos.ObjectsValues.ProductObjectValue;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.ObjectsValues.ProductObjectValue;

public class PriceDtoObjectValueTests
{
    [Fact]
    public void PriceDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        decimal price = 100.0m;
        decimal historyPrice = 90.0m;

        // Act
        var priceDtoObjectValue = new PriceDtoObjectValue(price, historyPrice);

        // Assert
        Assert.Equal(price, priceDtoObjectValue.Price);
        Assert.Equal(historyPrice, priceDtoObjectValue.HistoryPrice);
    }
}
