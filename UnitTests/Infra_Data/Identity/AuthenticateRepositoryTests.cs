using Infra_Data.Context;
using Infra_Data.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Identity;

public class AuthenticateRepositoryTests
{
    private readonly SignInManager<ApplicationUser> _signInManagerMock;
    private readonly UserManager<ApplicationUser> _userManagerMock;
    private readonly AuthenticateRepository _authenticateRepository;

    public AuthenticateRepositoryTests()
    {
        var userStoreMock = Substitute.For<IUserStore<ApplicationUser>>();
        _userManagerMock =
            Substitute.For<UserManager<ApplicationUser>>(userStoreMock, null, null, null, null, null, null, null, null);

        var contextAccessorMock = Substitute.For<IHttpContextAccessor>();
        var userPrincipalFactoryMock = Substitute.For<IUserClaimsPrincipalFactory<ApplicationUser>>();
        _signInManagerMock = Substitute.For<SignInManager<ApplicationUser>>(
            _userManagerMock, contextAccessorMock, userPrincipalFactoryMock, null, null, null, null);

        var options = new DbContextOptions<AppDbContext>();
        var appDbContextMock = Substitute.For<AppDbContext>(options);

        _authenticateRepository = new AuthenticateRepository(_signInManagerMock, _userManagerMock, appDbContextMock);
    }

    [Fact]
    public async Task AuthenticateAsync_ValidCredentials_ReturnsSuccess()
    {
        // Arrange
        const string email = "test@example.com";
        const string password = "Test@1234";
        const bool rememberMe = false;
        var signInResult = SignInResult.Success;

        _signInManagerMock.PasswordSignInAsync(email, password, rememberMe, true)
            .Returns(Task.FromResult(signInResult));

        // Act
        var result = await _authenticateRepository.AuthenticateAsync(email, password, rememberMe);

        // Assert
        Assert.True(result.IsAuthenticated);
        Assert.Equal("Login successful", result.ErrorMessage);
    }

    [Fact]
    public async Task AuthenticateAsync_InvalidCredentials_ReturnsFailure()
    {
        // Arrange
        const string email = "test@example.com";
        const string password = "wrong password";
        const bool rememberMe = false;
        var signInResult = SignInResult.Failed;

        _signInManagerMock.PasswordSignInAsync(email, password, rememberMe, true)
            .Returns(Task.FromResult(signInResult));

        // Act
        var result = await _authenticateRepository.AuthenticateAsync(email, password, rememberMe);

        // Assert
        Assert.False(result.IsAuthenticated);
        Assert.Equal("Invalid email or password. Please try again.", result.ErrorMessage);
    }

    [Fact]
    public async Task LogoutAsync_CallsSignOutAsync()
    {
        // Act
        await _authenticateRepository.LogoutAsync();

        // Assert
        await _signInManagerMock.Received(1).SignOutAsync();
    }

