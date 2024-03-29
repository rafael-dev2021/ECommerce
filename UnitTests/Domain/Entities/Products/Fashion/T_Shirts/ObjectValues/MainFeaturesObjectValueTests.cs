using Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;

namespace UnitTests.Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;

[TestFixture]
public class MainFeaturesObjectValueTests
{
    private readonly MainFeaturesObjectValueValidator _validator = new();

    [Test]
    public void TypeOfClothing_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var mainFeatures = new MainFeaturesObjectValue();
        mainFeatures.SetTypeOfClothing("");
        // Act
        var result = _validator.TestValidate(mainFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.TypeOfClothing)
            .WithErrorMessage("Type of clothing cannot be empty.");
    }

    [Test]
    public void TypeOfClothing_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var mainFeatures = new MainFeaturesObjectValue();
        mainFeatures.SetTypeOfClothing(" ".PadRight(16, 'a'));
        // Act
        var result = _validator.TestValidate(mainFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.TypeOfClothing)
            .WithErrorMessage("Type of clothing must have a maximum length of 15 characters.");
    }

    [Test]
    public void FabricDesign_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var mainFeatures = new MainFeaturesObjectValue();
        mainFeatures.SetFabricDesign("");
        // Act
        var result = _validator.TestValidate(mainFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.FabricDesign)
            .WithErrorMessage("Fabric design cannot be empty.");
    }

    [Test]
    public void FabricDesign_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var mainFeatures = new MainFeaturesObjectValue();
        mainFeatures.SetFabricDesign(" ".PadRight(16,'a'));
        // Act
        var result = _validator.TestValidate(mainFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.FabricDesign)
            .WithErrorMessage("Fabric design must have a maximum length of 15 characters.");
    }

    [Test]
    public void AllProperties_WithinValidLength_ShouldNotHaveValidationError()
    {
        // Arrange
        var mainFeatures = new MainFeaturesObjectValue();
        mainFeatures.SetTypeOfClothing("T-Shirt");
        mainFeatures.SetFabricDesign("Cotton");
        // Act
        var result = _validator.TestValidate(mainFeatures);
        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}