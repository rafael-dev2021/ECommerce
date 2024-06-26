﻿using Application.CustomExceptions;
using Application.Dtos;
using Application.Dtos.CartDto;
using Application.Services.Entities;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Cart;
using Domain.Interfaces;
using NSubstitute;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Services.Entities;

public class ShoppingCartItemDtoServiceTests
{
    private readonly IShoppingCartItemRepository _repository;
    private readonly IMapper _mapper;
    private readonly ShoppingCartItemDtoService _shoppingCartItemDtoService;

    public ShoppingCartItemDtoServiceTests()
    {
        _repository = Substitute.For<IShoppingCartItemRepository>();
        _mapper = Substitute.For<IMapper>();
        _shoppingCartItemDtoService = new ShoppingCartItemDtoService(_repository, _mapper);
    }

    public class GetShoppingCartItemsDtoAsyncTests : ShoppingCartItemDtoServiceTests
    {
        [Fact]
        public async Task GetShoppingCartItemsDtoAsync_ReturnsMappedCartItems_WhenCartItemsExist()
        {
            // Arrange
            var cartItems = new List<ShoppingCartItem> { new() };
            var cartItemDtos = new List<ShoppingCartItemDto>
            {
                new(
                    1,
                    1,
                    new ProductDto(),
                    1,
                    new CategoryDto(1, "", "", true),
                    1)
            };

            _repository.GetShoppingCartItemsAsync().Returns(cartItems);
            _mapper.Map<IEnumerable<ShoppingCartItemDto>>(cartItems).Returns(cartItemDtos);

            // Act
            var result = await _shoppingCartItemDtoService.GetShoppingCartItemsDtoAsync();

            // Assert
            Assert.NotNull(result);
            var shoppingCartItemDtos = result as ShoppingCartItemDto[] ?? result.ToArray();
            Assert.Single(shoppingCartItemDtos);
            Assert.Equal(cartItemDtos, shoppingCartItemDtos);
        }

        [Fact]
        public async Task GetShoppingCartItemsDtoAsync_ReturnsEmptyList_WhenNoCartItemsExist()
        {
            // Arrange
            _repository.GetShoppingCartItemsAsync().Returns(new List<ShoppingCartItem>());

            // Act
            var result = await _shoppingCartItemDtoService.GetShoppingCartItemsDtoAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }

    public class AddCartItemAsyncTests : ShoppingCartItemDtoServiceTests
    {
        [Fact]
        public async Task AddCartItemAsync_CallsRepositoryAddItemToCartAsync_WhenProductAndCategoryAreValid()
        {
            // Arrange
            var productDto = new ProductDto { Id = 1, Name = "Test Product" };
            var categoryDto = new CategoryDto(1, "Test Category", "", true);
            var product = new Product(1, "Test Product", "Description", [], 1, 1);
            var category = new Category(1, "Test Category", "", true);

            _mapper.Map<Product>(productDto).Returns(product);
            _mapper.Map<Category>(categoryDto).Returns(category);

            // Act
            await _shoppingCartItemDtoService.AddCartItemAsync(productDto, categoryDto);

            // Assert
            await _repository.Received(1).AddItemToCartAsync(product, category);
        }

        [Fact]
        public async Task AddCartItemAsync_ThrowsShoppingCartItemException_WhenProductIsNull()
        {
            // Arrange
            var productDto = new ProductDto();
            var categoryDto = new CategoryDto(1, "", "", true);

            // Act & Assert
            await Assert.ThrowsAsync<ShoppingCartItemException>(async () =>
                await _shoppingCartItemDtoService.AddCartItemAsync(productDto, categoryDto));
        }
    }

    public class RemoveItemCartServiceAsyncTests : ShoppingCartItemDtoServiceTests
    {
        [Fact]
        public async Task
            RemoveItemCartServiceAsync_CallsRepositoryRemoveItemToCartAsync_WhenProductAndCategoryAreValid()
        {
            // Arrange
            var productDto = new ProductDto { Id = 1, Name = "Test Product" };
            var categoryDto = new CategoryDto(1, "Test Category", "", true);
            var product = new Product(1, "Test Product", "Description", [], 1, 1);
            var category = new Category(1, "Test Category", "", true);

            _mapper.Map<Product>(productDto).Returns(product);
            _mapper.Map<Category>(categoryDto).Returns(category);

            // Act
            await _shoppingCartItemDtoService.RemoveItemCartServiceAsync(productDto, categoryDto);

            // Assert
            await _repository.Received(1).RemoveItemToCartAsync(product, category);
        }

