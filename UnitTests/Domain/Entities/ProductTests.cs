using Domain.Entities;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities;
using Xunit;

namespace UnitTests.Domain.Entities;

[TestFixture]
public class ProductTests
{
    private readonly ProductValidator _validator = new();
    private static readonly string[] SourceArray1 = ["Image1.jpg", "Image2.jpg"];

    [Fact]
    [Test]
    public void Name_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var product = new Product(1, "", "description",
            [..SourceArray1], 1, 1);
        // Act 
        var result = _validator.TestValidate(product);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Name cannot be empty.");
    }

    [Fact]
    [Test]
    public void Name_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var product = new Product(1, "".PadRight(61, 'a'), "description",
            [..SourceArray1], 1, 1);
        // Act 
        var result = _validator.TestValidate(product);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Name cannot be more than 60 characters.");
    }


    [Fact]
    [Test]
    public void Description_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var product = new Product(1, "name", "",
            [..SourceArray1], 1, 1);
        // Act 
        var result = _validator.TestValidate(product);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Description)
            .WithErrorMessage("Description cannot be empty.");
    }

    [Fact]
    [Test]
    public void Description_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var product = new Product(1, "name", "".PadRight(10001, 'a'),
            [..SourceArray1], 1, 1);
        // Act 
        var result = _validator.TestValidate(product);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Description)
            .WithErrorMessage("Description cannot be more than 10000 characters.");
    }

    [Fact]
    [Test]
    public void ImagesUrl_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var product = new Product(1, "name", "description",
            [""], 1, 1);
        // Act 
        var result = _validator.TestValidate(product);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ImagesUrl[0])
            .WithErrorMessage("Images cannot be empty.");
    }

    [Fact]
    [Test]
    public void ImagesUrl_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var product = new Product(1, "name", "description",
            ["".PadRight(801, 'a')], 1, 1);
        // Act 
        var result = _validator.TestValidate(product);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ImagesUrl[0])
            .WithErrorMessage("Images cannot be more than 800 characters.");
    }
    
    [Fact]
    [Test]
    public void Stock_WhenZero_ShouldHaveValidationError()
    {
        // Arrange
        var product = new Product(1, "name", "description",
            [.. SourceArray1], 0, 1);
        // Act 
        var result = _validator.TestValidate(product);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Stock)
            .WithErrorMessage("Stock must be greater than zero.");
    }
}