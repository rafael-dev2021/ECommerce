using Domain.Entities.Cart;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Cart;
using Xunit;

namespace UnitTests.Domain.Entities.Cart;

[TestFixture]

public class ShoppingCartItemTests
{
    private readonly ShoppingCartItemValidator _validator = new();
    
    [Fact]
    [Test]
    public void Quantity_WhenZero_ShouldHaveValidationError()
    {
        // Arrange
        var shoppingCartItem = new ShoppingCartItem();
            shoppingCartItem.SetQuantity(0);
        // Act
        var result = _validator.TestValidate(shoppingCartItem);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Quantity)
            .WithErrorMessage("Quantity must be greater than zero.");
    }

    [Fact]
    [Test]
    public void Quantity_WhenNegative_ShouldHaveValidationError()
    {
        // Arrange
        var shoppingCartItem = new ShoppingCartItem();
        shoppingCartItem.SetQuantity(-1);
        // Act
        var result = _validator.TestValidate(shoppingCartItem);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Quantity)
            .WithErrorMessage("Quantity must be greater than zero.");
    }

    [Fact]
    [Test]
    public void Quantity_WhenPositive_ShouldNotHaveValidationError()
    {
        // Arrange
        var shoppingCartItem = new ShoppingCartItem();
        shoppingCartItem.SetQuantity(1);
        // Act
        var result = _validator.TestValidate(shoppingCartItem);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Quantity);
    }
}