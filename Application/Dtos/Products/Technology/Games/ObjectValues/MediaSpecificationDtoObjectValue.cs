namespace Application.Dtos.Products.Technology.Games.ObjectValues;

public record MediaSpecificationDtoObjectValue(
    string Format,
    string AudioLanguages,
    string SubtitleLanguages,
    string ScreenLanguages,
    int MaximumNumberOfOfflinePlayers,
    int MaximumNumberOfOnlinePlayers,
    int FileSize,
    bool IsMultiplayer,
    bool IsOnline,
    bool IsOffline);