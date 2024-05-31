using Domain.Interfaces.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infra_Data.Identity;

public class SeedUserRoleRepository(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    : ISeedUserRoleRepository
{
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    private async Task CreateRoleIfNotExists(string roleName)
    {
        if (!await _roleManager.RoleExistsAsync(roleName))
        {
            IdentityRole role = new()
            {
                Name = roleName,
                NormalizedName = roleName.ToUpper()
            };
            await _roleManager.CreateAsync(role);
        }
    }
    

    private async Task CreateUserIfNotExists(string email, string roleName)
    {
        if (await _userManager.FindByEmailAsync(email) == null)
        {
            var appUser = new ApplicationUser
            {
                Email = email,
                UserName = email,
                NormalizedEmail = email.ToUpper(),
                NormalizedUserName = email.ToUpper(),
                FirstName = "Rafael",
                LastName = "Silva",
                BirthDate = new DateTime(2000, 02, 20, 0, 0, 0,DateTimeKind.Utc),
                Ssn = "123-45-6789",
                PhoneNumber = "161-240-7675",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(appUser, "@Visual23k+");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, roleName);
            }
        }
    }

   public async Task SeedRoleAsync()
    {
        await CreateRoleIfNotExists("Admin");
        await CreateRoleIfNotExists("User");
    }

    public async Task SeedUserAsync()
    {
        await CreateUserIfNotExists("admin@localhost.com", "Admin");
        await CreateUserIfNotExists("user@localhost.com", "User");
    }
}