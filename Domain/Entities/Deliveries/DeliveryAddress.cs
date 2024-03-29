namespace Domain.Entities.Deliveries;

public class DeliveryAddress
{
    public string Country { get; private  set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public string Complement { get; private set; } = string.Empty;
    public string ZipCode { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string Neighborhood { get; private set; } = string.Empty;

    public void SetCountry(string country) => Country = country;
    public void SetAddress(string address) => Address = address;
    public void SetComplement(string complement) => Complement = complement;
    public void SetZipCode(string zipCode) => ZipCode = zipCode;
    public void SetState(string state) => State = state;
    public void SetCity(string city) => City = city;
    public void SetNeighborhood(string neighborhood) => Neighborhood = neighborhood;
    
    public void Update(string address, string complement,string neighborhood)
    {
        Address = address;
        Complement = complement;
        Neighborhood = neighborhood;
    }
}