using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;
using Xunit;

namespace UnitTests.Domain.Entities.ObjectValues.ProductObjectValue;

 [TestFixture]
public class FlagsObjectValueTests
{
    private readonly FlagsObjectValueValidator _validator = new();

    [Fact]
    [Test]
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
    
    [Fact]
    [Test]
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

    [Fact]
    [Test]
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

    [Fact]
    [Test]
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