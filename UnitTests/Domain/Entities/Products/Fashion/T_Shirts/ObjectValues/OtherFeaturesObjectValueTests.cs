using Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;
using Xunit;

namespace UnitTests.Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;

[TestFixture]
public class OtherFeaturesObjectValueTests
{
    private readonly OtherFeaturesObjectValueValidator _validator = new();

    [Fact]
    [Test]
    public void Composition_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var otherFeatures = new OtherFeaturesObjectValue();
        otherFeatures.SetComposition("");
        // Act
        var result = _validator.TestValidate(otherFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Composition)
            .WithErrorMessage("Composition cannot be empty.");
    }

    [Fact]
    [Test]
    public void Composition_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var otherFeatures = new OtherFeaturesObjectValue();
        otherFeatures.SetComposition(" ".PadRight(16, 'a'));
        // Act
        var result = _validator.TestValidate(otherFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Composition)
            .WithErrorMessage("Composition must have a maximum length of 15 characters.");
    }

    [Fact]
    [Test]
    public void MainMaterial_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var otherFeatures = new OtherFeaturesObjectValue();
        otherFeatures.SetMainMaterial("");
        // Act
        var result = _validator.TestValidate(otherFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MainMaterial)
            .WithErrorMessage("Main material cannot be empty.");
    }

    [Fact]
    [Test]
    public void MainMaterial_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var otherFeatures = new OtherFeaturesObjectValue();
        otherFeatures.SetMainMaterial(" ".PadRight(16, 'a'));
        // Act
        var result = _validator.TestValidate(otherFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MainMaterial)
            .WithErrorMessage("Main material must have a maximum length of 15 characters.");
    }

    [Fact]
    [Test]
    public void UnitsPerKit_WhenZero_ShouldHaveValidationError()
    {
        // Arrange
        var otherFeatures = new OtherFeaturesObjectValue();
        otherFeatures.SetUnitsPerKit(0);
        // Act
        var result = _validator.TestValidate(otherFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.UnitsPerKit)
            .WithErrorMessage("Units per kit must be greater than zero.");
    }

    [Fact]
    [Test]
    public void WithRecycledMaterials_ShouldNotHaveValidationError()
    {
        // Arrange
        var otherFeatures = new OtherFeaturesObjectValue();
        otherFeatures.SetWithRecycledMaterials(false);
        // Act
        var result = _validator.TestValidate(otherFeatures);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.WithRecycledMaterials);
    }

    [Fact]
    [Test]
    public void ItsSporty_ShouldNotHaveValidationError()  
    {
        // Arrange
        var otherFeatures = new OtherFeaturesObjectValue();
        otherFeatures.SetItsSporty(false);
        // Act
        var result = _validator.TestValidate(otherFeatures);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.ItsSporty);
    }
}