using Application.Dtos.Products.Technology.Games.ObjectValues;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.Products.Technology.Games.ObjectValues;

public class MediaSpecificationDtoObjectValueTests
{
    [Fact]
    public void MediaSpecificationDtoObjectValue_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string format = "DVD";
        string audioLanguages = "English, French";
        string subtitleLanguages = "English, French";
        string screenLanguages = "English, French";
        int maximumNumberOfOfflinePlayers = 1;
        int maximumNumberOfOnlinePlayers = 4;
        int fileSize = 5000;
        bool isMultiplayer = true;
        bool isOnline = true;
        bool isOffline = true;

        // Act
        var mediaSpecificationDtoObjectValue = new MediaSpecificationDtoObjectValue(format, audioLanguages, subtitleLanguages, screenLanguages, maximumNumberOfOfflinePlayers, maximumNumberOfOnlinePlayers, fileSize, isMultiplayer, isOnline, isOffline);

        // Assert
        Assert.Equal(format, mediaSpecificationDtoObjectValue.Format);
        Assert.Equal(audioLanguages, mediaSpecificationDtoObjectValue.AudioLanguages);
        Assert.Equal(subtitleLanguages, mediaSpecificationDtoObjectValue.SubtitleLanguages);
        Assert.Equal(screenLanguages, mediaSpecificationDtoObjectValue.ScreenLanguages);
        Assert.Equal(maximumNumberOfOfflinePlayers, mediaSpecificationDtoObjectValue.MaximumNumberOfOfflinePlayers);
        Assert.Equal(maximumNumberOfOnlinePlayers, mediaSpecificationDtoObjectValue.MaximumNumberOfOnlinePlayers);
        Assert.Equal(fileSize, mediaSpecificationDtoObjectValue.FileSize);
        Assert.Equal(isMultiplayer, mediaSpecificationDtoObjectValue.IsMultiplayer);
        Assert.Equal(isOnline, mediaSpecificationDtoObjectValue.IsOnline);
        Assert.Equal(isOffline, mediaSpecificationDtoObjectValue.IsOffline);
    }
}
