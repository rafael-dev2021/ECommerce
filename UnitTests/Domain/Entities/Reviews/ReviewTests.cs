using Domain.Entities.Reviews;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Reviews;
using Xunit;

namespace UnitTests.Domain.Entities.Reviews;

[TestFixture]
public class ReviewTests
{
    private readonly ReviewValidator _validator = new();

    [Fact]
    [Test]
    public void Comment_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var review = new Review();
        review.SetComment("");
        // Act
        var result = _validator.TestValidate(review);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Comment)
            .WithErrorMessage("Comment cannot be empty.");
    }

    [Fact]
    [Test]
    public void Comment_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var review = new Review();
        review.SetComment(" ".PadRight(2001, 'a'));
        // Act
        var result = _validator.TestValidate(review);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Comment)
            .WithErrorMessage("Comment cannot be more than 2000 characters.");
    }

    [Fact]
    [Test]
    public void Image_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var review = new Review();
        review.SetImage(" ".PadRight(251, 'a'));
        // Act
        var result = _validator.TestValidate(review);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Image)
            .WithErrorMessage("Image cannot be more than 250 characters.");
    }

    [Fact]
    [Test]
    public void Rating_OutsideRange_ShouldHaveValidationError()
    {
        // Arrange
        var review = new Review();
        review.SetRating(6);
        // Act
        var result = _validator.TestValidate(review);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Rating)
            .WithErrorMessage("Rating must be between 1 and 5.");
    }
}