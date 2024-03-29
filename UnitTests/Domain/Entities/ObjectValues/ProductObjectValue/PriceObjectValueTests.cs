using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;
using Xunit;

namespace UnitTests.Domain.Entities.ObjectValues.ProductObjectValue;

[TestFixture]
public class PriceObjectValueTests
{
    private readonly PriceObjectValueValidator _validator = new();

    [Fact]
    [Test]
    public void
        Should_Not_Have_Error_When_Price_Is_Greater_Than_Zero_And_HistoryPrice_Is_Greater_Than_Or_Equal_To_Zero()
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

    [Fact]
    [Test]
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

    [Fact]
    [Test]
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

    [Fact]
    [Test]
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