using Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using Xunit;

namespace UnitTests.Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class CameraObjectValueTests
{
    private readonly CameraObjectValueValidator _validator = new();

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_MainCameraSpec_Is_Valid()
    {
        // Arrange
        var cameraObjectValue = new CameraObjectValue();
        cameraObjectValue.SetMainCameraSpec("16 MP");
        // Act
        var result = _validator.TestValidate(cameraObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.MainCameraSpec);
    }
    
    [Fact]
    [Test]
    public void Should_Have_Error_When_MainCameraSpec_Exceeds_Max_Empty()
    {
        // Arrange
        var cameraObjectValue = new CameraObjectValue();
        cameraObjectValue.SetMainCameraSpec("");
        // Act
        var result = _validator.TestValidate(cameraObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MainCameraSpec)
            .WithErrorMessage("Main camera specification cannot be empty.");
    }
    
    [Fact]
    [Test]
    public void Should_Have_Error_When_MainCameraSpec_Exceeds_Max_Length()
    {
        // Arrange
        var cameraObjectValue = new CameraObjectValue();
        cameraObjectValue.SetMainCameraSpec("16 MP, Dual-lens");
        // Act
        var result = _validator.TestValidate(cameraObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MainCameraSpec)
            .WithErrorMessage("Main camera specification must have a maximum length of 15 characters.");
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_MainCameraFeature_Is_Valid()
    {
        // Arrange
        var cameraObjectValue = new CameraObjectValue();
        cameraObjectValue.SetMainCameraFeature("Auto-focus, LED flash");
        // Act
        var result = _validator.TestValidate(cameraObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.MainCameraFeature);
    }
    [Fact]
    [Test]
    public void Should_Have_Error_When_MainCameraFeature_Exceeds_Max_Empty()
    {
        // Arrange
        var cameraObjectValue = new CameraObjectValue();
        cameraObjectValue.SetMainCameraFeature(""); 
        // Act
        var result = _validator.TestValidate(cameraObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MainCameraFeature)
            .WithErrorMessage("Main camera feature cannot be empty.");
    }
    [Fact]
    [Test]
    public void Should_Have_Error_When_MainCameraFeature_Exceeds_Max_Length()
    {
        // Arrange
        var cameraObjectValue = new CameraObjectValue();
        cameraObjectValue.SetMainCameraFeature("Auto-focus, LED flash, Wide angle lorem ipsum dolor sit amet inter  magna"); 
        // Act
        var result = _validator.TestValidate(cameraObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MainCameraFeature)
            .WithErrorMessage("Main camera feature must have a maximum length of 50 characters.");
    }
    

    [Fact]
    [Test]
    public void Should_Have_Error_When_SelfieCameraSpec_Exceeds_Max_Length()
    {
        // Arrange
        var cameraObjectValue = new CameraObjectValue();
        cameraObjectValue.SetSelfieCameraSpec("8 MP, Wide angle");
        // Act
        var result = _validator.TestValidate(cameraObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.SelfieCameraSpec)
            .WithErrorMessage("Selfie camera specification must have a maximum length of 15 characters.");
    }
    
    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_SelfieCameraSpec_Is_Valid()
    {
        // Arrange
        var cameraObjectValue = new CameraObjectValue();
        cameraObjectValue.SetSelfieCameraSpec("8 MP");
        // Act
        var result = _validator.TestValidate(cameraObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.SelfieCameraSpec);
    }
    
    [Fact]
    [Test]
    public void Should_Have_Error_When_SelfieCameraSpec_Exceeds_Max_Empty()
    {
        // Arrange
        var cameraObjectValue = new CameraObjectValue();
        cameraObjectValue.SetSelfieCameraSpec("");
        // Act
        var result = _validator.TestValidate(cameraObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.SelfieCameraSpec)
            .WithErrorMessage("Selfie camera specification cannot be empty.");
    }
    
 
    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_SelfieCameraFeature_Is_Valid()
    {
        // Arrange
        var cameraObjectValue = new CameraObjectValue();
        cameraObjectValue.SetSelfieCameraFeature("Portrait mode");
        // Act
        var result = _validator.TestValidate(cameraObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.SelfieCameraFeature);
    }
    
    [Fact]
    [Test]
    public void Should_Have_Error_When_SelfieCameraFeature_Exceeds_Max_Empty()
    {
        // Arrange
        var cameraObjectValue = new CameraObjectValue();
        cameraObjectValue.SetSelfieCameraFeature("");
        // Act
        var result = _validator.TestValidate(cameraObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.SelfieCameraFeature)
            .WithErrorMessage("Selfie camera feature cannot be empty.");
    }
    
    [Fact]
    [Test]
    public void Should_Have_Error_When_SelfieCameraFeature_Exceeds_Max_Length()
    {
        var stringTest = new string('x', 101);
        // Arrange
        var cameraObjectValue = new CameraObjectValue();
        cameraObjectValue.SetSelfieCameraFeature(stringTest);
        // Act
        var result = _validator.TestValidate(cameraObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.SelfieCameraFeature)
            .WithErrorMessage("Selfie camera feature must have a maximum length of 100 characters.");
    }
}