using Application.Dtos.ObjectsValues.ProductObjectValue;
using Application.Dtos.Products.Technology.Games;
using Application.Dtos.Products.Technology.Smartphones;
using Application.Services.GetMatchingProducts.Technology;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.GetMatchingProducts.Technology;

public class GetMatchingProductsDtoTechnologyTests
{

    [Fact]
    public void GetMatchingProducts_ShouldReturnMatchingProducts()
    {
        // Arrange
        var productDto = new GameDto { SpecificationObjectValue = new SpecificationDtoObjectValue("Model1", "", "", "", "") };
        var gamesDto = new List<GameDto>
            {
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model1", "", "", "", "") },
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model2", "", "", "", "") }
            };

        var smartphonesDto = new List<SmartphoneDto>
            {
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model1", "", "", "", "") },
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model2", "", "", "", "") }
            };

        var service = new GetMatchingProductsDtoTechnology
        {
            ProductDto = productDto,
            SmartphonesDto = smartphonesDto,
            GamesDto = gamesDto
        };

        // Act
        var matchingGames = service.GetMatchingProducts(gamesDto);
        var matchingSmartphones = service.GetMatchingProducts(smartphonesDto);

        // Assert
        Assert.Single(matchingGames);
        Assert.Single(matchingSmartphones);
    }


    [Fact]
    public void GetMatchingSmartphonesDto_ShouldReturnMatchingSmartphones()
    {
        // Arrange
        var productDto = new SmartphoneDto { SpecificationObjectValue = new SpecificationDtoObjectValue("Model1", "", "", "", "") };
        var smartphonesDto = new List<SmartphoneDto>
            {
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model1", "", "", "", "") },
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model2", "", "", "", "") }
            };
        var gamesDto = new List<GameDto>();

        var service = new GetMatchingProductsDtoTechnology
        {
            ProductDto = productDto,
            SmartphonesDto = smartphonesDto,
            GamesDto = gamesDto
        };

        // Act
        var matchingSmartphones = service.GetMatchingSmartphonesDto();

        // Assert
        Assert.Single(matchingSmartphones);
    }

    [Fact]
    public void GetMatchingGamesDto_ShouldReturnMatchingGames()
    {
        // Arrange
        var productDto = new GameDto { SpecificationObjectValue = new SpecificationDtoObjectValue("Model1", "", "", "", "") };
        var smartphonesDto = new List<SmartphoneDto>();
        var gamesDto = new List<GameDto>
            {
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model1", "", "", "", "") },
                new() { SpecificationObjectValue = new SpecificationDtoObjectValue ("Model2", "", "", "", "") }
            };

        var service = new GetMatchingProductsDtoTechnology
        {
            ProductDto = productDto,
            SmartphonesDto = smartphonesDto,
            GamesDto = gamesDto
        };

        // Act
        var matchingGames = service.GetMatchingGamesDto();

        // Assert
        Assert.Single(matchingGames);
    }
}
