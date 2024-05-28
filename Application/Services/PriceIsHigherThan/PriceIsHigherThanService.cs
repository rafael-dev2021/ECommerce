using Application.Dtos;
using Application.Interfaces;
using Application.Services.PriceIsHigherThan.Interfaces;

namespace Application.Services.PriceIsHigherThan;

public class PriceIsHigherThanService(IProductDtoService productDtoService) : IPriceIsHigherThanService
{
    private readonly IProductDtoService _productDtoService = productDtoService;

    public async Task<IEnumerable<ProductDto>> GetProductsAboveOrBelowPriceAsync(decimal price, decimal secondPrice)
    {
        var listProducts = await _productDtoService.GetProductsDtoAsync();
        var filteredProducts = listProducts
            .Where(x =>
            x.PriceObjectValue?.Price >= price &&
            x.PriceObjectValue?.Price <= secondPrice)
            .ToList();

        return filteredProducts;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAbovePriceAsync(decimal price)
    {
        var listProducts = await _productDtoService.GetProductsDtoAsync();
        var filteredProducts = listProducts
            .Where(x => x.PriceObjectValue?.Price >= price)
            .ToList();

        return filteredProducts;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsBelowPriceAsync(decimal price)
    {
        var listProducts = await _productDtoService.GetProductsDtoAsync();
        var filteredProducts = listProducts
            .Where(x => x.PriceObjectValue?.Price <= price)
            .ToList();

        return filteredProducts;
    }
}
