using Domain.Identity;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Identity;
using Xunit;

namespace UnitTests.Domain.Identity;

[TestFixture]
public class AuthenticationResultTests
{

    private readonly AuthenticationResultValidator _validator = new();

    [Fact]
    [Test]
    public void IsAuthenticated_WhenFalse_ShouldHaveValidationError()
    {
        // Arrange
        var model = new AuthenticationResult();
        model.SetIsAuthenticated(false);

        // Act
        var result = _validator.TestValidate(model);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.IsAuthenticated)
            .WithErrorMessage("Authentication failed.");
    }

    [Fact]
    [Test]
    public void ErrorMessage_WhenEmptyAndNotAuthenticated_ShouldHaveValidationError()
    {
        // Arrange
        var model = new AuthenticationResult();
        model.SetIsAuthenticated(false);
        model.SetErrorMessage("");

        // Act
        var result = _validator.TestValidate(model);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ErrorMessage)
            .WithErrorMessage("Error message cannot be empty if authentication failed.");
    }

    [Fact]
    [Test]
    public void ErrorMessage_WhenNotEmptyAndAuthenticated_ShouldHaveValidationError()
    {
        // Arrange
        var model = new AuthenticationResult();
        model.SetIsAuthenticated(true);
        model.SetErrorMessage("Some error message");

        // Act
        var result = _validator.TestValidate(model);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ErrorMessage)
            .WithErrorMessage("Error message must be empty if authentication succeeded.");
    }

    [Fact]
    [Test]
    public void IsAuthenticated_WhenTrue_ShouldNotHaveValidationError()
    {
        // Arrange
        var model = new AuthenticationResult();
        model.SetIsAuthenticated(true);

        // Act
        var result = _validator.TestValidate(model);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.IsAuthenticated);
    }

    [Fact]
    [Test]
    public void ErrorMessage_WhenEmptyAndAuthenticated_ShouldNotHaveValidationError()
    {
        // Arrange
        var model = new AuthenticationResult();
        model.SetIsAuthenticated(true);
        model.SetErrorMessage("");

        // Act
        var result = _validator.TestValidate(model);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.ErrorMessage);
    }

    [Fact]
    [Test]
    public void ErrorMessage_WhenNotEmptyAndNotAuthenticated_ShouldNotHaveValidationError()
    {
        // Arrange
        var model = new AuthenticationResult();
        model.SetIsAuthenticated(false);
        model.SetErrorMessage("Some error message");

        // Act
        var result = _validator.TestValidate(model);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.ErrorMessage);
    }
}
