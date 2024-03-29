using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;
using Xunit;

namespace UnitTests.Domain.Entities.ObjectValues.ProductObjectValue;

[TestFixture]
public class DataObjectValueTests
{
    private readonly DataObjectValueValidator _validator = new();

    [Fact]
    [Test]
    public void Should_Have_Error_When_ReleaseMonth_Is_Empty()
    {
        // Arrange
        var dataObjectValue = new DataObjectValue();
        // Act
        var result = _validator.TestValidate(dataObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ReleaseMonth)
            .WithErrorMessage("Release month can't be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_ReleaseMonth_Length_Is_Too_Long()
    {
        // Arrange
        var dataObjectValue = new DataObjectValue();
        dataObjectValue.SetReleaseMonth("ThisIsALongMonthName");
        // Act
        var result = _validator.TestValidate(dataObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ReleaseMonth)
            .WithErrorMessage("Release Month maximum 9 characters.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_ReleaseYear_Is_Empty()
    {
        // Arrange
        var dataObjectValue = new DataObjectValue();
        // Act
        var result = _validator.TestValidate(dataObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ReleaseYear)
            .WithErrorMessage("Release Year is required.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_ReleaseYear_Is_Not_Four_Digits()
    {
        // Arrange
        var dataObjectValue = new DataObjectValue();
        dataObjectValue.SetReleaseYear(12345);
        // Act
        var result = _validator.TestValidate(dataObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ReleaseYear)
            .WithErrorMessage("Must be a 4-digit positive integer.");
    }
}