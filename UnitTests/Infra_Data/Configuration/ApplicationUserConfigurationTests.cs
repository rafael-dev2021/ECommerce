using Infra_Data.Configuration;
using Infra_Data.Identity;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Configuration;

public class ApplicationUserConfigurationTests
{
    [Fact]
    public void Should_Configure_ApplicationUser()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        using var context = new TestDbContext(options);

        // Ensure database is created
        context.Database.EnsureCreated();

        // Act
        var modelBuilder = new ModelBuilder();
        var applicationUserConfiguration = new ApplicationUserConfiguration();
        applicationUserConfiguration.Configure(modelBuilder.Entity<ApplicationUser>());

        // Assert
        var entityType = modelBuilder.Model.FindEntityType(typeof(ApplicationUser));
        Assert.NotNull(entityType);

        // Primary Key
        var primaryKey = entityType.FindPrimaryKey();
        Assert.NotNull(primaryKey);
        Assert.Equal("Id", primaryKey.Properties[0].Name);

        // Properties
        var firstNameProperty = entityType.FindProperty("FirstName");
        Assert.NotNull(firstNameProperty);
        Assert.Equal(50, firstNameProperty.GetMaxLength());
        Assert.False(firstNameProperty.IsNullable);

        var lastNameProperty = entityType.FindProperty("LastName");
        Assert.NotNull(lastNameProperty);
        Assert.Equal(50, lastNameProperty.GetMaxLength());
        Assert.False(lastNameProperty.IsNullable);

        var emailProperty = entityType.FindProperty("Email");
        Assert.NotNull(emailProperty);
        Assert.Equal(50, emailProperty.GetMaxLength());
        Assert.False(emailProperty.IsNullable);

        var phoneNumberProperty = entityType.FindProperty("PhoneNumber");
        Assert.NotNull(phoneNumberProperty);
        Assert.Equal(16, phoneNumberProperty.GetMaxLength());
        Assert.False(phoneNumberProperty.IsNullable);

        var ssnProperty = entityType.FindProperty("Ssn");
        Assert.NotNull(ssnProperty);
        Assert.Equal(11, ssnProperty.GetMaxLength());
        Assert.False(ssnProperty.IsNullable);
    }
}
