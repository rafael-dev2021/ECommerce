using Application.Dtos.Products.Technology.Smartphones.ObjectValues;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.Products.Technology.Smartphones.ObjectValues;

public class DisplayDtoObjectValueTests
{
    [Fact]
    public void DisplayDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string displayType = "AMOLED";
        string displayResolution = "1080x2340";
        string displayProtection = "Corning Gorilla Glass 6";
        double displaySizeInches = 6.5;

        // Act
        var displayDtoObjectValue = new DisplayDtoObjectValue(displayType, displayResolution, displayProtection, displaySizeInches);

        // Assert
        Assert.Equal(displayType, displayDtoObjectValue.DisplayType);
        Assert.Equal(displayResolution, displayDtoObjectValue.DisplayResolution);
        Assert.Equal(displayProtection, displayDtoObjectValue.DisplayProtection);
        Assert.Equal(displaySizeInches, displayDtoObjectValue.DisplaySizeInches);
    }
}
