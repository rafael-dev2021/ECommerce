﻿using Domain.Identity;

namespace Domain.Interfaces.Identity;

public interface IAuthenticateRepository
{
    Task<AuthenticationResult> AuthenticateAsync(string email, string password, bool rememberMe);
    Task<RegistrationResult> RegisterAsync(string email, string password, string firstName, string lastName, string phone, string ssn, DateTime birthDate);
    Task LogoutAsync();
    Task<bool> UpdateProfileAsync(string email, string firstName, string lastName, string phone, DateTime birthDate, bool iSSubscribedToNewsletter);
    Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword);
    Task<SeedUserUpdate> GetUserProfileAsync(string userEmail);
    Task<bool> ForgotPasswordAsync(string email, string newPassWord);
}