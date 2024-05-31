using Domain.Identity;
using Domain.Interfaces.Identity;
using Infra_Data.Context;
using Infra_Data.Identity.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Identity;

public class AuthenticateRepository(
    SignInManager<ApplicationUser> signInManager,
    UserManager<ApplicationUser> userManager,
    AppDbContext appDbContext) : IAuthenticateRepository
{
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly AppDbContext _appDbContext = appDbContext;
    private readonly AuthenticateHelper _authenticateHelper = new(signInManager);

    private readonly RegisterHelper _registerHelper = new(
        signInManager,
        userManager,
        appDbContext
    );


    public async Task<RegistrationResult> RegisterAsync(string email, string password, string firstName,
        string lastName, string phone, string ssn, DateTime birthDate)
    {
        var validationErrors = await _registerHelper.ValidateAsync(email, ssn, phone);
        
        if (validationErrors.Count <= 0)
            return await _registerHelper.CreateUserAsync(email, password, firstName, lastName, phone, ssn, birthDate);
        
        var errorMessage = string.Join(Environment.NewLine, validationErrors);
        var registrationResult = new RegistrationResult();
        registrationResult.SetIsRegistered(false);
        registrationResult.SetErrorMessage(errorMessage);
        return registrationResult;

    }

    public async Task<AuthenticationResult> AuthenticateAsync(string email, string password, bool rememberMe)
    {
        return await _authenticateHelper.AuthenticateAsync(email, password, rememberMe);
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return false;
        var changePasswordResult = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

        return changePasswordResult.Succeeded;
    }

    public async Task<bool> ForgotPasswordAsync(string email, string newPassword)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return false;

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var resetPasswordResult = await _userManager.ResetPasswordAsync(user, token, newPassword);

        return resetPasswordResult.Succeeded;
    }

    public async Task<SeedUserUpdate> GetUserProfileAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        var userProfile = new SeedUserUpdate
        {
            FirstName = user?.FirstName!,
            LastName = user?.LastName!,
            Phone = user?.PhoneNumber!,
            BirthDate = user!.BirthDate,
            Ssn = user.Ssn,
            IsSubscribedToNewsletter = user.IsSubscribedToNewsletter
        };

        return userProfile;
    }

    public async Task<(bool success, string errorMessage)> UpdateProfileAsync(string email, string firstName,
        string lastName, string phone,
        DateTime birthDate, bool iSSubscribedToNewsletter)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return (false, "User not found.");
        }

        user.FirstName = firstName;
        user.LastName = lastName;
        user.PhoneNumber = phone;
        user.BirthDate = birthDate;
        user.IsSubscribedToNewsletter = iSSubscribedToNewsletter;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return (false, "Failed to update profile.");
        }

        var phoneAlreadyUsed = await IsPhoneAlreadyUsed(phone, user.Id);
        return phoneAlreadyUsed ? (false, "Phone number already registered.") : (true, "");
    }

    public async Task<bool> IsPhoneAlreadyUsed(string phone, string userId)
    {
        return await _appDbContext
            .Users
            .AnyAsync(u => u.PhoneNumber == phone && u.Id != userId);
    }
}