using Application.Dtos;
using Application.Dtos.ObjectsValues.ProductObjectValue;
using Application.Interfaces;
using Application.Services.CountProductByPrice;
using NSubstitute;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.CountProductByPrice;

public class CountProductsByPriceServiceTests
{
    private static readonly IProductDtoService ProductDtoServiceMock = Substitute.For<IProductDtoService>();
    private readonly CountProductsByPriceService _countProductsByPriceService = new(ProductDtoServiceMock);

    [Fact]
    public async Task CountingProductsAboveOrBelowPriceAsync_ShouldReturnCorrectCount_WhenSomeProductsAreInPriceRange()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { PriceObjectValue = new PriceDtoObjectValue(30.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(60.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(90.0m, 0m) }
        };

        ProductDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAboveOrBelowPriceAsync(50.0m, 80.0m);

        // Assert
        Assert.Equal(1, count);
    }

    [Fact]
    public async Task CountingProductsAboveOrBelowPriceAsync_ShouldReturnZero_WhenNoProductsInPriceRange()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { PriceObjectValue = new PriceDtoObjectValue(30.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(40.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(90.0m, 0m) }
        };

        ProductDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAboveOrBelowPriceAsync(50.0m, 80.0m);

        // Assert
        Assert.Equal(0, count);
    }

    [Fact]
    public async Task CountingProductsBelowPriceAsync_ShouldReturnCorrectCount_WhenSomeProductsAreBelowPrice()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { PriceObjectValue = new PriceDtoObjectValue(30.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(60.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(90.0m, 0m) }
        };

        ProductDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsBelowPriceAsync(50.0m);

        // Assert
        Assert.Equal(1, count);
    }

    [Fact]
    public async Task CountingProductsBelowPriceAsync_ShouldReturnZero_WhenNoProductsAreBelowPrice()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { PriceObjectValue = new PriceDtoObjectValue(60.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(70.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(80.0m, 0m) }
        };

        ProductDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsBelowPriceAsync(50.0m);

        // Assert
        Assert.Equal(0, count);
    }

    [Fact]
    public async Task CountingProductsAbovePriceAsync_ShouldReturnCorrectCount_WhenSomeProductsAreAbovePrice()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { PriceObjectValue = new PriceDtoObjectValue(30.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(60.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(90.0m, 0m) }
        };

        ProductDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAbovePriceAsync(50.0m);

        // Assert
        Assert.Equal(2, count);
    }

    [Fact]
    public async Task CountingProductsAbovePriceAsync_ShouldReturnZero_WhenNoProductsAreAbovePrice()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { PriceObjectValue = new PriceDtoObjectValue(30.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(40.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(45.0m, 0m) }
        };

        ProductDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAbovePriceAsync(50.0m);

        // Assert
        Assert.Equal(0, count);
    }
}