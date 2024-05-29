using Application.Dtos.DeliveriesDto;
using Application.Mappings;
using AutoMapper;
using Domain.Entities.Deliveries;
using FluentAssertions;
using Xunit;

namespace UnitTests.Application.Mappings;

public class MappingTheDeliveriesProfileTests
{
    private readonly IMapper _mapper;

    public MappingTheDeliveriesProfileTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingTheDeliveriesProfile>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Should_Map_DeliveryAddress_To_DeliveryAddressDto()
    {
        // Arrange
        var deliveryAddress = new DeliveryAddress();
        deliveryAddress.SetCountry("USA");
        deliveryAddress.SetAddress("123 Main St");
        deliveryAddress.SetComplement("Apt 4B");
        deliveryAddress.SetZipCode("12345");
        deliveryAddress.SetState("NY");
        deliveryAddress.SetCity("New York");
        deliveryAddress.SetNeighborhood("Manhattan");

        // Act
        var deliveryAddressDto = _mapper.Map<DeliveryAddressDto>(deliveryAddress);

        // Assert
        deliveryAddressDto.Country.Should().Be(deliveryAddress.Country);
        deliveryAddressDto.Address.Should().Be(deliveryAddress.Address);
        deliveryAddressDto.Complement.Should().Be(deliveryAddress.Complement);
        deliveryAddressDto.ZipCode.Should().Be(deliveryAddress.ZipCode);
        deliveryAddressDto.State.Should().Be(deliveryAddress.State);
        deliveryAddressDto.City.Should().Be(deliveryAddress.City);
        deliveryAddressDto.Neighborhood.Should().Be(deliveryAddress.Neighborhood);
    }

    [Fact]
    public void Should_Map_DeliveryAddressDto_To_DeliveryAddress()
    {
        // Arrange
        var deliveryAddressDto = new DeliveryAddressDto(
            "USA", "123 Main St", "Apt 4B", "12345", "NY", "New York", "Manhattan");

        // Act
        var deliveryAddress = _mapper.Map<DeliveryAddress>(deliveryAddressDto);

        // Assert
        deliveryAddress.Country.Should().Be(deliveryAddressDto.Country);
        deliveryAddress.Address.Should().Be(deliveryAddressDto.Address);
        deliveryAddress.Complement.Should().Be(deliveryAddressDto.Complement);
        deliveryAddress.ZipCode.Should().Be(deliveryAddressDto.ZipCode);
        deliveryAddress.State.Should().Be(deliveryAddressDto.State);
        deliveryAddress.City.Should().Be(deliveryAddressDto.City);
        deliveryAddress.Neighborhood.Should().Be(deliveryAddressDto.Neighborhood);
    }

    [Fact]
    public void Should_Map_UserDelivery_To_UserDeliveryDto()
    {
        // Arrange
        var userDelivery = new UserDelivery();
        userDelivery.SetFirstName("John");
        userDelivery.SetLastName("Doe");
        userDelivery.SetEmail("john.doe@example.com");
        userDelivery.SetPhone("123-456-7890");
        userDelivery.SetSsn("123-45-6789");

        // Act
        var userDeliveryDto = _mapper.Map<UserDeliveryDto>(userDelivery);

        // Assert
        userDeliveryDto.FirstName.Should().Be(userDelivery.FirstName);
        userDeliveryDto.LastName.Should().Be(userDelivery.LastName);
        userDeliveryDto.Email.Should().Be(userDelivery.Email);
        userDeliveryDto.Phone.Should().Be(userDelivery.Phone);
        userDeliveryDto.Ssn.Should().Be(userDelivery.Ssn);
    }

    [Fact]
    public void Should_Map_UserDeliveryDto_To_UserDelivery()
    {
        // Arrange
        var userDeliveryDto = new UserDeliveryDto(
            "John", "Doe", "john.doe@example.com", "123-456-7890", "123-45-6789");

        // Act
        var userDelivery = _mapper.Map<UserDelivery>(userDeliveryDto);

        // Assert
        userDelivery.FirstName.Should().Be(userDeliveryDto.FirstName);
        userDelivery.LastName.Should().Be(userDeliveryDto.LastName);
        userDelivery.Email.Should().Be(userDeliveryDto.Email);
        userDelivery.Phone.Should().Be(userDeliveryDto.Phone);
        userDelivery.Ssn.Should().Be(userDeliveryDto.Ssn);
    }
}
