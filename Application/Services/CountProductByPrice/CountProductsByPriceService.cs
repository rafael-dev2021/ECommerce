﻿using Application.Interfaces;
using Application.Services.CountProductByPrice.Interfaces;

namespace Application.Services.CountProductByPrice;

public class CountProductsByPriceService(IProductDtoService productDtoService) : ICountProductsByPriceService
{
    private readonly IProductDtoService _productDtoService = productDtoService;

    public async Task<int> CountingProductsAboveOrBelowPriceAsync(decimal price, decimal secondPrice)
    {
        var listProducts = await _productDtoService.GetProductsDtoAsync();
        var count = listProducts
            .Count(x => x.PriceObjectValue?.Price >= price && x.PriceObjectValue.Price <= secondPrice);

        return count;
    }

    public async Task<int> CountingProductsBelowPriceAsync(decimal price)
    {
        var listProducts = await _productDtoService.GetProductsDtoAsync();
        var count = listProducts.Count(x => x.PriceObjectValue?.Price <= price);
        return count;
    }

    public async Task<int> CountingProductsAbovePriceAsync(decimal price)
    {
        var listProducts = await _productDtoService.GetProductsDtoAsync();
        var count = listProducts.Count(x => x.PriceObjectValue?.Price >= price);
        return count;
    }
}
