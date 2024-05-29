using Application.Dtos.Products.Fashion.T_Shirts.ObjectValues;

namespace Application.Dtos.Products.Fashion.T_Shirts;

public record ShirtDto : ProductDto
{
    public MainFeaturesDtoObjectValue? MainFeaturesObjectValue { get; set; }
    public OtherFeaturesDtoObjectValue? OtherFeaturesObjectValue { get; set; }
}