namespace Application.Dtos.Products.Technology.Games.ObjectValues;

public record RequirementDtoObjectValue(
    int MinimumRamRequirementInMb,
    string MinimumOperatingSystemsRequired,
    string MinimumGraphicsProcessorsRequired,
    string MinimumProcessorsRequired);