namespace Domain.Entities.Products.Technology.Games.ObjectValues;

public class MediaSpecificationObjectValue
{
    public string Format { get; private set; } = string.Empty;
    public string AudioLanguages { get; private set; } = string.Empty;
    public string SubtitleLanguages { get; private set; } = string.Empty;
    public string ScreenLanguages { get; private set; } = string.Empty;
    public int MaximumNumberOfOfflinePlayers { get; private set; }
    public int MaximumNumberOfOnlinePlayers { get; private set; }
    public int FileSize { get; private set; }
    public bool IsMultiplayer { get; private set; }
    public bool IsOnline { get; private set; }
    public bool IsOffline { get; private set; }

    public void SetFormat(string format) => Format = format;
    public void SetAudioLanguages(string audioLanguages) => AudioLanguages = audioLanguages;
    public void SetSubtitleLanguages(string subtitleLanguages) => SubtitleLanguages = subtitleLanguages;
    public void SetScreenLanguages(string screenLanguages) => ScreenLanguages = screenLanguages;

    public void SetMaximumNumberOfOfflinePlayers(int maximumNumberOfOfflinePlayers) =>
        MaximumNumberOfOfflinePlayers = maximumNumberOfOfflinePlayers;

    public void SetMaximumNumberOfOnlinePlayers(int maximumNumberOfOnlinePlayers) =>
        MaximumNumberOfOnlinePlayers = maximumNumberOfOnlinePlayers;

    public void SetFileSize(int fileSize) => FileSize = fileSize;
    public void SetIsMultiplayer(bool isMultiplayer) => IsMultiplayer = isMultiplayer;
    public void SetIsOnline(bool isOnline) => IsOnline = isOnline;
    public void SetIsOffline(bool isOffline) => IsOffline = isOffline;
}