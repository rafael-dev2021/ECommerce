namespace Domain.Interfaces.Identity;

public interface ISeedUserRoleRepository
{
    Task SeedUserAsync();
    Task SeedRoleAsync();
}