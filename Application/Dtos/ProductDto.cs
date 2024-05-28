using Application.Dtos.ObjectsValues.ProductObjectValue;
using Application.Dtos.Reviews;
using Application.Services.CalculateWeightedAverageReviews;
using Application.Services.CalculateWeightedAverageReviews.ObjectValues;
using Application.Services.Discounts;
using Domain.Entities;
using System.ComponentModel;

namespace Application.Dtos;

public record ProductDto
{
    public int Id { get; set; }
    [DisplayName("Name")] public string? Name { get; set; }
    [DisplayName("Description")] public string? Description { get; set; } 
    [DisplayName("Images")] public List<string>? ImagesUrl { get; set; } 
    [DisplayName("Stock")] public int Stock { get; set; }
    [DisplayName("Categories")] public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public required ICollection<ReviewDto> Reviews { get; set; }

    public DataDtoObjectValue? DataObjectValue { get; set; }
    public FlagsDtoObjectValue? FlagsObjectValue { get; set; }
    public PriceDtoObjectValue? PriceObjectValue { get; set; }
    public SpecificationDtoObjectValue? SpecificationObjectValue { get; set; }
    public WarrantyDtoObjectValue? WarrantyObjectValue { get; set; }
    public CommonPropertiesDtoObjectValue? CommonPropertiesObjectValue { get; set; }

    public static CalculateDiscountService CalculateDiscountService() => new();

    public WeightedAverageResultOV CalculateWeightedAverage()
    {
        var weightedAverageCalculator = new WeightedAverageCalculator();
        return weightedAverageCalculator.CalculateWeightedAverage(Reviews);
    }
}