        [Fact]
        public async Task RemoveItemCartServiceAsync_ThrowsException_WhenProductIsNull()
        {
            // Arrange
            var productDto = new ProductDto();
            var categoryDto = new CategoryDto(1, "Test Category", "", true);

            // Act & Assert
            await Assert.ThrowsAsync<ShoppingCartItemException>(async () =>
                await _shoppingCartItemDtoService.RemoveItemCartServiceAsync(productDto, categoryDto));
        }
    }

    public class RemoveItemServiceAsyncTests : ShoppingCartItemDtoServiceTests
    {
        [Fact]
        public async Task RemoveItemServiceAsync_CallsRepositoryRemoveItemAsync_WhenProductIsValid()
        {
            // Arrange
            var productDto = new ProductDto { Id = 1, Name = "Test Product" };
            var product = new Product(1, "Test Product", "Description", [], 1, 1);

            _mapper.Map<Product>(productDto).Returns(product);

            // Act
            await _shoppingCartItemDtoService.RemoveItemServiceAsync(productDto);

            // Assert
            await _repository.Received(1).RemoveItemAsync(product);
        }

        [Fact]
        public async Task RemoveItemServiceAsync_ThrowsShoppingCartItemException_WhenProductIsNull()
        {
            // Arrange
            var productDto = new ProductDto();

            // Act & Assert
            await Assert.ThrowsAsync<ShoppingCartItemException>(async () =>
                await _shoppingCartItemDtoService.RemoveItemServiceAsync(productDto));
        }
    }

    public class ClearShoppingCartServiceAsyncTests : ShoppingCartItemDtoServiceTests
    {
        [Fact]
        public async Task ClearShoppingCartServiceAsync_CallsRepositoryClearShoppingCartAsync()
        {
            // Act
            await _shoppingCartItemDtoService.ClearShoppingCartServiceAsync();

            // Assert
            await _repository.Received(1).ClearShoppingCartAsync();
        }

        [Fact]
        public async Task ClearShoppingCartServiceAsync_ThrowsException_WhenRepositoryFails()
        {
            // Arrange
            _repository.ClearShoppingCartAsync().Returns(Task.FromException(new Exception("Test Exception")));

            // Act & Assert
            await Assert.ThrowsAsync<ShoppingCartItemException>(_shoppingCartItemDtoService
                .ClearShoppingCartServiceAsync);
        }
    }

    public class ProductDtoNullTests
    {
        [Fact]
        public void ProductDtoNull_ShouldThrowArgumentNullException_WhenProductDtoIsNull()
        {
            // Arrange
            ProductDto? productDto = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => ShoppingCartItemDtoService.ProductDtoNull(productDto));
        }

        [Fact]
        public void ProductDtoNull_ShouldNotThrowException_WhenProductDtoIsNotNull()
        {
            // Arrange
            var productDto = new ProductDto();

            // Act & Assert
            Assert.Null(Record.Exception(() => ShoppingCartItemDtoService.ProductDtoNull(productDto)));
        }
    }

    public class CategoryDtoNullTests
    {
        [Fact]
        public void CategoryDtoNull_ShouldThrowArgumentNullException_WhenCategoryDtoIsNull()
        {
            // Arrange
            CategoryDto? categoryDto = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => ShoppingCartItemDtoService.CategoryDtoNull(categoryDto));
        }

        [Fact]
        public void CategoryDtoNull_ShouldNotThrowException_WhenCategoryDtoIsNotNull()
        {
            // Arrange
            var categoryDto = new CategoryDto(1, "", "", true);

            // Act & Assert
            Assert.Null(Record.Exception(() => ShoppingCartItemDtoService.CategoryDtoNull(categoryDto)));
        }
    }

    [Fact]
    public async Task GetTotalAmountCartServiceAsync_ReturnsTotalAmount()
    {
        // Arrange
        const decimal totalAmount = 100.00m;
        _repository.GetTotalAmountCartAsync().Returns(totalAmount);

        // Act
        var result = await _shoppingCartItemDtoService.GetTotalAmountCartServiceAsync();

        // Assert
        Assert.Equal(totalAmount, result);
    }

    [Fact]
    public async Task GetTotalCartItemsServiceAsync_ReturnsTotalItems()
    {
        // Arrange
        const int totalItems = 5;
        _repository.GetTotalCartItemsAsync().Returns(totalItems);

        // Act
        var result = await _shoppingCartItemDtoService.GetTotalCartItemsServiceAsync();

        // Assert
        Assert.Equal(totalItems, result);
    }
}