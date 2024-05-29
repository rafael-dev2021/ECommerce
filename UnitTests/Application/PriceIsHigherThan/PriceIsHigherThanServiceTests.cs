﻿using Application.Dtos;
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
        new() { PriceObjectValue = new PriceDtoObjectValue(125.0m, 0m) }
    };

        var productDtoServiceMock = Substitute.For<IProductDtoService>();
        productDtoServiceMock.GetProductsDtoAsync().Returns(Task.FromResult<IEnumerable<ProductDto>>(productsDto));

        var service = new PriceIsHigherThanService(productDtoServiceMock);

        // Act
        var result = await service.GetProductsAboveOrBelowPriceAsync(price, secondPrice);

        // Assert
        Assert.Equal(2, result.Count());
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
                new() { PriceObjectValue = new PriceDtoObjectValue(125.0m, 0m) }
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
                new() { PriceObjectValue = new PriceDtoObjectValue(125.0m, 0m) }
            };

        var productDtoServiceMock = Substitute.For<IProductDtoService>();
        productDtoServiceMock.GetProductsDtoAsync().Returns(Task.FromResult<IEnumerable<ProductDto>>(productsDto));

        var service = new PriceIsHigherThanService(productDtoServiceMock);

        // Act
        var result = await service.GetProductsBelowPriceAsync(price);

        // Assert
        Assert.Equal(2, result.Count());
    }
}
