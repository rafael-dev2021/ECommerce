using Application.Dtos.PaymentsDto;
using Application.Mappings;
using AutoMapper;
using Domain.Entities.Payments;
using FluentAssertions;
using Xunit;

namespace UnitTests.Application.Mappings;

public class MappingThePaymentProfileTests
{
    private readonly IMapper _mapper;

    public MappingThePaymentProfileTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingThePaymentProfile>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Should_Map_Card_To_CardDto()
    {
        // Arrange
        var card = new Card();
        card.SetId(Guid.NewGuid());
        card.SetCardNumber("1234567890123456");
        card.SetCardHolderName("John Doe");
        card.SetCardExpirationDate("12/24");
        card.SetCardCvv("123");
        card.SetSsn("111-22-3333");

        // Act
        var cardDto = _mapper.Map<CardDto>(card);

        // Assert
        cardDto.Id.Should().Be(card.Id);
        cardDto.CardNumber.Should().Be(card.CardNumber);
        cardDto.CardHolderName.Should().Be(card.CardHolderName);
        cardDto.CardExpirationDate.Should().Be(card.CardExpirationDate);
        cardDto.CardCvv.Should().Be(card.CardCvv);
        cardDto.Ssn.Should().Be(card.Ssn);
    }

    [Fact]
    public void Should_Map_CardDto_To_Card()
    {
        // Arrange
        var cardDto = new CardDto
        {
            Id = Guid.NewGuid(),
            CardNumber = "1234567890123456",
            CardHolderName = "John Doe",
            CardExpirationDate = "12/24",
            CardCvv = "123",
            Ssn = "111-22-3333"
        };

        // Act
        var card = _mapper.Map<Card>(cardDto);

        // Assert
        card.Id.Should().Be(cardDto.Id);
        card.CardNumber.Should().Be(cardDto.CardNumber);
        card.CardHolderName.Should().Be(cardDto.CardHolderName);
        card.CardExpirationDate.Should().Be(cardDto.CardExpirationDate);
        card.CardCvv.Should().Be(cardDto.CardCvv);
        card.Ssn.Should().Be(cardDto.Ssn);
    }

    [Fact]
    public void Should_Map_CreditCard_To_CreditCardDto()
    {
        // Arrange
        var creditCard = new CreditCard();
        creditCard.SetId(Guid.NewGuid());
        creditCard.SetCardNumber("1234567890123456");
        creditCard.SetCardHolderName("John Doe");
        creditCard.SetCardExpirationDate("12/24");
        creditCard.SetCardCvv("123");
        creditCard.SetSsn("111-22-3333");

        // Act
        var creditCardDto = _mapper.Map<CreditCardDto>(creditCard);

        // Assert
        creditCardDto.Id.Should().Be(creditCard.Id);
        creditCardDto.CardNumber.Should().Be(creditCard.CardNumber);
        creditCardDto.CardHolderName.Should().Be(creditCard.CardHolderName);
        creditCardDto.CardExpirationDate.Should().Be(creditCard.CardExpirationDate);
        creditCardDto.CardCvv.Should().Be(creditCard.CardCvv);
        creditCardDto.Ssn.Should().Be(creditCard.Ssn);
    }

    [Fact]
    public void Should_Map_CreditCardDto_To_CreditCard()
    {
        // Arrange
        var creditCardDto = new CreditCardDto
        {
            Id = Guid.NewGuid(),
            CardNumber = "1234567890123456",
            CardHolderName = "John Doe",
            CardExpirationDate = "12/24",
            CardCvv = "123",
            Ssn = "111-22-3333"
        };

        // Act
        var creditCard = _mapper.Map<CreditCard>(creditCardDto);

        // Assert
        creditCard.Id.Should().Be(creditCardDto.Id);
        creditCard.CardNumber.Should().Be(creditCardDto.CardNumber);
        creditCard.CardHolderName.Should().Be(creditCardDto.CardHolderName);
        creditCard.CardExpirationDate.Should().Be(creditCardDto.CardExpirationDate);
        creditCard.CardCvv.Should().Be(creditCardDto.CardCvv);
        creditCard.Ssn.Should().Be(creditCardDto.Ssn);
    }

