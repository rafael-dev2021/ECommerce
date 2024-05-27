using Domain.Identity;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Identity;
using Xunit;

namespace UnitTests.Domain.Identity
{
    public class RegistrationResultTests
    {
        private readonly RegistrationResultValidator _validator = new();

        [Fact]
        [Test]
        public void IsRegistered_WhenFalse_ShouldHaveValidationError()
        {
            // Arrange
            var model = new RegistrationResult();
            model.SetIsRegistered(false);

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.IsRegistered)
                .WithErrorMessage("Registration failed.");
        }

        [Fact]
        [Test]
        public void ErrorMessage_WhenEmptyAndNotRegistered_ShouldHaveValidationError()
        {
            // Arrange
            var model = new RegistrationResult();
            model.SetIsRegistered(false);
            model.SetErrorMessage("");

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ErrorMessage)
                .WithErrorMessage("Error message cannot be empty if registration failed.");
        }

        [Fact]
        [Test]
        public void ErrorMessage_WhenNotEmptyAndRegistered_ShouldHaveValidationError()
        {
            // Arrange
            var model = new RegistrationResult();
            model.SetIsRegistered(true);
            model.SetErrorMessage("Some error message");

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ErrorMessage)
                .WithErrorMessage("Error message must be empty if registration succeeded.");
        }

        [Fact]
        [Test]
        public void IsRegistered_WhenTrue_ShouldNotHaveValidationError()
        {
            // Arrange
            var model = new RegistrationResult();
            model.SetIsRegistered(true);

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.IsRegistered);
        }

        [Fact]
        [Test]
        public void ErrorMessage_WhenEmptyAndRegistered_ShouldNotHaveValidationError()
        {
            // Arrange
            var model = new RegistrationResult();
            model.SetIsRegistered(true);
            model.SetErrorMessage("");

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.ErrorMessage);
        }

        [Fact]
        [Test]
        public void ErrorMessage_WhenNotEmptyAndNotRegistered_ShouldNotHaveValidationError()
        {
            // Arrange
            var model = new RegistrationResult();
            model.SetIsRegistered(false);
            model.SetErrorMessage("Some error message");

            // Act
            var result = _validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.ErrorMessage);
        }
    }
}
