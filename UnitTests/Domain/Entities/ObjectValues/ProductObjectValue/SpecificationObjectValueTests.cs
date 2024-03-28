using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;
using Xunit;

namespace UnitTests.Domain.Entities.ObjectValues.ProductObjectValue;

/// <summary>
/// This class contains unit tests for the SpecificationObjectValue class.
/// </summary>
public class SpecificationObjectValueTests
{
    /// <summary>
    /// Private field to hold a string with a specific length for testing purposes.
    /// </summary>
    private readonly string _stringTest21 = new('x', 21);

    /// <summary>
    /// Private field to hold an instance of the SpecificationObjectValueValidator class.
    /// </summary>
    private readonly SpecificationObjectValueValidator _validator = new();

    /// <summary>
    /// Tests that the model property should have an error when empty.
    /// </summary>
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

    /// <summary>
    /// Tests that the model property should not have an error when valid.
    /// </summary>
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

    /// <summary>
    /// Tests that the model property should have an error when more than 50 characters.
    /// </summary>
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

    /// <summary>
    /// Tests that the brand property should have an error when empty.
    /// </summary>
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

    /// <summary>
    /// Tests that the brand property should not have an error when valid.
    /// </summary>
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

    /// <summary>
    /// Tests that the brand property should have an error when more than 20 characters.
    /// </summary>
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

    /// <summary>
    /// Tests that the line property should have an error when empty.
    /// </summary>
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

    /// <summary>
    /// Tests that the line property should not have an error when valid.
    /// </summary>
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

    /// <summary>
    /// Tests that the line property should have an error when more than 20 characters.
    /// </summary>
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

    /// <summary>
    /// Tests that the weight property should have an error when empty.
    /// </summary>
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

    /// <summary>
    /// Tests that the weight property should not have an error when valid.
    /// </summary>
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

    /// <summary>
    /// Tests that the weight property should have an error when more than 20 characters.
    /// </summary>
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

    /// <summary>
    /// Tests that the type property should have an error when empty.
    /// </summary>
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

    
    /// <summary>
    /// Tests that the type property should not have an error when valid.
    /// </summary>
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

    
    /// <summary>
    /// Tests that the type property should have an error when more than 20 characters.
    /// </summary>
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