    [Fact]
    public void Should_Map_DebitCard_To_DebitCardDto()
    {
        // Arrange
        var debitCard = new DebitCard();
        debitCard.SetId(Guid.NewGuid());
        debitCard.SetCardNumber("1234567890123456");
        debitCard.SetCardHolderName("John Doe");
        debitCard.SetCardExpirationDate("12/24");
        debitCard.SetCardCvv("123");
        debitCard.SetSsn("111-22-3333");

        // Act
        var debitCardDto = _mapper.Map<DebitCardDto>(debitCard);

        // Assert
        debitCardDto.Id.Should().Be(debitCard.Id);
        debitCardDto.CardNumber.Should().Be(debitCard.CardNumber);
        debitCardDto.CardHolderName.Should().Be(debitCard.CardHolderName);
        debitCardDto.CardExpirationDate.Should().Be(debitCard.CardExpirationDate);
        debitCardDto.CardCvv.Should().Be(debitCard.CardCvv);
        debitCardDto.Ssn.Should().Be(debitCard.Ssn);
    }

    [Fact]
    public void Should_Map_DebitCardDto_To_DebitCard()
    {
        // Arrange
        var debitCardDto = new DebitCardDto
        {
            Id = Guid.NewGuid(),
            CardNumber = "1234567890123456",
            CardHolderName = "John Doe",
            CardExpirationDate = "12/24",
            CardCvv = "123",
            Ssn = "111-22-3333"
        };

        // Act
        var debitCard = _mapper.Map<DebitCard>(debitCardDto);

        // Assert
        debitCard.Id.Should().Be(debitCardDto.Id);
        debitCard.CardNumber.Should().Be(debitCardDto.CardNumber);
        debitCard.CardHolderName.Should().Be(debitCardDto.CardHolderName);
        debitCard.CardExpirationDate.Should().Be(debitCardDto.CardExpirationDate);
        debitCard.CardCvv.Should().Be(debitCardDto.CardCvv);
        debitCard.Ssn.Should().Be(debitCardDto.Ssn);
    }

    [Fact]
    public void Should_Map_PaymentMethod_To_PaymentMethodDto()
    {
        // Arrange
        var paymentMethod = new PaymentMethod();
        paymentMethod.CreditCard.SetId(Guid.NewGuid());
        paymentMethod.DebitCard.SetId(Guid.NewGuid());

        // Act
        var paymentMethodDto = _mapper.Map<PaymentMethodDto>(paymentMethod);

        // Assert
        paymentMethodDto.CreditCard.Id.Should().Be(paymentMethod.CreditCard.Id);
        paymentMethodDto.DebitCard.Id.Should().Be(paymentMethod.DebitCard.Id);
    }

    [Fact]
    public void Should_Map_PaymentMethodDto_To_PaymentMethod()
    {
        // Arrange
        var creditCardDto = new CreditCardDto { Id = Guid.NewGuid() };
        var debitCardDto = new DebitCardDto { Id = Guid.NewGuid() };
        var paymentMethodDto = new PaymentMethodDto(creditCardDto, debitCardDto);

        // Act
        var paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodDto);

        // Assert
        paymentMethod.CreditCard.Id.Should().Be(paymentMethodDto.CreditCard.Id);
        paymentMethod.DebitCard.Id.Should().Be(paymentMethodDto.DebitCard.Id);
    }

    [Fact]
    public void Should_Map_Payment_To_PaymentDto()
    {
        // Arrange
        var payment = new PaymentMethod();
        payment.SetId(1);
        payment.SetSsn("111-22-3333");
        payment.SetAmount(100.00m);

        // Act
        var paymentDto = _mapper.Map<PaymentDto>(payment);

        // Assert
        paymentDto.Id.Should().Be(payment.Id);
        paymentDto.Ssn.Should().Be(payment.Ssn);
        paymentDto.Amount.Should().Be(payment.Amount);
    }
}