using Application.Dtos.Products.Fashion.T_Shirts.ObjectValues;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.Products.Fashion.T_Shirts.ObjectValues;

public class OtherFeaturesDtoObjectValueTests
{
    [Fact]
    public void OtherFeaturesDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string composition = "Cotton";
        string mainMaterial = "Polyester";
        int unitsPerKit = 5;
        bool withRecycledMaterials = true;
        bool itsSporty = false;

        // Act
        var otherFeaturesDtoObjectValue = new OtherFeaturesDtoObjectValue(composition, mainMaterial, unitsPerKit, withRecycledMaterials, itsSporty);

        // Assert
        Assert.Equal(composition, otherFeaturesDtoObjectValue.Composition);
        Assert.Equal(mainMaterial, otherFeaturesDtoObjectValue.MainMaterial);
        Assert.Equal(unitsPerKit, otherFeaturesDtoObjectValue.UnitsPerKit);
        Assert.Equal(withRecycledMaterials, otherFeaturesDtoObjectValue.WithRecycledMaterials);
        Assert.Equal(itsSporty, otherFeaturesDtoObjectValue.ItsSporty);
    }
}
