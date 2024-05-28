using Application.Dtos;
using Application.Dtos.Products.Technology.Games;
using Application.Dtos.Products.Technology.Smartphones;

namespace Application.Services.GetMatchingProducts.Technology;

public class GetMatchingProductsDtoTechnology
{
    public ProductDto? ProductDto { get; set; }
    public required IEnumerable<SmartphoneDto> SmartphonesDto { get; set; }
    public required IEnumerable<GameDto> GamesDto { get; set; }

    public IEnumerable<T> GetMatchingProducts<T>(IEnumerable<T> productsDto) where T : ProductDto
    {
        return productsDto
            .Where(x =>
            x.SpecificationObjectValue?.Model == ProductDto?.SpecificationObjectValue?.Model &&
            x.Category?.Name == ProductDto?.Category?.Name);
    }
    public IEnumerable<SmartphoneDto> GetMatchingSmartphonesDto()
    {
        return GetMatchingProducts(SmartphonesDto);
    }

    public IEnumerable<GameDto> GetMatchingGamesDto()
    {
        return GetMatchingProducts(GamesDto);
    }
}