    [Fact]
    public async Task ChangePasswordAsync_ValidEmail_ReturnsTrue()
    {
        // Arrange
        const string email = "test@example.com";
        const string oldPassword = "OldPassword@123";
        const string newPassword = "NewPassword@123";
        var user = new ApplicationUser { Email = email };

        _userManagerMock.FindByEmailAsync(email)!.Returns(Task.FromResult(user));
        _userManagerMock.ChangePasswordAsync(user, oldPassword, newPassword)
            .Returns(Task.FromResult(IdentityResult.Success));

        // Act
        var result = await _authenticateRepository.ChangePasswordAsync(email, oldPassword, newPassword);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task ChangePasswordAsync_InvalidEmail_ReturnsFalse()
    {
        // Arrange
        const string email = "invalid@example.com";
        const string oldPassword = "OldPassword@123";
        const string newPassword = "NewPassword@123";

        _userManagerMock.FindByEmailAsync(email).Returns(Task.FromResult<ApplicationUser?>(null));

        // Act
        var result = await _authenticateRepository.ChangePasswordAsync(email, oldPassword, newPassword);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task ForgotPasswordAsync_ValidEmail_ReturnsTrue()
    {
        // Arrange
        const string email = "test@example.com";
        const string newPassword = "NewPassword@123";
        var user = new ApplicationUser { Email = email };
        const string token = "reset-token";

        _userManagerMock.FindByEmailAsync(email)!.Returns(Task.FromResult(user));
        _userManagerMock.GeneratePasswordResetTokenAsync(user).Returns(Task.FromResult(token));
        _userManagerMock.ResetPasswordAsync(user, token, newPassword).Returns(Task.FromResult(IdentityResult.Success));

        // Act
        var result = await _authenticateRepository.ForgotPasswordAsync(email, newPassword);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task ForgotPasswordAsync_InvalidEmail_ReturnsFalse()
    {
        // Arrange
        const string email = "invalid@example.com";
        const string newPassword = "NewPassword@123";

        _userManagerMock.FindByEmailAsync(email).Returns(Task.FromResult<ApplicationUser?>(null));

        // Act
        var result = await _authenticateRepository.ForgotPasswordAsync(email, newPassword);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task GetUserProfileAsync_ValidEmail_ReturnsUserProfile()
    {
        // Arrange
        const string email = "test@example.com";
        var user = new ApplicationUser
        {
            Email = email,
            FirstName = "John",
            LastName = "Doe",
            PhoneNumber = "1234567890",
            BirthDate = new DateTime(2000, 1, 1),
            Ssn = "123-45-6789",
            IsSubscribedToNewsletter = true
        };

        _userManagerMock.FindByEmailAsync(email)!.Returns(Task.FromResult(user));

        // Act
        var result = await _authenticateRepository.GetUserProfileAsync(email);

        // Assert
        Assert.Equal(user.FirstName, result.FirstName);
        Assert.Equal(user.LastName, result.LastName);
        Assert.Equal(user.PhoneNumber, result.Phone);
        Assert.Equal(user.BirthDate, result.BirthDate);
        Assert.Equal(user.Ssn, result.Ssn);
        Assert.Equal(user.IsSubscribedToNewsletter, result.IsSubscribedToNewsletter);
    }

    [Fact]
    public async Task UpdateProfileAsync_InvalidEmail_ReturnsFailure()
    {
        // Arrange
        const string email = "invalid@example.com";
        const string firstName = "John";
        const string lastName = "Doe";
        const string phone = "1234567890";
        var birthDate = new DateTime(2000, 1, 1);
        const bool isSubscribedToNewsletter = true;

        _userManagerMock.FindByEmailAsync(email).Returns(Task.FromResult<ApplicationUser?>(null));

        // Act
        var (success, errorMessage) = await _authenticateRepository.UpdateProfileAsync(email, firstName, lastName,
            phone, birthDate, isSubscribedToNewsletter);

        // Assert
        Assert.False(success);
        Assert.Equal("User not found.", errorMessage);
    }

    [Fact]
    public async Task UpdateProfileAsync_FailedToUpdate_ReturnsFailure()
    {
        // Arrange
        const string email = "test@example.com";
        const string firstName = "John";
        const string lastName = "Doe";
        const string phone = "1234567890";
        var birthDate = new DateTime(2000, 1, 1);
        const bool isSubscribedToNewsletter = true;
        var user = new ApplicationUser { Email = email };

        _userManagerMock.FindByEmailAsync(email)!.Returns(Task.FromResult(user));
        _userManagerMock.UpdateAsync(user)
            .Returns(Task.FromResult(
                IdentityResult.Failed(new IdentityError { Description = "Failed to update user." })));

        // Act
        var (success, errorMessage) = await _authenticateRepository.UpdateProfileAsync(email, firstName, lastName,
            phone, birthDate, isSubscribedToNewsletter);

        // Assert
        Assert.False(success);
        Assert.Equal("Failed to update profile.", errorMessage);
    }
}