using Application.Dtos.PaymentsDto;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.PaymentsDto;

public class CardDtoTests
{
    [Fact]
    public void CardDto_ShouldCreateInstanceWithDefaultValues()
    {
        // Arrange & Act
        var cardDto = new CardDto();

        // Assert
        Assert.Equal(default, cardDto.Id);
        Assert.Equal(string.Empty, cardDto.CardNumber);
        Assert.Equal(string.Empty, cardDto.CardHolderName);
        Assert.Equal(string.Empty, cardDto.CardExpirationDate);
        Assert.Equal(string.Empty, cardDto.CardCvv);
        Assert.Equal(string.Empty, cardDto.Ssn);
    }

    [Fact]
    public void CardDto_ShouldSetAndGetPropertiesCorrectly()
    {
        // Arrange
        var id = new Guid("12345678-1234-5678-9012-123456789012");
        var cardNumber = "1234567890123456";
        var cardHolderName = "John Doe";
        var cardExpirationDate = "01/25";
        var cardCvv = "123";
        var ssn = "123456789";

        // Act
        var cardDto = new CardDto
        {
            Id = id,
            CardNumber = cardNumber,
            CardHolderName = cardHolderName,
            CardExpirationDate = cardExpirationDate,
            CardCvv = cardCvv,
            Ssn = ssn
        };

        // Assert
        Assert.Equal(id, cardDto.Id);
        Assert.Equal(cardNumber, cardDto.CardNumber);
        Assert.Equal(cardHolderName, cardDto.CardHolderName);
        Assert.Equal(cardExpirationDate, cardDto.CardExpirationDate);
        Assert.Equal(cardCvv, cardDto.CardCvv);
        Assert.Equal(ssn, cardDto.Ssn);
    }
}
