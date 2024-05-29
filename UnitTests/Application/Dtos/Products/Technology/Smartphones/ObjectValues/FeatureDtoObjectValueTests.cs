using Application.Dtos.Products.Technology.Smartphones.ObjectValues;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.Products.Technology.Smartphones.ObjectValues;

public class FeatureDtoObjectValueTests
{
    [Fact]
    public void FeatureDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string cellNetworkTechnology = "5G";
        string virtualAssistant = "Siri";
        string manufacturerPartNumber = "ABC123";

        // Act
        var featureDtoObjectValue = new FeatureDtoObjectValue(cellNetworkTechnology, virtualAssistant, manufacturerPartNumber);

        // Assert
        Assert.Equal(cellNetworkTechnology, featureDtoObjectValue.CellNetworkTechnology);
        Assert.Equal(virtualAssistant, featureDtoObjectValue.VirtualAssistant);
        Assert.Equal(manufacturerPartNumber, featureDtoObjectValue.ManufacturerPartNumber);
    }
}
