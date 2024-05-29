using Application.Dtos.DeliveriesDto;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.DeliveriesDto;

public class UserDeliveryDtoTests
{
    [Fact]
    public void UserDeliveryDto_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string firstName = "John";
        string lastName = "Doe";
        string email = "john.doe@example.com";
        string phone = "1234567890";
        string ssn = "123-45-6789";

        // Act
        var userDeliveryDto = new UserDeliveryDto(firstName, lastName, email, phone, ssn);

        // Assert
        Assert.Equal(firstName, userDeliveryDto.FirstName);
        Assert.Equal(lastName, userDeliveryDto.LastName);
        Assert.Equal(email, userDeliveryDto.Email);
        Assert.Equal(phone, userDeliveryDto.Phone);
        Assert.Equal(ssn, userDeliveryDto.Ssn);
    }
}
