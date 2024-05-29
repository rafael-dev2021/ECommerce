using Application.Dtos;
using Application.Dtos.ObjectsValues.ProductObjectValue;
using Application.Services.PriceIsHigherThan;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.PriceIsHigherThan;

public class PriceIsHigherThanServiceBooleansTests
{
    [Fact]
    public void IsPriceHigherThanTwoThousand_ShouldReturnTrueWhenPriceIsHigherThanTwoThousand()
    {
        // Arrange
        var productDto = new ProductDto { PriceObjectValue = new PriceDtoObjectValue(2500.0m, 0m) };
        var service = new PriceIsHigherThanServiceBooleans { ProductDto = productDto };

        // Act
        var result = service.IsPriceHigherThanTwoThousand;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPriceHigherThanTwoThousand_ShouldReturnFalseWhenPriceIsLowerThanTwoThousand()
    {
        // Arrange
        var productDto = new ProductDto { PriceObjectValue = new PriceDtoObjectValue(1500.0m, 0m) };
        var service = new PriceIsHigherThanServiceBooleans { ProductDto = productDto };

        // Act
        var result = service.IsPriceHigherThanTwoThousand;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPriceHigherThanTwoThousand_ShouldReturnFalseWhenProductDtoIsNull()
    {
        // Arrange
        var service = new PriceIsHigherThanServiceBooleans { ProductDto = null };

        // Act
        var result = service.IsPriceHigherThanTwoThousand;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPriceHigherThanTwoThousand_ShouldReturnFalseWhenPriceObjectValueIsNull()
    {
        // Arrange
        var productDto = new ProductDto { PriceObjectValue = null };
        var service = new PriceIsHigherThanServiceBooleans { ProductDto = productDto };

        // Act
        var result = service.IsPriceHigherThanTwoThousand;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPriceIsBetweenTwoHundredAndAThousand_ShouldReturnTrueWhenPriceIsBetweenTwoHundredAndAThousand()
    {
        // Arrange
        var productDto = new ProductDto { PriceObjectValue = new PriceDtoObjectValue(500.0m, 0m) };
        var service = new PriceIsHigherThanServiceBooleans { ProductDto = productDto };

        // Act
        var result = service.IsPriceIsBetweenTwoHundredAndAThousand;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPriceIsBetweenTwoHundredAndAThousand_ShouldReturnFalseWhenPriceIsLowerThanTwoHundred()
    {
        // Arrange
        var productDto = new ProductDto { PriceObjectValue = new PriceDtoObjectValue(150.0m, 0m) };
        var service = new PriceIsHigherThanServiceBooleans { ProductDto = productDto };

        // Act
        var result = service.IsPriceIsBetweenTwoHundredAndAThousand;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPriceIsBetweenTwoHundredAndAThousand_ShouldReturnFalseWhenPriceIsHigherThanAThousand()
    {
        // Arrange
        var productDto = new ProductDto { PriceObjectValue = new PriceDtoObjectValue(1500.0m, 0m) };
        var service = new PriceIsHigherThanServiceBooleans { ProductDto = productDto };

        // Act
        var result = service.IsPriceIsBetweenTwoHundredAndAThousand;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPriceIsBetweenTwoHundredAndAThousand_ShouldReturnFalseWhenProductDtoIsNull()
    {
        // Arrange
        var service = new PriceIsHigherThanServiceBooleans { ProductDto = null };

        // Act
        var result = service.IsPriceIsBetweenTwoHundredAndAThousand;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPriceIsBetweenTwoHundredAndAThousand_ShouldReturnFalseWhenPriceObjectValueIsNull()
    {
        // Arrange
        var productDto = new ProductDto { PriceObjectValue = null };
        var service = new PriceIsHigherThanServiceBooleans { ProductDto = productDto };

        // Act
        var result = service.IsPriceIsBetweenTwoHundredAndAThousand;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPriceIsLowerThanOneHundred_ShouldReturnTrueWhenPriceIsLowerThanOneHundred()
    {
        // Arrange
        var productDto = new ProductDto { PriceObjectValue = new PriceDtoObjectValue(50.0m, 0m) };
        var service = new PriceIsHigherThanServiceBooleans { ProductDto = productDto };

        // Act
        var result = service.IsPriceIsLowerThanOneHundred;

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPriceIsLowerThanOneHundred_ShouldReturnFalseWhenPriceIsHigherThanOneHundred()
    {
        // Arrange
        var productDto = new ProductDto { PriceObjectValue = new PriceDtoObjectValue(150.0m, 0m) };
        var service = new PriceIsHigherThanServiceBooleans { ProductDto = productDto };

        // Act
        var result = service.IsPriceIsLowerThanOneHundred;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPriceIsLowerThanOneHundred_ShouldReturnFalseWhenProductDtoIsNull()
    {
        // Arrange
        var service = new PriceIsHigherThanServiceBooleans { ProductDto = null };

        // Act
        var result = service.IsPriceIsLowerThanOneHundred;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPriceIsLowerThanOneHundred_ShouldReturnFalseWhenPriceObjectValueIsNull()
    {
        // Arrange
        var productDto = new ProductDto { PriceObjectValue = null };
        var service = new PriceIsHigherThanServiceBooleans { ProductDto = productDto };

        // Act
        var result = service.IsPriceIsLowerThanOneHundred;

        // Assert
        Assert.False(result);
    }
}
