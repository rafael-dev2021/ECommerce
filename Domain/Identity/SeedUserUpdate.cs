namespace Domain.Identity;

public class SeedUserUpdate
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Ssn { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public bool IsSubscribedToNewsletter { get; set; }
}