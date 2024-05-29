using Application.Dtos.Products.Technology.Smartphones.ObjectValues;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.Products.Technology.Smartphones.ObjectValues;

public class DimensionDtoObjectValueTests
{
    [Fact]
    public void DimensionDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        double heightInches = 6.2;
        double widthInches = 3.0;
        double thicknessInches = 0.4;

        // Act
        var dimensionDtoObjectValue = new DimensionDtoObjectValue(heightInches, widthInches, thicknessInches);

        // Assert
        Assert.Equal(heightInches, dimensionDtoObjectValue.HeightInches);
        Assert.Equal(widthInches, dimensionDtoObjectValue.WidthInches);
        Assert.Equal(thicknessInches, dimensionDtoObjectValue.ThicknessInches);
    }
}