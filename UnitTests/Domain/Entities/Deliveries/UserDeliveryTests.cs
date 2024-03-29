using Domain.Entities.Deliveries;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Deliveries;
using Xunit;

namespace UnitTests.Domain.Entities.Deliveries;

[TestFixture]
public class UserDeliveryTests
{
    private readonly UserDeliveryValidator _validator = new();

    [Fact]
    [Test]
    public void FirstName_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var userDelivery = new UserDelivery();
        userDelivery.SetFirstName("");
        // Act
        var result = _validator.TestValidate(userDelivery);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.FirstName)
            .WithErrorMessage("First name cannot be empty.");
    }

    [Fact]
    [Test]
    public void FirstName_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var userDelivery = new UserDelivery();
        userDelivery.SetFirstName(" ".PadRight(16, 'A'));
        // Act
        var result = _validator.TestValidate(userDelivery);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.FirstName)
            .WithErrorMessage("First name must have a maximum length of 15 characters.");
    }

    [Fact]
    [Test]
    public void LastName_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var userDelivery = new UserDelivery();
        userDelivery.SetLastName("");
        // Act
        var result = _validator.TestValidate(userDelivery);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.LastName)
            .WithErrorMessage("Last name cannot be empty.");
    }

    [Fact]
    [Test]
    public void LastName_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var userDelivery = new UserDelivery();
        userDelivery.SetLastName(" ".PadRight(16, 'A'));
        // Act
        var result = _validator.TestValidate(userDelivery);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.LastName)
            .WithErrorMessage("Last name must have a maximum length of 15 characters.");
    }

    [Fact]
    [Test]
    public void Email_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var userDelivery = new UserDelivery();
        userDelivery.SetEmail("");
        // Act
        var result = _validator.TestValidate(userDelivery);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage("Email cannot be empty.");
    }

    [Fact]
    [Test]
    public void Email_WhenInvalidFormat_ShouldHaveValidationError()
    {
        // Arrange
        var userDelivery = new UserDelivery();
        userDelivery.SetEmail("invalid-email");
        // Act
        var result = _validator.TestValidate(userDelivery);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage("Invalid email address format.");
    }

    [Fact]
    [Test]
    public void Email_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var userDelivery = new UserDelivery();
        userDelivery.SetEmail(" ".PadRight(51, 'a'));
        // Act
        var result = _validator.TestValidate(userDelivery);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage("Email must have a maximum length of 50 characters.");
    }

    [Fact]
    [Test]
    public void Phone_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var userDelivery = new UserDelivery();
        userDelivery.SetPhone("");
        // Act
        var result = _validator.TestValidate(userDelivery);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Phone)
            .WithErrorMessage("Phone cannot be empty.");
    }

    [Fact]
    [Test]
    public void Phone_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var userDelivery = new UserDelivery();
        userDelivery.SetPhone(" ".PadRight(17, 'A'));
        // Act
        var result = _validator.TestValidate(userDelivery);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Phone)
            .WithErrorMessage("Phone must have a maximum length of 16 characters.");
    }

    [Fact]
    [Test]
    public void Ssn_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var userDelivery = new UserDelivery();
        userDelivery.SetSsn("");
        // Act
        var result = _validator.TestValidate(userDelivery);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Ssn)
            .WithErrorMessage("SSN cannot be empty.");
    }

    [Fact]
    [Test]
    public void Ssn_WhenInvalidFormat_ShouldHaveValidationError()
    {
        // Arrange
        var userDelivery = new UserDelivery();
        userDelivery.SetSsn("123-45-67891");
        // Act
        var result = _validator.TestValidate(userDelivery);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Ssn)
            .WithErrorMessage("SSN must be a 9-digit number.");
    }

    [Fact]
    [Test]
    public void Ssn_WhenExceedsMaxLength_ShouldHaveValidationError()
    {
        // Arrange
        var userDelivery = new UserDelivery();
        userDelivery.SetSsn(new string('1', 17));
        // Act
        var result = _validator.TestValidate(userDelivery);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Ssn)
            .WithErrorMessage("Ssn must have a maximum length of 11 characters.");
    }
}