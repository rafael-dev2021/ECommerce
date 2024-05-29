using Application.Dtos.DeliveriesDto;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.DeliveriesDto;

public class DeliveryAddressDtoTests
{
    [Fact]
    public void DeliveryAddressDto_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string country = "Country";
        string address = "Address";
        string complement = "Complement";
        string zipCode = "12345-678";
        string state = "State";
        string city = "City";
        string neighborhood = "Neighborhood";

        // Act
        var deliveryAddressDto = new DeliveryAddressDto(country, address, complement, zipCode, state, city, neighborhood);

        // Assert
        Assert.Equal(country, deliveryAddressDto.Country);
        Assert.Equal(address, deliveryAddressDto.Address);
        Assert.Equal(complement, deliveryAddressDto.Complement);
        Assert.Equal(zipCode, deliveryAddressDto.ZipCode);
        Assert.Equal(state, deliveryAddressDto.State);
        Assert.Equal(city, deliveryAddressDto.City);
        Assert.Equal(neighborhood, deliveryAddressDto.Neighborhood);
    }
}
