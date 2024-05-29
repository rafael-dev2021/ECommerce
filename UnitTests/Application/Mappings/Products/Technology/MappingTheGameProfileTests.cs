using Application.Dtos.ObjectsValues.ProductObjectValue;
using Application.Dtos.Products.Technology.Games;
using Application.Dtos.Products.Technology.Games.ObjectValues;
using Application.Mappings;
using Application.Mappings.Products.Technology;
using AutoMapper;
using Domain.Entities.Products.Technology.Games;
using FluentAssertions;
using Xunit;

namespace UnitTests.Application.Mappings.Products.Technology;

public class MappingTheGameProfileTests
{
    private readonly IMapper _mapper;

    public MappingTheGameProfileTests()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingTheGameProfile>();
            cfg.AddProfile<MappingTheProductProfile>();
        });
        _mapper = configuration.CreateMapper();
    }

    [Fact]
    public void Should_Map_GameDto_To_Game()
    {
        // Arrange
        var gameDto = new GameDto
        {
            Id = 1,
            Name = "Test Game",
            Description = "A test game description",
            ImagesUrl = ["image1.jpg", "image2.jpg"],
            Stock = 10,
            CategoryId = 1,
            DataObjectValue = new DataDtoObjectValue("January", 2023),
            FlagsObjectValue = new FlagsDtoObjectValue(true, true, true),
            PriceObjectValue = new PriceDtoObjectValue(19.99m, 19.99m),
            SpecificationObjectValue = new SpecificationDtoObjectValue("Model1", "Brand1", "Line1", "1kg", "Type1"),
            WarrantyObjectValue = new WarrantyDtoObjectValue("1 year", "2 years"),
            CommonPropertiesObjectValue = new CommonPropertiesDtoObjectValue("Unisex", "Blue", "Adult", "No", "L"),
            GeneralFeaturesObjectValue = new GeneralFeaturesDtoObjectValue("Collection1", "Saga1", "Title1", "Edition1", "Platform1", "Developer1", "Publisher1", 'A'),
            MediaSpecificationObjectValue = new MediaSpecificationDtoObjectValue("DVD", "English", "English", "English", 1, 4, 1024, true, true, true),
            RequirementObjectValue = new RequirementDtoObjectValue(512, "Windows 10", "NVIDIA", "Intel")
        };

        // Act
        var game = _mapper.Map<Game>(gameDto);

        // Assert
        game.Id.Should().Be(gameDto.Id);
        game.Name.Should().Be(gameDto.Name);
        game.Description.Should().Be(gameDto.Description);
        game.ImagesUrl.Should().BeEquivalentTo(gameDto.ImagesUrl);
        game.Stock.Should().Be(gameDto.Stock);
        game.CategoryId.Should().Be(gameDto.CategoryId);
        game.GeneralFeaturesObjectValue.Should().NotBeNull();
        game.GeneralFeaturesObjectValue?.Collection.Should().Be(gameDto.GeneralFeaturesObjectValue.Collection);
        game.GeneralFeaturesObjectValue?.Saga.Should().Be(gameDto.GeneralFeaturesObjectValue.Saga);
        game.GeneralFeaturesObjectValue?.Title.Should().Be(gameDto.GeneralFeaturesObjectValue.Title);
        game.GeneralFeaturesObjectValue?.Edition.Should().Be(gameDto.GeneralFeaturesObjectValue.Edition);
        game.GeneralFeaturesObjectValue?.Platform.Should().Be(gameDto.GeneralFeaturesObjectValue.Platform);
        game.GeneralFeaturesObjectValue?.Developers.Should().Be(gameDto.GeneralFeaturesObjectValue.Developers);
        game.GeneralFeaturesObjectValue?.Publishers.Should().Be(gameDto.GeneralFeaturesObjectValue.Publishers);
        game.GeneralFeaturesObjectValue?.GameRating.Should().Be(gameDto.GeneralFeaturesObjectValue.GameRating);

        game.MediaSpecificationObjectValue.Should().NotBeNull();
        game.MediaSpecificationObjectValue?.Format.Should().Be(gameDto.MediaSpecificationObjectValue.Format);
        game.MediaSpecificationObjectValue?.AudioLanguages.Should().Be(gameDto.MediaSpecificationObjectValue.AudioLanguages);
        game.MediaSpecificationObjectValue?.SubtitleLanguages.Should().Be(gameDto.MediaSpecificationObjectValue.SubtitleLanguages);
        game.MediaSpecificationObjectValue?.ScreenLanguages.Should().Be(gameDto.MediaSpecificationObjectValue.ScreenLanguages);
        game.MediaSpecificationObjectValue?.MaximumNumberOfOfflinePlayers.Should().Be(gameDto.MediaSpecificationObjectValue.MaximumNumberOfOfflinePlayers);
        game.MediaSpecificationObjectValue?.MaximumNumberOfOnlinePlayers.Should().Be(gameDto.MediaSpecificationObjectValue.MaximumNumberOfOnlinePlayers);
        game.MediaSpecificationObjectValue?.FileSize.Should().Be(gameDto.MediaSpecificationObjectValue.FileSize);
        game.MediaSpecificationObjectValue?.IsMultiplayer.Should().Be(gameDto.MediaSpecificationObjectValue.IsMultiplayer);
        game.MediaSpecificationObjectValue?.IsOnline.Should().Be(gameDto.MediaSpecificationObjectValue.IsOnline);
        game.MediaSpecificationObjectValue?.IsOffline.Should().Be(gameDto.MediaSpecificationObjectValue.IsOffline);

        game.RequirementObjectValue.Should().NotBeNull();
        game.RequirementObjectValue?.MinimumRamRequirementInMb.Should().Be(gameDto.RequirementObjectValue.MinimumRamRequirementInMb);
        game.RequirementObjectValue?.MinimumOperatingSystemsRequired.Should().Be(gameDto.RequirementObjectValue.MinimumOperatingSystemsRequired);
        game.RequirementObjectValue?.MinimumGraphicsProcessorsRequired.Should().Be(gameDto.RequirementObjectValue.MinimumGraphicsProcessorsRequired);
        game.RequirementObjectValue?.MinimumProcessorsRequired.Should().Be(gameDto.RequirementObjectValue.MinimumProcessorsRequired);
    }
}
