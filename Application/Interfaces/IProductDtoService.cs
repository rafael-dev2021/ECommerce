﻿using Application.Dtos;

namespace Application.Interfaces;

public interface IProductDtoService
{
    Task<IEnumerable<ProductDto>> GetProductsDtoAsync();
    Task<IEnumerable<ProductDto>> GetProductsDtoFavoritesAsync();
    Task<IEnumerable<ProductDto>> GetProductsDtoDailyOffersAsync();
    Task<IEnumerable<ProductDto>> GetProductsDtoBestSellersAsync();
    Task<IEnumerable<ProductDto>> GetProductsDtoByCategoriesAsync(string categoryStr);
    Task<IEnumerable<ProductDto>> GetSearchProductsDtoAsync(string keyword);
    Task<ProductDto> GetByIdAsync(int? id); 
}