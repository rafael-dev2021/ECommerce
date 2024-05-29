using Application.Dtos.ObjectsValues.ProductObjectValue;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.ObjectsValues.ProductObjectValue;

public class CommonPropertiesDtoObjectValueTests
{
    [Fact]
    public void CommonPropertiesDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        var gender = "Male";
        var color = "Blue";
        var age = "Adult";
        var recommendedUses = "Outdoor activities";
        var size = "Large";

        // Act
        var commonPropertiesDtoObjectValue = new CommonPropertiesDtoObjectValue(gender, color, age, recommendedUses, size);

        // Assert
        Assert.Equal(gender, commonPropertiesDtoObjectValue.Gender);
        Assert.Equal(color, commonPropertiesDtoObjectValue.Color);
        Assert.Equal(age, commonPropertiesDtoObjectValue.Age);
        Assert.Equal(recommendedUses, commonPropertiesDtoObjectValue.RecommendedUses);
        Assert.Equal(size, commonPropertiesDtoObjectValue.Size);
    }
}
