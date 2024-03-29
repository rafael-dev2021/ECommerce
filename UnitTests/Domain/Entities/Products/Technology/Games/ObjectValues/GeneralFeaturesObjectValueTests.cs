using Domain.Entities.Products.Technology.Games.ObjectValues;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Products.Technology.Games.ObjectValues;
using Xunit;

namespace UnitTests.Domain.Entities.Products.Technology.Games.ObjectValues;

[TestFixture]
public class GeneralFeaturesObjectValueTests
{
    private readonly GeneralFeaturesObjectValueValidator _validator = new();


    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_Collection_Is_Valid()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetCollection("Collection 1");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Collection);
    }


    [Fact]
    [Test]
    public void Should_Have_Error_When_Collection_Is_Empty()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetCollection("");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Collection)
            .WithErrorMessage("Collection cannot be empty.");
    }


    [Fact]
    [Test]
    public void Should_Have_Error_When_Collection_Exceeds_Maximum_Length()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetCollection("This is a very long collection name that exceeds the maximum allowed length");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Collection)
            .WithErrorMessage("Collection must have a maximum length of 25 characters.");
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_Saga_Is_Valid()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetSaga("Saga 1");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Saga);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_Saga_Is_Empty()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetSaga("");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Saga)
            .WithErrorMessage("Saga cannot be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_Saga_Exceeds_Maximum_Length()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetSaga("This is a very long saga name that exceeds the maximum allowed length");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Saga)
            .WithErrorMessage("Saga must have a maximum length of 40 characters.");
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_Title_Is_Valid()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetTitle("Game Title");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Title);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_Title_Is_Empty()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetTitle("");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage("Title cannot be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_Title_Exceeds_Maximum_Length()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetTitle("This is a very long title that exceeds the maximum allowed length");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage("Title must have a maximum length of 50 characters.");
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_Edition_Is_Valid()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetEdition("First Edition");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Edition);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_Edition_Is_Empty()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetEdition("");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Edition)
            .WithErrorMessage("Edition cannot be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_Edition_Exceeds_Maximum_Length()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetEdition("This is a very long edition name that exceeds the maximum allowed length");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Edition)
            .WithErrorMessage("Edition must have a maximum length of 25 characters.");
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_Platform_Is_Valid()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetPlatform("PlayStation");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Platform);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_Platform_Is_Empty()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetPlatform("");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Platform)
            .WithErrorMessage("Platform cannot be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_Platform_Exceeds_Maximum_Length()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetPlatform("This is a very long platform name that exceeds the maximum allowed length");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Platform)
            .WithErrorMessage("Platform must have a maximum length of 15 characters.");
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_Developers_Is_Valid()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetDevelopers("Developer 1");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Developers);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_Developers_Is_Empty()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetDevelopers("");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Developers)
            .WithErrorMessage("Developers cannot be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_Developers_Exceeds_Maximum_Length()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetDevelopers("This is a very long developers name that exceeds the maximum allowed length");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Developers)
            .WithErrorMessage("Developers must have a maximum length of 40 characters.");
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_Publishers_Is_Valid()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetPublishers("Publisher 1");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Publishers);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_Publishers_Is_Empty()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetPublishers("");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Publishers)
            .WithErrorMessage("Publishers cannot be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_Publishers_Exceeds_Maximum_Length()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetPublishers("This is a very long publishers name that exceeds the maximum allowed length");
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Publishers)
            .WithErrorMessage("Publishers must have a maximum length of 15 characters.");
    }
    
    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_GameRating_Is_Valid()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetGameRating('A');
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.GameRating);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_GameRating_Is_Empty()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetGameRating('\0');
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.GameRating)
            .WithErrorMessage("Game rating cannot be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_GameRating_Is_Not_Uppercase_Letter()
    {
        // Arrange
        var generalFeatures = new GeneralFeaturesObjectValue();
        generalFeatures.SetGameRating('1');
        // Act
        var result = _validator.TestValidate(generalFeatures);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.GameRating)
            .WithErrorMessage("Game rating must be a valid uppercase letter (A-Z).");
    }

}