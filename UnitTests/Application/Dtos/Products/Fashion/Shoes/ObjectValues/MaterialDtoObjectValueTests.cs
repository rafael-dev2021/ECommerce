using Application.Dtos.Products.Fashion.Shoes.ObjectValues;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.Products.Fashion.Shoes.ObjectValues;

public class MaterialDtoObjectValueTests
{
    [Fact]
    public void MaterialDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string materialsFromAbroad = "Leather";
        string interiorMaterials = "Fabric";
        string soleMaterials = "Rubber";

        // Act
        var materialDtoObjectValue = new MaterialDtoObjectValue(materialsFromAbroad, interiorMaterials, soleMaterials);

        // Assert
        Assert.Equal(materialsFromAbroad, materialDtoObjectValue.MaterialsFromAbroad);
        Assert.Equal(interiorMaterials, materialDtoObjectValue.InteriorMaterials);
        Assert.Equal(soleMaterials, materialDtoObjectValue.SoleMaterials);
    }
}
