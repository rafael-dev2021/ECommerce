using Application.Dtos;
using Application.Dtos.CartDto;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.CartDto;

public class ShoppingCartItemDtoTests
{
    [Fact]
    public void ShoppingCartItemDto_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        int id = 1;
        int productId = 101;
        ProductDto product = new ProductDto();
        int categoryId = 201;
        CategoryDto category = new CategoryDto(1, "", "", true);
        int quantity = 3;

        // Act
        var shoppingCartItemDto = new ShoppingCartItemDto(id, productId, product, categoryId, category, quantity);

        // Assert
        Assert.Equal(id, shoppingCartItemDto.Id);
        Assert.Equal(productId, shoppingCartItemDto.ProductId);
        Assert.Equal(product, shoppingCartItemDto.Product);
        Assert.Equal(categoryId, shoppingCartItemDto.CategoryId);
        Assert.Equal(category, shoppingCartItemDto.Category);
        Assert.Equal(quantity, shoppingCartItemDto.Quantity);
    }
}
