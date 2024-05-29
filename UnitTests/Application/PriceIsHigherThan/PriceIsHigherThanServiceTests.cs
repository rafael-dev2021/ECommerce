using Application.Dtos;
using Application.Dtos.ObjectsValues.ProductObjectValue;
using Application.Interfaces;
using Application.Services.PriceIsHigherThan;
using NSubstitute;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.PriceIsHigherThan;

public class PriceIsHigherThanServiceTests
{

    [Fact]
    public async Task GetProductsAboveOrBelowPriceAsync_ShouldReturnFilteredProducts()
    {
        // Arrange
        var price = 50.0m;
        var secondPrice = 1000.0m;
        var productsDto = new List<ProductDto>
        {
            new() { PriceObjectValue = new PriceDtoObjectValue(25.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(75.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(125.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(0m, 0m) }
        };

        var productDtoServiceMock = Substitute.For<IProductDtoService>();
        productDtoServiceMock.GetProductsDtoAsync().Returns(Task.FromResult<IEnumerable<ProductDto>>(productsDto));

        var service = new PriceIsHigherThanService(productDtoServiceMock);

        // Act
        var result = await service.GetProductsAboveOrBelowPriceAsync(price, secondPrice);

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Contains(result, p => p.PriceObjectValue?.Price >= price);
        Assert.Contains(result, p => p.PriceObjectValue?.Price <= secondPrice);
    }

    [Fact]
    public async Task GetProductsAbovePriceAsync_ShouldReturnFilteredProducts()
    {
        // Arrange
        var price = 50.0m;
        var productsDto = new List<ProductDto>
        {
            new() { PriceObjectValue = new PriceDtoObjectValue(25.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(75.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(125.0m, 0m) },
            new() { PriceObjectValue = null },
            new() { PriceObjectValue = new PriceDtoObjectValue(0m, 0m) }
        };

        var productDtoServiceMock = Substitute.For<IProductDtoService>();
        productDtoServiceMock.GetProductsDtoAsync().Returns(Task.FromResult<IEnumerable<ProductDto>>(productsDto));

        var service = new PriceIsHigherThanService(productDtoServiceMock);

        // Act
        var result = await service.GetProductsAbovePriceAsync(price);

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetProductsBelowPriceAsync_ShouldReturnFilteredProducts()
    {
        // Arrange
        var price = 100.0m;
        var productsDto = new List<ProductDto>
        {
            new() { PriceObjectValue = new PriceDtoObjectValue(25.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(75.0m, 0m) },
            new() { PriceObjectValue = new PriceDtoObjectValue(125.0m, 0m) },
            new() { PriceObjectValue = null },
            new() { PriceObjectValue = new PriceDtoObjectValue(0m, 0m) }
        };

        var productDtoServiceMock = Substitute.For<IProductDtoService>();
        productDtoServiceMock.GetProductsDtoAsync().Returns(Task.FromResult<IEnumerable<ProductDto>>(productsDto));

        var service = new PriceIsHigherThanService(productDtoServiceMock);

        // Act
        var result = await service.GetProductsBelowPriceAsync(price);

        // Assert
        Assert.Equal(3, result.Count());
    }

    [Fact]
    public async Task GetProductsAboveOrBelowPriceAsync_ShouldReturnEmptyList_WhenNoProductsAvailable()
    {
        // Arrange
        var price = 50.0m;
        var secondPrice = 1000.0m;
        var emptyList = new List<ProductDto>();

        var productDtoServiceMock = Substitute.For<IProductDtoService>();
        productDtoServiceMock.GetProductsDtoAsync().Returns(Task.FromResult<IEnumerable<ProductDto>>(emptyList));

        var service = new PriceIsHigherThanService(productDtoServiceMock);

        // Act
        var result = await service.GetProductsAboveOrBelowPriceAsync(price, secondPrice);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetProductsAbovePriceAsync_ShouldReturnEmptyList_WhenNoProductsAvailable()
    {
        // Arrange
        var price = 50.0m;
        var emptyList = new List<ProductDto>();

        var productDtoServiceMock = Substitute.For<IProductDtoService>();
        productDtoServiceMock.GetProductsDtoAsync().Returns(Task.FromResult<IEnumerable<ProductDto>>(emptyList));

        var service = new PriceIsHigherThanService(productDtoServiceMock);

        // Act
        var result = await service.GetProductsAbovePriceAsync(price);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetProductsBelowPriceAsync_ShouldReturnEmptyList_WhenNoProductsAvailable()
    {
        // Arrange
        var price = 100.0m;
        var emptyList = new List<ProductDto>();

        var productDtoServiceMock = Substitute.For<IProductDtoService>();
        productDtoServiceMock.GetProductsDtoAsync().Returns(Task.FromResult<IEnumerable<ProductDto>>(emptyList));

        var service = new PriceIsHigherThanService(productDtoServiceMock);

        // Act
        var result = await service.GetProductsBelowPriceAsync(price);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetProductsAboveOrBelowPriceAsync_ShouldReturnFilteredProducts_WhenPriceIsHigherOrEqual()
    {
        // Arrange
        var price = 50.0m;
        var secondPrice = 1000.0m;
        var productsDto = new List<ProductDto>
    {
        new() { PriceObjectValue = new PriceDtoObjectValue(25.0m, 100.0m) },
        new() { PriceObjectValue = new PriceDtoObjectValue(75.0m, 80.0m) },
        new() { PriceObjectValue = new PriceDtoObjectValue(125.0m, 150.0m) },
        new() { PriceObjectValue = new PriceDtoObjectValue(0m, 0m) }, 
        new() { PriceObjectValue = new PriceDtoObjectValue(100.0m, 1000m) }, 
    };

        var productDtoServiceMock = Substitute.For<IProductDtoService>();
        productDtoServiceMock.GetProductsDtoAsync().Returns(Task.FromResult<IEnumerable<ProductDto>>(productsDto));

        var service = new PriceIsHigherThanService(productDtoServiceMock);

        // Act
        var result = await service.GetProductsAboveOrBelowPriceAsync(price, secondPrice);

        // Assert
        Assert.Equal(3, result.Count()); 
        Assert.Contains(result, p => p.PriceObjectValue?.Price >= price);
        Assert.Contains(result, p => p.PriceObjectValue?.Price <= secondPrice);
    }
}
