using Domain.Entities.Payments;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Payments;
using Xunit;

namespace UnitTests.Domain.Entities.Payments;

[TestFixture]
public class CardTests
{
    private readonly CardValidator<Card> _validator = new();


    [Fact]
    [Test]
    public void CardNumber_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var card = new Card();
        card.SetCardNumber("");
        // Act
        var result = _validator.TestValidate(card);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CardNumber)
            .WithErrorMessage("Card number cannot be empty.");
    }

    [Fact]
    [Test]
    public void CardNumber_WhenTooLong_ShouldHaveValidationError()
    {
        // Arrange
        var card = new Card();
        card.SetCardNumber(" ".PadRight(20, 'a'));
        // Act
        var result = _validator.TestValidate(card);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CardNumber)
            .WithErrorMessage("Card Number must have a maximum length of 19 characters.");
    }

    [Fact]
    [Test]
    public void CardNumber_WhenNotDigits_ShouldHaveValidationError()
    {
        // Arrange
        var card = new Card();
        card.SetCardNumber("1223asd5wd1c1fsadc1sda");
        // Act
        var result = _validator.TestValidate(card);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CardNumber)
            .WithErrorMessage("Card number must be a 16-digit number.");
    }

    [Fact]
    [Test]
    public void CardHolderName_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var card = new Card();
        card.SetCardHolderName("");
        // Act
        var result = _validator.TestValidate(card);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CardHolderName)
            .WithErrorMessage("Card holder name cannot be empty.");
    }

    [Fact]
    [Test]
    public void CardHolderName_WhenTooLong_ShouldHaveValidationError()
    {
        // Arrange
        var card = new Card();
        card.SetCardHolderName(" ".PadRight(51, 'a'));
        // Act
        var result = _validator.TestValidate(card);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CardHolderName)
            .WithErrorMessage("Card holder name must have a maximum length of 50 characters.");
    }

    [Fact]
    [Test]
    public void CardExpirationDate_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var card = new Card();
        card.SetCardExpirationDate("");
        // Act
        var result = _validator.TestValidate(card);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CardExpirationDate)
            .WithErrorMessage("Card expiration date cannot be empty.");
    }

    [Fact]
    [Test]
    public void CardExpirationDate_WhenTooLong_ShouldHaveValidationError()
    {
        // Arrange
        var card = new Card();
        card.SetCardExpirationDate("123456");
        // Act
        var result = _validator.TestValidate(card);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CardExpirationDate)
            .WithErrorMessage("Card expiration Date must have a maximum length of 5 characters.");
    }

    [Fact]
    [Test]
    public void CardExpirationDate_WhenInvalidFormat_ShouldHaveValidationError()
    {
        // Arrange
        var card = new Card();
        card.SetCardExpirationDate("13/99");
        // Act
        var result = _validator.TestValidate(card);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CardExpirationDate)
            .WithErrorMessage("Invalid card expiration date format. Use MM/YY.");
    }

    [Fact]
    [Test]
    public void CardCvv_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var card = new Card();
        card.SetCardCvv("");
        // Act
        var result = _validator.TestValidate(card);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CardCvv)
            .WithErrorMessage("Card CVV cannot be empty.");
    }

    [Fact]
    [Test]
    public void CardCvv_WhenTooLong_ShouldHaveValidationError()
    {
        // Arrange
        var card = new Card();
        card.SetCardCvv("12345");
        // Act
        var result = _validator.TestValidate(card);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CardCvv)
            .WithErrorMessage("Card cvv must have a maximum length of 4 characters.");
    }

    [Fact]
    [Test]
    public void CardCvv_WhenNotDigits_ShouldHaveValidationError()
    {
        // Arrange
        var card = new Card();
        card.SetCardCvv("abc"); // Non-digits
        // Act
        var result = _validator.TestValidate(card);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.CardCvv)
            .WithErrorMessage("Card CVV must be a 3-digit number.");
    }

    [Fact]
    [Test]
    public void Ssn_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var card = new Card();
        card.SetSsn("");
        // Act
        var result = _validator.TestValidate(card);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Ssn)
            .WithErrorMessage("SSN cannot be empty.");
    }

    [Fact]
    [Test]
    public void Ssn_WhenTooLong_ShouldHaveValidationError()
    {
        // Arrange
        var card = new Card();
        card.SetSsn("123456789012"); // 12 characters
        // Act
        var result = _validator.TestValidate(card);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Ssn)
            .WithErrorMessage("Ssn must have a maximum length of 11 characters.");
    }

    [Fact]
    [Test]
    public void Ssn_WhenNotDigits_ShouldHaveValidationError()
    {
        // Arrange
        var card = new Card();
        card.SetSsn("123abc789"); // Non-digits
        // Act
        var result = _validator.TestValidate(card);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Ssn)
            .WithErrorMessage("SSN must be a 9-digit number.");
    }
}