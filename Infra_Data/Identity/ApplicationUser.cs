using Microsoft.AspNetCore.Identity;

namespace Infra_Data.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; }= string.Empty;
    public string Ssn { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public bool IsSubscribedToNewsletter { get; set; }
}