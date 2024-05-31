using Application.CustomExceptions;
using Application.Dtos;
using Application.Dtos.CartDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.Entities;

public class ShoppingCartItemDtoService(IShoppingCartItemRepository repository, IMapper mapper) : IShoppingCartItemDtoService
{
    public async Task<IEnumerable<ShoppingCartItemDto>> GetShoppingCartItemsDtoAsync()
    {
        var getCartItems = await repository.GetShoppingCartItemsAsync();

        return !getCartItems.Any() ? [] : mapper.Map<IEnumerable<ShoppingCartItemDto>>(getCartItems);
    }

    public async Task<decimal> GetTotalAmountCartServiceAsync()
    {
        return await repository.GetTotalAmountCartAsync();
    }

    public async Task<int> GetTotalCartItemsServiceAsync()
    {
        return await repository.GetTotalCartItemsAsync();
    }

    public async Task RemoveItemServiceAsync(ProductDto productDto)
    {
        ProductDtoNull(productDto);

        var product = mapper.Map<Product>(productDto) ??
            throw new ShoppingCartItemException("Error removing product.");

        await repository.RemoveItemAsync(product);
    }


    public async Task AddCartItemAsync(ProductDto productDto, CategoryDto categoryDto)
    {
        ProductDtoNull(productDto);

        CategoryDtoNull(categoryDto);

        var addProduct = mapper.Map<Product>(productDto);

        var addCategory = mapper.Map<Category>(categoryDto);

        if (addProduct == null)
            throw new ShoppingCartItemException("Error adding product to cart.");

        await repository.AddItemToCartAsync(addProduct, addCategory);
    }

    public async Task RemoveItemCartServiceAsync(ProductDto productDto, CategoryDto categoryDto)
    {
        ProductDtoNull(productDto);

        CategoryDtoNull(categoryDto);

        var removeProduct = mapper.Map<Product>(productDto);

        var removeCategory = mapper.Map<Category>(categoryDto);

        if (removeProduct == null)
            throw new ShoppingCartItemException("Error removing product.");

        await repository.RemoveItemToCartAsync(removeProduct, removeCategory);
    }

    public async Task ClearShoppingCartServiceAsync()
    {
        try
        {
            await repository.ClearShoppingCartAsync();
        }
        catch (Exception ex)
        {
            throw new ShoppingCartItemException("Error clearing the shopping cart.", ex);
        }
    }

    public static void ProductDtoNull(ProductDto? productDto)
    {
        if (productDto == null)
            throw new ArgumentNullException(nameof(productDto), "ProductDto cannot be null.");
    }

    public static void CategoryDtoNull(CategoryDto? categoryDto)
    {
        if (categoryDto == null)
            throw new ArgumentNullException(nameof(categoryDto), "CategoryDto cannot be null.");
    }
}