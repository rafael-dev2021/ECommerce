using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;
using Xunit;

namespace UnitTests.Domain.Entities.ObjectValues.ProductObjectValue;

/// <summary>
/// Unit tests for the <see cref="FlagsObjectValue"/> class and its validations.
/// </summary>
public class FlagsObjectValueTests
{
    /// <summary>
    /// A validator for the <see cref="FlagsObjectValue"/> class.
    /// </summary>
    private readonly FlagsObjectValueValidator _validator = new();

    /// <summary>
    /// Tests that the validator does not have any validation errors when IsFavorite is false and IsDailyOffer is false.
    /// </summary>
    [Fact]
    public void Should_Not_Have_Error_When_IsFavorite_Is_False_And_IsDailyOffer_Is_False()
    {
        // Arrange
        var flagsObjectValue = new FlagsObjectValue();
        flagsObjectValue.SetIsDailyOffer(false);
        flagsObjectValue.SetIsBestSeller(false);
        // Act
        var result = _validator.TestValidate(flagsObjectValue);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.IsFavorite);
    }

    /// <summary>
    /// Tests that the validator has a validation error when IsFavorite is true and IsDailyOffer is true.
    /// </summary>
    [Fact]
    public void Should_Have_Error_When_IsFavorite_Is_True_And_IsDailyOffer_Is_True()
    {
        // Arrange
        var flagsObjectValue = new FlagsObjectValue();
        flagsObjectValue.SetIsFavorite(true);
        flagsObjectValue.SetIsDailyOffer(true);

        // Act
        var result = _validator.TestValidate(flagsObjectValue);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.IsFavorite)
            .WithErrorMessage("Cannot be favorite and daily offer at the same time.");
    }

    /// <summary>
    /// Tests that the validator does not have any validation errors when IsBestSeller is false and IsDailyOffer is false.
    /// </summary>
    [Fact]
    public void Should_Not_Have_Error_When_IsBestSeller_Is_False_And_IsDailyOffer_Is_False()
    {
        // Arrange
        var flagsObjectValue = new FlagsObjectValue();
        flagsObjectValue.SetIsBestSeller(false);
        flagsObjectValue.SetIsDailyOffer(false);

        // Act
        var result = _validator.TestValidate(flagsObjectValue);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.IsBestSeller);
    }

    /// <summary>
    /// Tests that the validator has a validation error when IsBestSeller is true and IsDailyOffer is true.
    /// </summary>
    [Fact]
    public void Should_Have_Error_When_IsBestSeller_Is_True_And_IsDailyOffer_Is_True()
    {
        // Arrange
        var flagsObjectValue = new FlagsObjectValue();
        flagsObjectValue.SetIsBestSeller(true);
        flagsObjectValue.SetIsDailyOffer(true);

        // Act
        var result = _validator.TestValidate(flagsObjectValue);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.IsBestSeller)
            .WithErrorMessage("Cannot be best seller and daily offer at the same time.");
    }
}