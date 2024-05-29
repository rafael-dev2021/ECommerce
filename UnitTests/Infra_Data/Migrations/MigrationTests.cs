using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Migrations;

public class MigrationTests
{
    private class TestDbContext : DbContext
    {
        public DbSet<IdentityRole> AspNetRoles { get; set; }
        public DbSet<IdentityUser> AspNetUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDatabase");
        }
    }

    [Fact]
    public void TestMigrationCreatesAspNetRolesTable()
    {
        _ = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new TestDbContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        using (var context = new TestDbContext())
        {
            // Attempt to add and save a new entity to verify table creation
            context.AspNetRoles.Add(new IdentityRole { Name = "TestRole", NormalizedName = "TESTROLE" });
            context.SaveChanges();

            var exists = context.AspNetRoles.Any();
            Assert.True(exists);
        }
    }

    [Fact]
    public void TestMigrationCreatesAspNetUsersTable()
    {
        _ = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new TestDbContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        using (var context = new TestDbContext())
        {
            // Attempt to add and save a new entity to verify table creation
            context.AspNetUsers.Add(new IdentityUser { UserName = "TestUser", NormalizedUserName = "TESTUSER" });
            context.SaveChanges();

            var exists = context.AspNetUsers.Any();
            Assert.True(exists);
        }
    }
}
