using Application.Dtos;
using Application.Dtos.CartDto;
using Application.Mappings;
using AutoMapper;
using Domain.Entities.Cart;
using FluentAssertions;
using Xunit;

namespace UnitTests.Application.Mappings;

public class MappingTheShoppingCartProfileTests
{
    private readonly IMapper _mapper;

    public MappingTheShoppingCartProfileTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingTheShoppingCartProfile>();
            cfg.AddProfile<MappingTheProductProfile>();
            cfg.AddProfile<MappingTheCategoryProfile>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Should_Map_ShoppingCartItem_To_ShoppingCartItemDto()
    {
        // Arrange
        var shoppingCartItem = new ShoppingCartItem();
        shoppingCartItem.SetId(1);
        shoppingCartItem.SetProductId(2);
        shoppingCartItem.SetCategoryId(3);
        shoppingCartItem.SetQuantity(4);
        shoppingCartItem.SetShoppingCartId("ShoppingCart123");
        shoppingCartItem.SetUserId("User123");

        // Act
        var shoppingCartItemDto = _mapper.Map<ShoppingCartItemDto>(shoppingCartItem);

        // Assert
        shoppingCartItemDto.Id.Should().Be(shoppingCartItem.Id);
        shoppingCartItemDto.ProductId.Should().Be(shoppingCartItem.ProductId);
        shoppingCartItemDto.CategoryId.Should().Be(shoppingCartItem.CategoryId);
        shoppingCartItemDto.Quantity.Should().Be(shoppingCartItem.Quantity);
    }

    [Fact]
    public void Should_Map_ShoppingCartItemDto_To_ShoppingCartItem()
    {
        // Arrange
        var shoppingCartItemDto = new ShoppingCartItemDto(
            1,
            2,
            new ProductDto { Id = 2, Name = "ProductName" },
            3,
            new CategoryDto(1, "Category", "image.url", true),
            4
        );

        // Act
        var shoppingCartItem = _mapper.Map<ShoppingCartItem>(shoppingCartItemDto);

        // Assert
        shoppingCartItem.Id.Should().Be(shoppingCartItemDto.Id);
        shoppingCartItem.ProductId.Should().Be(shoppingCartItemDto.ProductId);
        shoppingCartItem.CategoryId.Should().Be(shoppingCartItemDto.CategoryId);
        shoppingCartItem.Quantity.Should().Be(shoppingCartItemDto.Quantity);
    }
}
