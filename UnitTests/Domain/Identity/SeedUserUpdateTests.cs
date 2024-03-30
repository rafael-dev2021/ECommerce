using Domain.Identity;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Identity;
using Xunit;

namespace UnitTests.Domain.Identity;

[TestFixture]
public class SeedUserUpdateTests
{
    private readonly SeedUserUpdateValidator _validator = new();

    [Fact]
    [Test]
    public void FirstName_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { FirstName = "" };
        // Act 
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.FirstName)
            .WithErrorMessage("First name cannot be empty.");
    }

    [Fact]
    [Test]
    public void FirstName_WhenMaxLengthExceeded_ShouldHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { FirstName = new string('A', 51) };
        // Act 
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.FirstName)
            .WithErrorMessage("First name must have a maximum length of 50 characters.");
    }

    [Fact]
    [Test]
    public void FirstName_WhenValid_ShouldNotHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { FirstName = "John" };
        // Act 
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    [Test]
    public void LastName_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { LastName = "" };
        // Act 
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.LastName)
            .WithErrorMessage("Last name cannot be empty.");
    }

    [Fact]
    [Test]
    public void LastName_WhenMaxLengthExceeded_ShouldHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { LastName = new string('A', 51) };
        // Act 
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.LastName)
            .WithErrorMessage("Last name must have a maximum length of 50 characters.");
    }

    [Fact]
    [Test]
    public void LastName_WhenValid_ShouldNotHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { LastName = "John" };
        // Act 
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.LastName);
    }

    [Fact]
    [Test]
    public void Email_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { Email = "" };
        // Act 
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage("Email cannot be empty.");
    }

    [Fact]
    [Test]
    public void Email_WhenInvalidEmail_ShouldHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { Email = "invalidemail" };
        // Act 
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage("Invalid email address format.");
    }

    [Fact]
    [Test]
    public void Email_WhenMaxLengthExceeded_ShouldHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { Email = new string('A', 51) };
        // Act 
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage("Email must have a maximum length of 50 characters.");
    }

    [Fact]
    [Test]
    public void Phone_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { Phone = "" };
        // Act 
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Phone)
            .WithErrorMessage("Phone cannot be empty.");
    }
    
    [Fact]
    [Test]
    public void Phone_WhenValid_ShouldNotHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { Phone = "1234567890" };
        // Act
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Phone);
    }
    
    [Fact]
    [Test]
    public void Phone_WhenMaxLengthExceeded_ShouldHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { Phone = new string('A', 17) };
        // Act 
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Phone)
            .WithErrorMessage("Phone must have a maximum length of 16 characters.");
    }
    
    [Fact]
    [Test]
    public void Ssn_WhenValid_ShouldNotHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { Ssn = "123456789" };
        // Act
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Ssn);
    }

    [Fact]
    [Test]
    public void Ssn_WhenInvalid_ShouldHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { Ssn = "12345678" };
        // Act
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Ssn)
            .WithErrorMessage("SSN must be a 9-digit number.");
    }
    
    [Fact]
    [Test]
    public void Ssn_WhenMaxLengthExceeded_ShouldHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { Ssn = new string('A', 12) };
        // Act 
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Ssn)
            .WithErrorMessage("SSN must have a maximum length of 11 characters.");
    }
    
    [Fact]
    [Test]
    public void BirthDate_WhenEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { BirthDate = DateTime.MinValue };
        // Act 
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.BirthDate)
            .WithErrorMessage("Birth date cannot be empty.");
    }
    
    [Fact]
    [Test]
    public void IsSubscribedToNewsletter_WhenEmpty_ShouldNotHaveValidationError()
    {
        // Arrange
        var model = new SeedUserUpdate { IsSubscribedToNewsletter = false };
        // Act 
        var result = _validator.TestValidate(model);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.IsSubscribedToNewsletter);
    }
    
}