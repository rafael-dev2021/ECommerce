using Application.Dtos.Products.Technology.Games.ObjectValues;

namespace Application.Dtos.Products.Technology.Games;

public record GameDto
{
    public GeneralFeaturesDtoObjectValue? GeneralFeaturesObjectValue { get; set; }
    public MediaSpecificationDtoObjectValue? MediaSpecificationObjectValue { get; set; }
    public RequirementDtoObjectValue? RequirementObjectValue { get; set; }
}