using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infra_Data.Identity.Helpers;

public class AuthenticateHelper(SignInManager<ApplicationUser> signInManager)
{
    public async Task<AuthenticationResult> AuthenticateAsync(string email, string password, bool rememberMe)
    {
        var result = await signInManager.PasswordSignInAsync(email, password, isPersistent: rememberMe, lockoutOnFailure: true);

        var errorMessages = new Dictionary<Func<SignInResult, bool>, string>
        {
            { r => r.Succeeded, "Login successful" },
            { r => r.IsLockedOut, "Your account is locked. Please contact support." },
            { r => true, "Invalid email or password. Please try again." }
        };

        var errorMessage = errorMessages.First(kv => kv.Key(result)).Value;

        var authResult = new AuthenticationResult();
        authResult.SetIsAuthenticated(result.Succeeded);
        authResult.SetErrorMessage(errorMessage);

        return authResult;
    }
}