using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;
using Xunit;

namespace UnitTests.Domain.Entities.Products.Fashion;

[TestFixture]
public class CommonPropertiesObjectValueTests
{
    private readonly CommonPropertiesValidator _validator = new();

    [Fact]
    [Test]
    public void Gender_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var commonProperties = new CommonPropertiesObjectValue();
        commonProperties.SetGender("");
        // Act
        var result = _validator.TestValidate(commonProperties);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Gender)
            .WithErrorMessage("Gender cannot be empty.");
    }

    [Fact]
    [Test]
    public void Gender_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var commonProperties = new CommonPropertiesObjectValue();
        commonProperties.SetGender(" ".PadRight(11, 'a'));
        // Act
        var result = _validator.TestValidate(commonProperties);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Gender)
            .WithErrorMessage("Gender must have a maximum length of 10 characters.");
    }

    [Fact]
    [Test]
    public void Color_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var commonProperties = new CommonPropertiesObjectValue();
        commonProperties.SetColor("");
        // Act
        var result = _validator.TestValidate(commonProperties);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Color)
            .WithErrorMessage("Color cannot be empty.");
    }

    [Fact]
    [Test]
    public void Color_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var commonProperties = new CommonPropertiesObjectValue();
        commonProperties.SetColor(" ".PadRight(21, 'a'));
        // Act
        var result = _validator.TestValidate(commonProperties);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Color)
            .WithErrorMessage("Color must have a maximum length of 20 characters.");
    }

    [Fact]
    [Test]
    public void Age_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var commonProperties = new CommonPropertiesObjectValue();
        commonProperties.SetAge("");
        // Act
        var result = _validator.TestValidate(commonProperties);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Age)
            .WithErrorMessage("Age cannot be empty.");
    }

    [Fact]
    [Test]
    public void Age_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var commonProperties = new CommonPropertiesObjectValue();
        commonProperties.SetAge(" ".PadRight(11, 'a'));
        // Act
        var result = _validator.TestValidate(commonProperties);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Age)
            .WithErrorMessage("Age must have a maximum length of 10 characters.");
    }

    [Fact]
    [Test]
    public void RecommendedUses_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var commonProperties = new CommonPropertiesObjectValue();
        commonProperties.SetRecommendedUses("");
        // Act
        var result = _validator.TestValidate(commonProperties);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.RecommendedUses)
            .WithErrorMessage("Recommended uses cannot be empty.");
    }

    [Fact]
    [Test]
    public void RecommendedUses_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var commonProperties = new CommonPropertiesObjectValue();
        commonProperties.SetRecommendedUses(" ".PadRight(16, 'a'));
        // Act
        var result = _validator.TestValidate(commonProperties);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.RecommendedUses)
            .WithErrorMessage("Recommended uses must have a maximum length of 15 characters.");
    }

    [Fact]
    [Test]
    public void Size_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var commonProperties = new CommonPropertiesObjectValue();
        commonProperties.SetSize("");
        // Act
        var result = _validator.TestValidate(commonProperties);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Size)
            .WithErrorMessage("Size cannot be empty.");
    }

    [Fact]
    [Test]
    public void Size_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var commonProperties = new CommonPropertiesObjectValue();
        commonProperties.SetSize(" ".PadRight(11, 'a'));
        // Act
        var result = _validator.TestValidate(commonProperties);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Size)
            .WithErrorMessage("Size must have a maximum length of 10 characters.");
    }
}