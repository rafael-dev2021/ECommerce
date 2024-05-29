using Application.Dtos.ObjectsValues.ProductObjectValue;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.ObjectsValues.ProductObjectValue;

public class WarrantyDtoObjectValueTests
{
    [Fact]
    public void WarrantyDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string warrantyLength = "1 year";
        string warrantyInformation = "Limited warranty";

        // Act
        var warrantyDtoObjectValue = new WarrantyDtoObjectValue(warrantyLength, warrantyInformation);

        // Assert
        Assert.Equal(warrantyLength, warrantyDtoObjectValue.WarrantyLength);
        Assert.Equal(warrantyInformation, warrantyDtoObjectValue.WarrantyInformation);
    }
}
