using Application.Dtos.Products.Fashion.Shoes.ObjectValues;

namespace Application.Dtos.Products.Fashion.Shoes;

public record ShoeDto
{
    public MaterialDtoObjectValue? MaterialObjectValue { get; set; }
}