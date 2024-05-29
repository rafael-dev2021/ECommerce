using Application.Dtos.PaymentsDto;
using Domain.Entities.Payments.ObjectValues;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.PaymentsDto;

public class PaymentDtoTests
{
    [Fact]
    public void PaymentDto_ShouldCreateInstanceWithDefaultValues()
    {
        // Arrange & Act
        var paymentDto = new PaymentDto();

        // Assert
        Assert.Equal(0, paymentDto.Id);
        Assert.Equal(string.Empty, paymentDto.Ssn);
        Assert.Equal(0m, paymentDto.Amount);
        Assert.NotNull(paymentDto.PaymentMethodObjectValue);
    }

    [Fact]
    public void PaymentDto_ShouldSetAndGetPropertiesCorrectly()
    {
        // Arrange
        var id = 1;
        var ssn = "123456789";
        var amount = 100m;
        var paymentMethodObjectValue = new PaymentMethodObjectValue();

        // Act
        var paymentDto = new PaymentDto
        {
            Id = id,
            Ssn = ssn,
            Amount = amount,
            PaymentMethodObjectValue = paymentMethodObjectValue
        };

        // Assert
        Assert.Equal(id, paymentDto.Id);
        Assert.Equal(ssn, paymentDto.Ssn);
        Assert.Equal(amount, paymentDto.Amount);
        Assert.Equal(paymentMethodObjectValue, paymentDto.PaymentMethodObjectValue);
    }
}
