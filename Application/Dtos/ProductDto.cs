using System.ComponentModel;
using Application.Dtos.ObjectsValues.ProductObjectValue;
using Domain.Entities;
using Domain.Entities.Reviews;

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
    public ICollection<Review>? Reviews { get; set; }

    public DataDtoObjectValue? DataObjectValue { get; set; }
    public FlagsDtoObjectValue? FlagsObjectValue { get; set; }
    public PriceDtoObjectValue? PriceObjectValue { get; set; }
    public SpecificationDtoObjectValue? SpecificationObjectValue { get; set; }
    public WarrantyDtoObjectValue? WarrantyObjectValue { get; set; }
    public CommonPropertiesDtoObjectValue? CommonPropertiesObjectValue { get; set; }
}