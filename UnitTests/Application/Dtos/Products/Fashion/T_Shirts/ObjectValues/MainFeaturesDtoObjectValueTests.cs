using Application.Dtos.Products.Fashion.T_Shirts.ObjectValues;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.Products.Fashion.T_Shirts.ObjectValues;

public class MainFeaturesDtoObjectValueTests
{
    [Fact]
    public void MainFeaturesDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string typeOfClothing = "T-Shirt";
        string fabricDesign = "Striped";

        // Act
        var mainFeaturesDtoObjectValue = new MainFeaturesDtoObjectValue(typeOfClothing, fabricDesign);

        // Assert
        Assert.Equal(typeOfClothing, mainFeaturesDtoObjectValue.TypeOfClothing);
        Assert.Equal(fabricDesign, mainFeaturesDtoObjectValue.FabricDesign);
    }
}
