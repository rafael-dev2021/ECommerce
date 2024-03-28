using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;
using Xunit;

namespace UnitTests.Domain.Entities.ObjectValues.ProductObjectValue;

/// <summary>
/// Unit tests for the <see cref="PriceObjectValueValidator"/> class.
/// </summary>
public class PriceObjectValueTests
{
    /// <summary>
    /// The instance of the <see cref="PriceObjectValueValidator"/> class under test.
    /// </summary>
    private readonly PriceObjectValueValidator _validator = new();

    /// <summary>
    /// Tests that the validator does not have any errors when the price is greater than zero and the history price is greater than or equal to zero.
    /// </summary>
    [Fact]
    public void Should_Not_Have_Error_When_Price_Is_Greater_Than_Zero_And_HistoryPrice_Is_Greater_Than_Or_Equal_To_Zero()
    {
        // Arrange
        var priceObjectValue = new PriceObjectValue();
        priceObjectValue.SetPrice(10.0m);
        priceObjectValue.SetHistoryPrice(0.0m);

        // Act
        var result = _validator.TestValidate(priceObjectValue);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Price);
        result.ShouldNotHaveValidationErrorFor(x => x.HistoryPrice);
    }

    /// <summary>
    /// Tests that the validator has an error when the price is not greater than zero.
    /// </summary>
    [Fact]
    public void Should_Have_Error_When_Price_Is_Not_Greater_Than_Zero()
    {
        // Arrange
        var priceObjectValue = new PriceObjectValue();
        priceObjectValue.SetPrice(0.0m);
        priceObjectValue.SetHistoryPrice(5.0m);

        // Act
        var result = _validator.TestValidate(priceObjectValue);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Price)
            .WithErrorMessage("Price must be greater than zero.");
    }

    /// <summary>
    /// Tests that the validator has an error when the price is less than zero.
    /// </summary>
    [Fact]
    public void Should_Have_Error_When_Price_Is_Less_Than_Zero()
    {
        // Arrange
        var priceObjectValue = new PriceObjectValue();
        priceObjectValue.SetPrice(-10.0m);
        priceObjectValue.SetHistoryPrice(5.0m);

        // Act
        var result = _validator.TestValidate(priceObjectValue);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Price)
            .WithErrorMessage("Price must be greater than zero.");
    }

    /// <summary>
    /// Tests that the validator has an error when the history price is less than zero.
    /// </summary>
    [Fact]
    public void Should_Have_Error_When_HistoryPrice_Is_Less_Than_Zero()
    {
        // Arrange
        var priceObjectValue = new PriceObjectValue();
        priceObjectValue.SetPrice(10.0m);
        priceObjectValue.SetHistoryPrice(-5.0m);

        // Act
        var result = _validator.TestValidate(priceObjectValue);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.HistoryPrice)
            .WithErrorMessage("History price must be greater than or equal to zero.");
    }
}