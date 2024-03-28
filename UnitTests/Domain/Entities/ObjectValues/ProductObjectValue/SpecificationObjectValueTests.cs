using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;
using Xunit;

namespace UnitTests.Domain.Entities.ObjectValues.ProductObjectValue;

public class SpecificationObjectValueTests
{
    private readonly string _stringTest21 = new('x', 21);

    private readonly SpecificationObjectValueValidator _validator = new();

    [Fact]
    public void Model_Should_Have_Error_When_Empty()
    {
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetModel("");

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Model)
            .WithErrorMessage("Model cannot be empty.");
    }

    [Fact]
    public void Model_Should_Not_Have_Error_When_Valid()
    {
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetModel("Valid Model");

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Model);
    }

    [Fact]
    public void Model_Should_Have_Error_When_more_50_characters()
    {
        var stringTest = new string('x', 51);
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetModel(stringTest);

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Model)
            .WithErrorMessage("Model must have a maximum length of 50 characters.");
    }

    [Fact]
    public void Brand_Should_Have_Error_When_Empty()
    {
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetBrand("");

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Brand)
            .WithErrorMessage("Brand cannot be empty.");
    }

    [Fact]
    public void Brand_Should_Not_Have_Error_When_Valid()
    {
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetBrand("Valid Brand");

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Brand);
    }

    [Fact]
    public void Brand_Should_Have_Error_When_more_20_characters()
    {
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetBrand(_stringTest21);

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Brand)
            .WithErrorMessage("Brand must have a maximum length of 20 characters.");
    }

    [Fact]
    public void Line_Should_Have_Error_When_Empty()
    {
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetLine("");

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Line)
            .WithErrorMessage("Line cannot be empty.");
    }

    [Fact]
    public void Line_Should_Not_Have_Error_When_Valid()
    {
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetLine("Valid Line");

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Line);
    }

    [Fact]
    public void Line_Should_Have_Error_When_more_20_characters()
    {
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetLine(_stringTest21);

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Line)
            .WithErrorMessage("Line must have a maximum length of 20 characters.");
    }
    
    [Fact]
    public void Weight_Should_Have_Error_When_Empty()
    {
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetWeight("");

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Weight)
            .WithErrorMessage("Weight cannot be empty.");
    }

    [Fact]
    public void Weight_Should_Not_Have_Error_When_Valid()
    {
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetWeight("Weight Line");

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Weight);
    }

    [Fact]
    public void Weight_Should_Have_Error_When_more_20_characters()
    {
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetWeight(_stringTest21);

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Weight)
            .WithErrorMessage("Weight must have a maximum length of 20 characters.");
    }
    
    [Fact]
    public void Type_Should_Have_Error_When_Empty()
    {
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetType("");

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Type)
            .WithErrorMessage("Type cannot be empty.");
    }

    [Fact]
    public void Type_Should_Not_Have_Error_When_Valid()
    {
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetType("Type Line");

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Type);
    }

    [Fact]
    public void Type_Should_Have_Error_When_more_20_characters()
    {
        // Arrange
        var specification = new SpecificationObjectValue();
        specification.SetType(_stringTest21);

        // Act
        var result = _validator.TestValidate(specification);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Type)
            .WithErrorMessage("Type must have a maximum length of 20 characters.");
    }
}