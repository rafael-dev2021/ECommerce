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
    public async Task CountingProductsAboveOrBelowPriceAsync_ShouldReturnCorrectCount_WhenSomeProductsAreInPriceRange()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { PriceObjectValue = new PriceDtoObjectValue(30.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(60.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(90.0m, 0m) }
        };
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAboveOrBelowPriceAsync(50.0m, 80.0m);

        // Assert
        Assert.Equal(1, count);
    }

    [Fact]
    public async Task CountingProductsAboveOrBelowPriceAsync_ShouldReturnCorrectCount_WhenAllProductsAreInPriceRange()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { PriceObjectValue = new PriceDtoObjectValue(50.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(60.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(70.0m, 0m) }
        };
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAboveOrBelowPriceAsync(50.0m, 80.0m);

        // Assert
        Assert.Equal(3, count);
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
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAboveOrBelowPriceAsync(50.0m, 80.0m);

        // Assert
        Assert.Equal(0, count);
    }

    [Fact]
    public async Task CountingProductsAboveOrBelowPriceAsync_ShouldHandleNullPriceObjectValue()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { PriceObjectValue = null },
            new() { PriceObjectValue = new PriceDtoObjectValue(60.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(70.0m, 0m) }
        };
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAboveOrBelowPriceAsync(50.0m, 80.0m);

        // Assert
        Assert.Equal(2, count);
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
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsBelowPriceAsync(50.0m);

        // Assert
        Assert.Equal(1, count);
    }

    [Fact]
    public async Task CountingProductsBelowPriceAsync_ShouldReturnCorrectCount_WhenAllProductsAreBelowPrice()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { PriceObjectValue = new PriceDtoObjectValue(30.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(40.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(45.0m, 0m) }
        };
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsBelowPriceAsync(50.0m);

        // Assert
        Assert.Equal(3, count);
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
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsBelowPriceAsync(50.0m);

        // Assert
        Assert.Equal(0, count);
    }

    [Fact]
    public async Task CountingProductsBelowPriceAsync_ShouldHandleNullPriceObjectValue()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { PriceObjectValue = null },
            new() { PriceObjectValue = new PriceDtoObjectValue(60.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(70.0m, 0m) }
        };
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

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
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAbovePriceAsync(50.0m);

        // Assert
        Assert.Equal(2, count); 
    }

    [Fact]
    public async Task CountingProductsAbovePriceAsync_ShouldReturnCorrectCount_WhenAllProductsAreAbovePrice()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { PriceObjectValue = new PriceDtoObjectValue(60.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(70.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(80.0m, 0m) }
        };
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAbovePriceAsync(50.0m);

        // Assert
        Assert.Equal(3, count); 
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
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAbovePriceAsync(50.0m);

        // Assert
        Assert.Equal(0, count); 
    }

    [Fact]
    public async Task CountingProductsAbovePriceAsync_ShouldHandleNullPriceObjectValue()
    {
        // Arrange
        var products = new List<ProductDto>
        {
            new() { PriceObjectValue = null },
            new() { PriceObjectValue = new PriceDtoObjectValue(60.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(70.0m, 0m) }
        };
        _productDtoServiceMock.GetProductsDtoAsync().Returns(products);

        // Act
        var count = await _countProductsByPriceService.CountingProductsAbovePriceAsync(50.0m);

        // Assert
        Assert.Equal(2, count); 
    }
}
