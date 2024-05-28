using Application.Dtos;
using Application.Dtos.Products.Fashion.Shoes;
using Application.Dtos.Products.Fashion.T_Shirts;

namespace Application.Services.GetMatchingProducts.Fashion;

public class GetMatchingProductsDtoFashion
{
    public ProductDto? ProductDto { get; set; }
    public required IEnumerable<ShirtDto> TshirtsDto { get; set; }
    public required IEnumerable<ShoeDto> ShoesDto { get; set; }

    public IEnumerable<T> GetMatchingProducts<T>(IEnumerable<T> productsDto) where T : ProductDto
    {
        return productsDto
            .Where(x =>
            x.SpecificationObjectValue?.Model == ProductDto?.SpecificationObjectValue?.Model &&
            x.Category?.Name == ProductDto?.Category?.Name);
    }
    public IEnumerable<ShirtDto> GetMatchingTshirtDto()
    {
        return GetMatchingProducts(TshirtsDto);
    }
    public IEnumerable<ShoeDto> GetMatchingShoesDto()
    {
        return GetMatchingProducts(ShoesDto);
    }
}
