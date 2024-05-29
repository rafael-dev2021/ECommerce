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
    private readonly IProductDtoService _productDtoServiceMock;
    private readonly CountProductsByPriceService _countProductsByPriceService;

    public CountProductsByPriceServiceTests()
    {
        _productDtoServiceMock = Substitute.For<IProductDtoService>();
        _countProductsByPriceService = new CountProductsByPriceService(_productDtoServiceMock);
    }

    [Fact]
    public async Task CountingProductsAboveOrBelowPriceAsync_ShouldReturnCorrectCount()
    {
        // Arrange
        var products = new List<ProductDto>
            {
                new() { PriceObjectValue = new PriceDtoObjectValue(50.0m,0m) },
                new() { PriceObjectValue = new PriceDtoObjectValue(100.0m,0m) },
                new() { PriceObjectValue = new PriceDtoObjectValue(150.0m, 0m) }
            };
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAboveOrBelowPriceAsync(50.0m, 150.0m);

        // Assert
        Assert.Equal(3, count);
    }

    [Fact]
    public async Task CountingProductsAboveOrBelowPriceAsync_ShouldReturnCorrectCountWhenSecondPriceIsLower()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { PriceObjectValue = new PriceDtoObjectValue(50.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(100.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(150.0m, 0m) }
        };
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAboveOrBelowPriceAsync(50.0m, 100.0m);

        // Assert
        Assert.Equal(2, count);
    }

    [Fact]
    public async Task CountingProductsBelowPriceAsync_ShouldReturnCorrectCount()
    {
        // Arrange
        var products = new List<ProductDto>
            {
                new() { PriceObjectValue = new PriceDtoObjectValue(50.0m, 0m) },
                new() { PriceObjectValue = new PriceDtoObjectValue(100.0m, 0m) },
                new() { PriceObjectValue = new PriceDtoObjectValue(150.0m, 0m) }
            };
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsBelowPriceAsync(75.0m);

        // Assert
        Assert.Equal(1, count);
    }

    [Fact]
    public async Task CountingProductsAbovePriceAsync_ShouldReturnCorrectCount()
    {
        // Arrange
        var products = new List<ProductDto>
            {
                new() { PriceObjectValue = new PriceDtoObjectValue(50.0m, 0m) },
                new() { PriceObjectValue = new PriceDtoObjectValue(100.0m, 0m) },
                new() { PriceObjectValue = new PriceDtoObjectValue(150.0m, 0m) }
            };
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAbovePriceAsync(100.0m);

        // Assert
        Assert.Equal(2, count);
    }

    [Fact]
    public async Task CountingProductsAbovePriceAsync_ShouldReturnZeroWhenNoProductPriceIsAbove()
    {
        // Arrange
        var products = new List<ProductDto>
    {
        new() { PriceObjectValue = new PriceDtoObjectValue(50.0m, 0m) },
        new() { PriceObjectValue = new PriceDtoObjectValue(75.0m, 0m) },
        new() { PriceObjectValue = new PriceDtoObjectValue(90.0m, 0m) }
    };
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAbovePriceAsync(100.0m);

        // Assert
        Assert.Equal(0, count);
    }
}
