using Application.Dtos.PaymentsDto;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.PaymentsDto;

public class PaymentMethodDtoTests
{
    [Fact]
    public void PaymentMethodDto_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        var creditCardDto = new CreditCardDto
        {
            Id = new Guid("12345678-1234-5678-9012-123456789012"),
            CardNumber = "1234567890123456",
            CardHolderName = "John Doe",
            CardExpirationDate = "01/25",
            CardCvv = "123",
            Ssn = "123456789"
        };
        var debitCardDto = new DebitCardDto
        {
            Id = new Guid("12345678-1234-5678-9012-123456789012"),
            CardNumber = "1234567890123456",
            CardHolderName = "John Doe",
            CardExpirationDate = "01/25",
            CardCvv = "123",
            Ssn = "123456789"
        };

        // Act
        var paymentMethodDto = new PaymentMethodDto(creditCardDto, debitCardDto);

        // Assert
        Assert.Equal(creditCardDto, paymentMethodDto.CreditCard);
        Assert.Equal(debitCardDto, paymentMethodDto.DebitCard);
    }
}
