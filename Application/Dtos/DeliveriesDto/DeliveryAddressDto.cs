namespace Application.Dtos.DeliveriesDto;

public record DeliveryAddressDto(
    string Country,
    string Address,
    string Complement,
    string ZipCode,
    string State,
    string City,
    string Neighborhood) { }

