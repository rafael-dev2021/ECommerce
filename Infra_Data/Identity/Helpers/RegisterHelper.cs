using Domain.Identity;
using Infra_Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Identity.Helpers;

public class RegisterHelper(
    SignInManager<ApplicationUser> signInManager,
    UserManager<ApplicationUser> userManager,
    AppDbContext appDbContext)
{
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly AppDbContext _appDbContext = appDbContext;

    private async Task<bool> IsSsnAlreadyUsed(string ssn) => await
        _appDbContext
            .Users
            .FirstOrDefaultAsync(s => s.Ssn == ssn) != null;

    private async Task<bool> IsEmailAlreadyUsed(string email) => await
        _appDbContext
            .Users
            .FirstOrDefaultAsync(e => e.Email == email) != null;

    private async Task<bool> IsPhoneAlreadyUsed(string phone) => await
        _appDbContext
            .Users
            .FirstOrDefaultAsync(p => p.PhoneNumber == phone) != null;
    
    
    public async Task<List<string>> ValidateAsync(string email, string ssn, string phone)
    {
        var validationErrors = new List<string>();

        var errors = new Dictionary<Func<Task<bool>>, string>
        {
            { () => IsSsnAlreadyUsed(ssn), "SSN already registered." },
            { () => IsEmailAlreadyUsed(email), "Email exists" },
            { () => IsPhoneAlreadyUsed(phone), "Phone number already registered." }
        };

        foreach (var error in errors)
        {
            if (await error.Key())
            {
                validationErrors.Add(error.Value);
            }
        }
        return validationErrors;
    }

    
    public async Task<RegistrationResult> CreateUserAsync(string email, string password, string firstName,
        string lastName, string phone, string ssn, DateTime birthDate)
    {
        var registrationResult = new RegistrationResult();
        var appUser = new ApplicationUser()
        {
            Email = email,
            UserName = email,
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phone,
            Ssn = ssn,
            BirthDate = birthDate
        };

        var result = await _userManager.CreateAsync(appUser, password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(appUser, "User");
            await _signInManager.SignInAsync(appUser, isPersistent: false);
            registrationResult.SetErrorMessage("Registration successful.");
            return registrationResult;
        }

        registrationResult.SetIsRegistered(false);
        registrationResult.SetErrorMessage("User creation failed.");
        return registrationResult;
    }
}