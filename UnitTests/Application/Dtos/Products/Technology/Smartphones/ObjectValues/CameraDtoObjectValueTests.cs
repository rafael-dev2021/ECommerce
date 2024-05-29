using Application.Dtos.Products.Technology.Smartphones.ObjectValues;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.Products.Technology.Smartphones.ObjectValues;

public class CameraDtoObjectValueTests
{
    [Fact]
    public void CameraDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string mainCameraSpec = "48 MP";
        string mainCameraFeature = "Auto-focus";
        string selfieCameraSpec = "16 MP";
        string selfieCameraFeature = "Portrait mode";

        // Act
        var cameraDtoObjectValue = new CameraDtoObjectValue(mainCameraSpec, mainCameraFeature, selfieCameraSpec, selfieCameraFeature);

        // Assert
        Assert.Equal(mainCameraSpec, cameraDtoObjectValue.MainCameraSpec);
        Assert.Equal(mainCameraFeature, cameraDtoObjectValue.MainCameraFeature);
        Assert.Equal(selfieCameraSpec, cameraDtoObjectValue.SelfieCameraSpec);
        Assert.Equal(selfieCameraFeature, cameraDtoObjectValue.SelfieCameraFeature);
    }
}
