using Domain.Entities.Products.Technology.Games.ObjectValues;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.Products.Technology.Games.ObjectValues;
using Xunit;

namespace UnitTests.Domain.Entities.Products.Technology.Games.ObjectValues;

[TestFixture]
public class MediaSpecificationObjectValueTests
{ 
    private readonly MediaSpecificationObjectValueValidator _validator = new();

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_Format_Is_Valid()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetFormat("DVD");
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Format);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_Format_Is_Empty()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetFormat("");
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Format)
            .WithErrorMessage("Format cannot be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_Format_Exceeds_Maximum_Length()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetFormat("Blu-ray Disc lorem ipsum dolor sit amet");
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Format)
            .WithErrorMessage("Format must have a maximum length of 20 characters.");
    }


    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_AudioLanguages_Is_Valid()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetAudioLanguages("English, Spanish");
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.AudioLanguages);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_AudioLanguages_Is_Empty()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetAudioLanguages("");
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.AudioLanguages)
            .WithErrorMessage("Audio languages cannot be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_AudioLanguages_Exceeds_Maximum_Length()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetAudioLanguages(
            "English, Spanish, French, German, Italian, Portuguese, Chinese, Japanese, Korean, Russian, Arabic, Hindi, Bengali, Urdu, Swahili");
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.AudioLanguages)
            .WithErrorMessage("Audio languages must have a maximum length of 50 characters.");
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_SubtitleLanguages_Is_Valid()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetSubtitleLanguages("English, Spanish");
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.SubtitleLanguages);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_SubtitleLanguages_Is_Empty()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetSubtitleLanguages("");
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.SubtitleLanguages)
            .WithErrorMessage("Subtitle languages cannot be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_SubtitleLanguages_Exceeds_Maximum_Length()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetSubtitleLanguages("English, Spanish, French, German, Italian, Portuguese");
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.SubtitleLanguages)
            .WithErrorMessage("Subtitle languages must have a maximum length of 30 characters.");
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_ScreenLanguages_Is_Valid()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetScreenLanguages("English, Spanish");
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.ScreenLanguages);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_ScreenLanguages_Is_Empty()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetScreenLanguages("");
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ScreenLanguages)
            .WithErrorMessage("Screen languages cannot be empty.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_ScreenLanguages_Exceeds_Maximum_Length()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetScreenLanguages("English, Spanish, French, German, Italian");
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.ScreenLanguages)
            .WithErrorMessage("Screen languages must have a maximum length of 30 characters.");
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_MaximumNumberOfOfflinePlayers_Is_Greater_Or_Equal_To_Zero()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetMaximumNumberOfOfflinePlayers(1);
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.MaximumNumberOfOfflinePlayers);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_MaximumNumberOfOfflinePlayers_Is_Less_Than_Zero()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetMaximumNumberOfOfflinePlayers(-1);
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MaximumNumberOfOfflinePlayers)
            .WithErrorMessage("Maximum number of offline players must be greater than or equal to zero.");
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_MaximumNumberOfOnlinePlayers_Is_Greater_Or_Equal_To_Zero()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetMaximumNumberOfOnlinePlayers(1);
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.MaximumNumberOfOnlinePlayers);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_MaximumNumberOfOnlinePlayers_Is_Less_Than_Zero()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetMaximumNumberOfOnlinePlayers(-1);
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.MaximumNumberOfOnlinePlayers)
            .WithErrorMessage("Maximum number of online players must be greater than or equal to zero.");
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_FileSize_Is_Greater_Or_Equal_To_Zero()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetFileSize(10);
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.FileSize);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_FileSize_Is_Less_Than_Zero()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetFileSize(-10);
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.FileSize)
            .WithErrorMessage("File size must be greater than or equal to zero.");
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_IsMultiplayer_Is_Valid()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetIsMultiplayer(true);
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.IsMultiplayer);
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_IsOnline_Is_Valid()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetIsOnline(true);
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.IsOnline);
    }

    [Fact]
    [Test]
    public void Should_Not_Have_Error_When_IsOffline_Is_Valid()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetIsOffline(true);
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.IsOffline);
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_IsMultiplayer_Is_Invalid()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetIsMultiplayer(false);
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.IsMultiplayer)
            .WithErrorMessage("Is multiplayer must be true or false.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_IsOnline_Is_Invalid()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetIsOnline(false);
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.IsOnline)
            .WithErrorMessage("Is online must be true or false.");
    }

    [Fact]
    [Test]
    public void Should_Have_Error_When_IsOffline_Is_Invalid()
    {
        // Arrange
        var mediaSpecificationObjectValue = new MediaSpecificationObjectValue();
        mediaSpecificationObjectValue.SetIsOffline(false);
        // Act
        var result = _validator.TestValidate(mediaSpecificationObjectValue);
        // Assert
        result.ShouldHaveValidationErrorFor(x => x.IsOffline)
            .WithErrorMessage("Is offline must be true or false.");
    }
}