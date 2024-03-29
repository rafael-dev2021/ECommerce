namespace Domain.Entities.Deliveries;

public class UserDelivery
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private  set; } = string.Empty;
    public string Email { get; private  set; } = string.Empty;
    public string Phone { get; private  set; } = string.Empty;
    public string Ssn { get; private  set; } = string.Empty;

    public void SetFirstName(string firstName) => FirstName = firstName;
    public void SetLastName(string lastName) => LastName = lastName;
    public void SetEmail(string email) => Email = email;
    public void SetPhone(string phone) => Phone = phone;
    public void SetSsn(string ssn) => Ssn = ssn;
    public void Update(string phone, string email) { Phone = phone; Email = email; }
}