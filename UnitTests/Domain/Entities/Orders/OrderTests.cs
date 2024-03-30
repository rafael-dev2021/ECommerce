using Domain.Entities.Orders;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Orders;
using Xunit;

namespace UnitTests.Domain.Entities.Orders;

[TestFixture]
public class OrderTests
{
    private readonly OrderValidator _validator = new();

    [Fact]
    [Test]
    public void TotalOrder_WhenZero_ShouldHaveValidationError()
    {
        // Arrange
        var order = new Order();
        order.SetTotalOrder(0);
        // Act
        var result = _validator.TestValidate(order);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.TotalOrder)
            .WithErrorMessage("Total order must be greater than zero.");
    }

    [Fact]
    [Test]
    public void TotalOrder_WhenNegative_ShouldHaveValidationError()
    {
        // Arrange
        var order = new Order();
        order.SetTotalOrder(-1);
        // Act
        var result = _validator.TestValidate(order);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.TotalOrder)
            .WithErrorMessage("Total order must be greater than zero.");
    }

    [Fact]
    [Test]
    public void TotalOrder_WhenPositive_ShouldNotHaveValidationError()
    {
        // Arrange
        var order = new Order();
        order.SetTotalOrder(10.0m);
        // Act
        var result = _validator.TestValidate(order);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.TotalOrder);
    }

    [Fact]
    [Test]
    public void TotalItemsOrder_WhenZero_ShouldHaveValidationError()
    {
        // Arrange
        var order = new Order();
        order.SetTotalItemsOrder(0);
        // Act
        var result = _validator.TestValidate(order);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.TotalItemsOrder)
            .WithErrorMessage("Total items order must be greater than zero.");
    }

    [Fact]
    [Test]
    public void TotalItemsOrder_WhenNegative_ShouldHaveValidationError()
    {
        // Arrange
        var order = new Order();
        order.SetTotalItemsOrder(-1);
        // Act
        var result = _validator.TestValidate(order);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.TotalItemsOrder)
            .WithErrorMessage("Total items order must be greater than zero.");
    }

    [Fact]
    [Test]
    public void TotalItemsOrder_WhenPositive_ShouldNotHaveValidationError()
    {
        // Arrange
        var order = new Order();
        order.SetTotalItemsOrder(10);
        // Act
        var result = _validator.TestValidate(order);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.TotalItemsOrder);
    }

    [Fact]
    [Test]
    public void ConfirmedOrder_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var order = new Order();
        order.SetConfirmedOrder(default(DateTime));
        // Act
        var result = _validator.TestValidate(order);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ConfirmedOrder)
            .WithErrorMessage("Confirmed order date cannot be empty.");
    }

    [Fact]
    [Test]
    public void DispatchedOrder_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var order = new Order();
        order.SetDispatchedOrder(default(DateTime));
        // Act
        var result = _validator.TestValidate(order);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.DispatchedOrder)
            .WithErrorMessage("Dispatched order date cannot be empty.");
    }

    [Fact]
    [Test]
    public void RequestReceived_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var order = new Order();
        order.SetRequestReceived(default(DateTime));
        // Act
        var result = _validator.TestValidate(order);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.RequestReceived)
            .WithErrorMessage("Request received date cannot be empty.");
    }
}