using Domain.Entities;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities;
using Xunit;

namespace UnitTests.Domain.Entities;

[TestFixture]
public class CategoryTests
{
    private readonly CategoryValidator _validator = new();

    [Fact]
    [Test]
    public void Name_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var category = new Category(1, "", "url", true);
        // Act 
        var result = _validator.TestValidate(category);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Name cannot be empty.");
    }

    [Fact]
    [Test]
    public void Name_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var category = new Category(1, "".PadRight(51, 'a'), "url", true);
        // Act 
        var result = _validator.TestValidate(category);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Name cannot be more than 50 characters.");
    }

    [Fact]
    [Test]
    public void ImagesUrl_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var category = new Category(1, "category", "", true);
        // Act 
        var result = _validator.TestValidate(category);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ImageUrl)
            .WithErrorMessage("Image url cannot be empty.");
    }

    [Fact]
    [Test]
    public void ImagesUrl_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var category = new Category(1, "category", "".PadRight(501, 'a'), true);
        // Act 
        var result = _validator.TestValidate(category);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ImageUrl)
            .WithErrorMessage("Image url cannot be more than 500 characters.");
    }


    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_IsActive_Is_True()
    {
        // Arrange
        var category = new Category(1, "category",
            "url", true);
        // Act 
        var result = _validator.TestValidate(category);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.IsActive)
            .WithErrorMessage("The category cannot be active.");
    }
}