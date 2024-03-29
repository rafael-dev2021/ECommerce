using Domain.Entities.Products.Fashion.Shoes.ObjectValues;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Products.Fashion.Shoes.ObjectValues;
using Xunit;

namespace UnitTests.Domain.Entities.Products.Fashion.Shoes.ObjectValues;

[TestFixture]
public class MaterialObjectValueTests
{
    private readonly MaterialObjectValueValidator _validator = new();

    [Fact]
    [Test]
    public void MaterialsFromAbroad_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var material = new MaterialObjectValue();
        material.SetMaterialsFromAbroad("");
        // Act
        var result = _validator.TestValidate(material);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MaterialsFromAbroad)
            .WithErrorMessage("Materials from abroad cannot be empty.");
    }

    [Fact]
    [Test]
    public void MaterialsFromAbroad_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var material = new MaterialObjectValue();
        material.SetMaterialsFromAbroad(" ".PadRight(11, 'a'));
        // Act
        var result = _validator.TestValidate(material);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MaterialsFromAbroad)
            .WithErrorMessage("Materials from abroad must have a maximum length of 10 characters.");
    }

    [Fact]
    [Test]
    public void InteriorMaterials_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var material = new MaterialObjectValue();
        material.SetInteriorMaterials("");
        // Act
        var result = _validator.TestValidate(material);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.InteriorMaterials)
            .WithErrorMessage("Interior materials cannot be empty.");
    }

    [Fact]
    [Test]
    public void InteriorMaterials_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var material = new MaterialObjectValue();
        material.SetInteriorMaterials(" ".PadRight(11, 'a'));
        // Act
        var result = _validator.TestValidate(material);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.InteriorMaterials)
            .WithErrorMessage("Interior materials must have a maximum length of 10 characters.");
    }

    [Fact]
    [Test]
    public void SoleMaterials_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var material = new MaterialObjectValue();
        material.SetSoleMaterials("");
        // Act
        var result = _validator.TestValidate(material);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.SoleMaterials)
            .WithErrorMessage("Sole materials cannot be empty.");
    }

    [Fact]
    [Test]
    public void SoleMaterials_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var material = new MaterialObjectValue();
        material.SetSoleMaterials(" ".PadRight(11, 'a'));
        // Act
        var result = _validator.TestValidate(material);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.SoleMaterials)
            .WithErrorMessage("Sole materials must have a maximum length of 10 characters.");
    }

    [Fact]
    [Test]
    public void AllProperties_WithinValidLength_ShouldNotHaveValidationError()
    {
        // Arrange
        var material = new MaterialObjectValue();
        material.SetMaterialsFromAbroad("Leather");
        material.SetInteriorMaterials("Fabric");
        material.SetSoleMaterials("Rubber");
        // Act
        var result = _validator.TestValidate(material);
        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}