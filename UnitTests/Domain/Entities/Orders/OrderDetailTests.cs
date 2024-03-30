using Domain.Entities.Orders;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Orders;
using Xunit;

namespace UnitTests.Domain.Entities.Orders;

[TestFixture]
public class OrderDetailTests
{
    private readonly OrderDetailValidator _validator = new();

    [Fact]
    [Test]
    public void Quantity_WhenZero_ShouldHaveValidationError()
    {
        // Arrange
        var orderDetail = new OrderDetail();
        orderDetail.SetQuantity(0);
        // Act
        var result = _validator.TestValidate(orderDetail);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Quantity)
            .WithErrorMessage("Quantity must be greater than zero.");
    }

    [Fact]
    [Test]
    public void Quantity_WhenNegative_ShouldHaveValidationError()
    {
        // Arrange
        var orderDetail = new OrderDetail();
        orderDetail.SetQuantity(-1);
        // Act
        var result = _validator.TestValidate(orderDetail);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Quantity)
            .WithErrorMessage("Quantity must be greater than zero.");
    }

    [Fact]
    [Test]
    public void Quantity_WhenPositive_ShouldNotHaveValidationError()
    {
        // Arrange
        var orderDetail = new OrderDetail();
        orderDetail.SetQuantity(1);
        // Act
        var result = _validator.TestValidate(orderDetail);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Quantity);
    }

    [Fact]
    [Test]
    public void Price_WhenZero_ShouldHaveValidationError()
    {
        // Arrange
        var orderDetail = new OrderDetail();
        orderDetail.SetPrice(0);
        // Act
        var result = _validator.TestValidate(orderDetail);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Price)
            .WithErrorMessage("Price must be greater than zero.");
    }

    [Fact]
    [Test]
    public void Price_WhenNegative_ShouldHaveValidationError()
    {
        // Arrange
        var orderDetail = new OrderDetail();
        orderDetail.SetPrice(-1);
        // Act
        var result = _validator.TestValidate(orderDetail);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Price)
            .WithErrorMessage("Price must be greater than zero.");
    }

    [Fact]
    [Test]
    public void Price_WhenPositive_ShouldNotHaveValidationError()
    {
        // Arrange
        var orderDetail = new OrderDetail();
        orderDetail.SetPrice(10);
        // Act
        var result = _validator.TestValidate(orderDetail);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Price);
    }
}