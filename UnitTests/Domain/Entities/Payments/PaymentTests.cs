using Domain.Entities.Payments;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Payments;
using Xunit;

namespace UnitTests.Domain.Entities.Payments;

public class PaymentMethodTests
{
    private readonly PaymentMethodValidator<PaymentMethod> _methodValidator = new();
 
    [Fact]
    [Test]
    public void Ssn_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var payment = new PaymentMethod();
        payment.SetSsn("");
        // Act
        var result = _methodValidator.TestValidate(payment);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Ssn)
            .WithErrorMessage("SSN cannot be empty.");
    }

    [Fact]
    [Test]
    public void Ssn_WhenTooLong_ShouldHaveValidationError()
    {
        // Arrange
        var payment = new PaymentMethod();
        payment.SetSsn("123456789012"); // 12 characters
        // Act
        var result = _methodValidator.TestValidate(payment);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Ssn)
            .WithErrorMessage("SSN must have a maximum length of 11 characters.");
    }

    [Fact]
    [Test]
    public void Ssn_WhenNotDigits_ShouldHaveValidationError()
    {
        // Arrange
        var payment = new PaymentMethod();
        payment.SetSsn("123abc789"); // Non-digits
        // Act
        var result = _methodValidator.TestValidate(payment);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Ssn)
            .WithErrorMessage("SSN must be a 9-digit number.");
    }

    [Fact]
    [Test]
    public void Amount_WhenZero_ShouldHaveValidationError()
    {
        // Arrange
        var payment = new PaymentMethod();
        payment.SetAmount(0);
        // Act
        var result = _methodValidator.TestValidate(payment);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Amount)
            .WithErrorMessage("Amount must be greater than zero.");
    }

    [Fact]
    [Test]
    public void Amount_WhenNegative_ShouldHaveValidationError()
    {
        // Arrange
        var payment = new PaymentMethod();
        payment.SetAmount(-10);
        // Act
        var result = _methodValidator.TestValidate(payment);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Amount)
            .WithErrorMessage("Amount must be greater than zero.");
    }
}