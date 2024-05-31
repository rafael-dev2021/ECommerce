using System.Reflection;
using Infra_Data.Identity;
using Microsoft.AspNetCore.Identity;
using NSubstitute;
using Xunit;

namespace UnitTests.Infra_Data.Identity;

public class SeedUserRoleRepositoryTests
{
    private readonly RoleManager<IdentityRole> _roleManagerMock;
    private readonly UserManager<ApplicationUser> _userManagerMock;
    private readonly SeedUserRoleRepository _seedUserRoleRepository;

    public SeedUserRoleRepositoryTests()
    {
        // Mock RoleManager
        var roleStoreMock = Substitute.For<IRoleStore<IdentityRole>>();
        _roleManagerMock = Substitute.For<RoleManager<IdentityRole>>(
            roleStoreMock, null, null, null, null);

        // Mock UserManager
        var userStoreMock = Substitute.For<IUserStore<ApplicationUser>>();
        _userManagerMock = Substitute.For<UserManager<ApplicationUser>>(
            userStoreMock, null, null, null, null, null, null, null, null);

        _seedUserRoleRepository = new SeedUserRoleRepository(_roleManagerMock, _userManagerMock);
    }

    [Fact]
    public async Task SeedRoleAsync_CreatesAdminAndUserRolesIfNotExist()
    {
        // Arrange
        _roleManagerMock.RoleExistsAsync("Admin").Returns(false);
        _roleManagerMock.RoleExistsAsync("User").Returns(false);
        _roleManagerMock.CreateAsync(Arg.Any<IdentityRole>()).Returns(IdentityResult.Success);

        // Act
        await _seedUserRoleRepository.SeedRoleAsync();

        // Assert
        await _roleManagerMock.Received(1).CreateAsync(Arg.Is<IdentityRole>(role => role.Name == "Admin"));
        await _roleManagerMock.Received(1).CreateAsync(Arg.Is<IdentityRole>(role => role.Name == "User"));
    }

    [Fact]
    public async Task CreateUserIfNotExists_CreatesUserIfNotExists()
    {
        // Arrange
        const string email = "newuser@localhost.com";
        const string roleName = "User";
        _userManagerMock.FindByEmailAsync(email).Returns(Task.FromResult<ApplicationUser?>(null));
        _userManagerMock.CreateAsync(Arg.Any<ApplicationUser>(), Arg.Any<string>())
            .Returns(Task.FromResult(IdentityResult.Success));
        _userManagerMock.AddToRoleAsync(Arg.Any<ApplicationUser>(), roleName)
            .Returns(Task.FromResult(IdentityResult.Success));

        // Act
        var createUserIfNotExistsMethod = typeof(SeedUserRoleRepository)
            .GetMethod("CreateUserIfNotExists",
                BindingFlags.NonPublic | BindingFlags.Instance);
        await (Task)createUserIfNotExistsMethod?.Invoke(_seedUserRoleRepository, [email, roleName])!;

        // Assert
        await _userManagerMock.Received(1).CreateAsync(
            Arg.Is<ApplicationUser>(user => user.Email == email), Arg.Any<string>());
        await _userManagerMock.Received(1).AddToRoleAsync(
            Arg.Is<ApplicationUser>(user => user.Email == email), roleName);
    }

    [Fact]
    public async Task CreateUserIfNotExists_DoesNotCreateUserIfExists()
    {
        // Arrange
        const string email = "existinguser@localhost.com";
        const string roleName = "User";
        var existingUser = new ApplicationUser { Email = email };
        _userManagerMock.FindByEmailAsync(email).Returns(Task.FromResult<ApplicationUser?>(existingUser));

        // Act
        var createUserIfNotExistsMethod = typeof(SeedUserRoleRepository)
            .GetMethod("CreateUserIfNotExists",
                BindingFlags.NonPublic | BindingFlags.Instance);
        await (Task)createUserIfNotExistsMethod?.Invoke(_seedUserRoleRepository, [email, roleName])!;

        // Assert
        await _userManagerMock.DidNotReceive().CreateAsync(Arg.Any<ApplicationUser>(), Arg.Any<string>());
        await _userManagerMock.DidNotReceive().AddToRoleAsync(Arg.Any<ApplicationUser>(), Arg.Any<string>());
    }

    [Fact]
    public async Task SeedUserAsync_CreatesAdminAndUserIfNotExist()
    {
        // Arrange
        _userManagerMock.FindByEmailAsync("admin@localhost.com").Returns(Task.FromResult<ApplicationUser?>(null));
        _userManagerMock.FindByEmailAsync("user@localhost.com").Returns(Task.FromResult<ApplicationUser?>(null));
        _userManagerMock.CreateAsync(Arg.Any<ApplicationUser>(), Arg.Any<string>())
            .Returns(Task.FromResult(IdentityResult.Success));
        _userManagerMock.AddToRoleAsync(Arg.Any<ApplicationUser>(), Arg.Any<string>())
            .Returns(Task.FromResult(IdentityResult.Success));

        // Act
        await _seedUserRoleRepository.SeedUserAsync();

        // Assert
        await _userManagerMock.Received(1).CreateAsync(
            Arg.Is<ApplicationUser>(user => user.Email == "admin@localhost.com"), Arg.Any<string>());
        await _userManagerMock.Received(1).AddToRoleAsync(
            Arg.Is<ApplicationUser>(user => user.Email == "admin@localhost.com"), "Admin");

        await _userManagerMock.Received(1).CreateAsync(
            Arg.Is<ApplicationUser>(user => user.Email == "user@localhost.com"), Arg.Any<string>());
        await _userManagerMock.Received(1).AddToRoleAsync(
            Arg.Is<ApplicationUser>(user => user.Email == "user@localhost.com"), "User");
    }

    [Fact]
    public async Task SeedUserAsync_DoesNotCreateUsersIfTheyExist()
    {
        // Arrange
        var adminUser = new ApplicationUser { Email = "admin@localhost.com" };
        var normalUser = new ApplicationUser { Email = "user@localhost.com" };
        _userManagerMock.FindByEmailAsync("admin@localhost.com").Returns(Task.FromResult<ApplicationUser?>(adminUser));
        _userManagerMock.FindByEmailAsync("user@localhost.com").Returns(Task.FromResult<ApplicationUser?>(normalUser));

        // Act
        await _seedUserRoleRepository.SeedUserAsync();

        // Assert
        await _userManagerMock.DidNotReceive().CreateAsync(Arg.Any<ApplicationUser>(), Arg.Any<string>());
        await _userManagerMock.DidNotReceive().AddToRoleAsync(Arg.Any<ApplicationUser>(), Arg.Any<string>());
    }
}