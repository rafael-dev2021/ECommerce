﻿using Application.Dtos;
using Application.Dtos.CartDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Entities;

public class ShoppingCartItemDtoService(IShoppingCartItemRepository repository, IMapper mapper) : IShoppingCartItemDtoService
{
    private readonly IShoppingCartItemRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ShoppingCartItemDto>> GetShoppingCartItemsDtoAsync()
    {
        var getCartItems = await _repository.GetShoppingCartItemsAsync();

        if (getCartItems == null || !getCartItems.Any()) return [];

        return _mapper.Map<IEnumerable<ShoppingCartItemDto>>(getCartItems);
    }

    public async Task<decimal> GetTotalAmountCartServiceAsync()
    {
        return await _repository.GetTotalAmountCartAsync();
    }

    public async Task<int> GetTotalCartItemsServiceAsync()
    {
        return await _repository.GetTotalCartItemsAsync();
    }

    public async Task RemoveItemServiceAsync(ProductDto productDto)
    {
        ProductDtoNull(productDto);

        var product = _mapper.Map<Product>(productDto) ?? throw new Exception("Error removing product.");
        await _repository.RemoveItemAsync(product);
    }


    public async Task AddCartItemAsync(ProductDto productDto, CategoryDto categoryDto)
    {
        ProductDtoNull(productDto);

        CategoryDtoNull(categoryDto);

        var addProduct = _mapper.Map<Product>(productDto);

        var addCategory = _mapper.Map<Category>(categoryDto);

        if (addProduct == null)
            throw new Exception("Error adding product to cart.");

        await _repository.AddItemToCartAsync(addProduct, addCategory);
    }

    public async Task RemoveItemCartServiceAsync(ProductDto productDto, CategoryDto categoryDto)
    {
        ProductDtoNull(productDto);

        CategoryDtoNull(categoryDto);

        var removeProduct = _mapper.Map<Product>(productDto);

        var removeCategory = _mapper.Map<Category>(categoryDto);

        if (removeProduct == null)
            throw new Exception("Error removing product.");

        await _repository.RemoveItemToCartAsync(removeProduct, removeCategory);
    }

    public async Task ClearShoppingCartServiceAsync()
    {
        try
        {
            await _repository.ClearShoppingCartAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error clearing the shopping cart.", ex);
        }
    }

    private static void ProductDtoNull(ProductDto productDto)
    {
        if (productDto == null)
            throw new ArgumentNullException(nameof(productDto), "ProductDto cannot be null.");
    }

    private static void CategoryDtoNull(CategoryDto categoryDto)
    {
        if (categoryDto == null)
            throw new ArgumentNullException(nameof(categoryDto), "CategoryDto cannot be null.");
    }
}