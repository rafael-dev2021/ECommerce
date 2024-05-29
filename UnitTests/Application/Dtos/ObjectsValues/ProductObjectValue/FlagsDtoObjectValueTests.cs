using Application.Dtos.ObjectsValues.ProductObjectValue;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.ObjectsValues.ProductObjectValue;

public class FlagsDtoObjectValueTests
{
    [Fact]
    public void FlagsDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        bool isFavorite = true;
        bool isDailyOffer = false;
        bool isBestSeller = true;

        // Act
        var flagsDtoObjectValue = new FlagsDtoObjectValue(isFavorite, isDailyOffer, isBestSeller);

        // Assert
        Assert.Equal(isFavorite, flagsDtoObjectValue.IsFavorite);
        Assert.Equal(isDailyOffer, flagsDtoObjectValue.IsDailyOffer);
        Assert.Equal(isBestSeller, flagsDtoObjectValue.IsBestSeller);
    }
}
