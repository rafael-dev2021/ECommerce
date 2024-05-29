using Application.Dtos.ObjectsValues.ProductObjectValue;
using Application.Dtos.Products.Fashion.Shoes;
using Application.Dtos.Products.Fashion.T_Shirts;
using Application.Services.GetMatchingProducts.Fashion;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.GetMatchingProducts.Fashion;

public class GetMatchingProductsDtoFashionTests
{
    [Fact]
    public void GetMatchingProducts_ShouldReturnMatchingProducts()
    {
        // Arrange
        var productDto = new ShirtDto { SpecificationObjectValue = new SpecificationDtoObjectValue("Model1", "", "", "", "") };
        var tshirtsDto = new List<ShirtDto>
            {
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model1", "", "", "", "") },
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model2", "", "", "", "") }
            };
        var shoesDto = new List<ShoeDto>();

        var service = new GetMatchingProductsDtoFashion
        {
            ProductDto = productDto,
            TshirtsDto = tshirtsDto,
            ShoesDto = shoesDto
        };

        // Act
        var matchingTshirts = service.GetMatchingTshirtDto();

        // Assert
        Assert.Single(matchingTshirts);
    }

    [Fact]
    public void GetMatchingTshirtDto_ShouldReturnMatchingTshirts()
    {
        // Arrange
        var productDto = new ShirtDto { SpecificationObjectValue = new SpecificationDtoObjectValue("Model1", "", "", "", "") };
        var tshirtsDto = new List<ShirtDto>
            {
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model1", "", "", "", "") },
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model2", "", "", "", "") }
            };

        var shoesDto = new List<ShoeDto>
            {
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model1", "", "", "", "") },
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model2", "", "", "", "") }
            };

        var service = new GetMatchingProductsDtoFashion
        {
            ProductDto = productDto,
            TshirtsDto = tshirtsDto,
            ShoesDto = shoesDto
        };

        // Act
        var matchingTshirts = service.GetMatchingProducts(tshirtsDto);
        var matchingShoes = service.GetMatchingProducts(shoesDto);

        // Assert
        Assert.Single(matchingTshirts);
        Assert.Single(matchingShoes);
    }

    [Fact]
    public void GetMatchingShoesDto_ShouldReturnMatchingShoes()
    {
        // Arrange
        var productDto = new ShoeDto { SpecificationObjectValue = new SpecificationDtoObjectValue("Model1", "", "", "", "") };
        var tshirtsDto = new List<ShirtDto>();
        var shoesDto = new List<ShoeDto>
            {
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model1", "", "", "", "") },
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model2", "", "", "", "") }
            };

        var service = new GetMatchingProductsDtoFashion
        {
            ProductDto = productDto,
            TshirtsDto = tshirtsDto,
            ShoesDto = shoesDto
        };

        // Act
        var matchingShoes = service.GetMatchingShoesDto();

        // Assert
        Assert.Single(matchingShoes);
    }
}
