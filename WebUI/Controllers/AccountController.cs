using System.Security.Claims;
using Domain.Interfaces.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels.IdentityViewModel;

namespace WebUI.Controllers;

public class AccountController(IAuthenticateRepository authenticateRepository) : Controller
{

    [AllowAnonymous]
    public IActionResult Login(string returnUrl) =>
       View(new LoginViewModel()
       { ReturnUrl = returnUrl });


    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var authenticationResult = await authenticateRepository.AuthenticateAsync(model.Email, model.Password, model.RememberMe);

        if (authenticationResult.IsAuthenticated)
        {
            if (string.IsNullOrEmpty(model.ReturnUrl))
                return RedirectToAction("Index", "Home");

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, model.Email),
                new(ClaimTypes.Role, "User")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return Redirect(model.ReturnUrl);
        }
        else
        {
            ModelState.AddModelError(string.Empty, authenticationResult.ErrorMessage);
        }

        return View(model);
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Register() => View();

    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var registrationResult = await authenticateRepository.RegisterAsync(model.Email, model.Password, model.FirstName, model.LastName, model.Phone, model.Ssn, model.BirthDate);

        if (registrationResult.IsRegistered)
            return Redirect("/");

        ModelState.AddModelError(string.Empty, registrationResult.ErrorMessage);
        return View(model);
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        HttpContext.Session.Clear();
        HttpContext.User = null!;

        await authenticateRepository.LogoutAsync();

        const string url = "/Account/Login";
        return Redirect(url);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> EditProfile()
    {
        var userEmail = User.Identity?.Name;
        
        var userProfile = await authenticateRepository.GetUserProfileAsync(userEmail!);

        var model = new EditProfileViewModel
        {
            FirstName = userProfile.FirstName,
            LastName = userProfile.LastName,
            Phone = userProfile.Phone,
            BirthDate = userProfile.BirthDate,
            SSN = userProfile.Ssn
        };

        return View(model);
    }
    
    [Authorize]
    [HttpGet]
    public IActionResult EditProfileSuccess() => View();

    [Authorize]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> EditProfile(EditProfileViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var userEmail = User.Identity?.Name;

        var updateResult = await authenticateRepository
            .UpdateProfileAsync(
            userEmail!,
            model.FirstName,
            model.LastName,
            model.Phone,
            model.BirthDate,
            model.IsSubscribedToNewsletter);

        if (updateResult.success)
            return RedirectToAction(EditProfileSuccess().ToString());

        ModelState.AddModelError(string.Empty, updateResult.errorMessage);
        return View(model);
    }

    [Authorize]
    [HttpGet]
    public IActionResult AccessDenied() => View();

    [Authorize]
    [HttpGet]
    public IActionResult ChangePasswordSuccess() => View();
    
    [Authorize]
    [HttpGet]
    public IActionResult ChangePassword() => View();
    
    [Authorize]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var userEmail = User.Identity?.Name;

        var changePasswordResult = await authenticateRepository
            .ChangePasswordAsync(
            userEmail!,
            model.OldPassword,
            model.NewPassword);

        if (changePasswordResult)
            return RedirectToAction(ChangePasswordSuccess().ToString());

        ModelState.AddModelError(string.Empty, "Failed to change password.");
        return View(model);
    }

    [HttpGet]
    public IActionResult PasswordResetSuccess() => View();

    [HttpGet]
    public IActionResult ResetPassword() => View();

    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> ResetPassword(PasswordResetViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        
        var resetResult = await authenticateRepository.ForgotPasswordAsync(model.Email, model.NewPassword);

        if (resetResult)
            return RedirectToAction(PasswordResetSuccess().ToString());

        ModelState.AddModelError(string.Empty,
            "An error occurred while resetting the password, user not found.");

        return View(model);
    }
}
