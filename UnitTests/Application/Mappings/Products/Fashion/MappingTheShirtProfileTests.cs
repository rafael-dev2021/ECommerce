using Application.Dtos.ObjectsValues.ProductObjectValue;
using Application.Dtos.Products.Fashion.T_Shirts;
using Application.Dtos.Products.Fashion.T_Shirts.ObjectValues;
using Application.Mappings;
using Application.Mappings.Products.Fashion;
using AutoMapper;
using Domain.Entities.ObjectValues.ProductObjectValue;
using Domain.Entities.Products.Fashion.T_Shirts;
using Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;
using FluentAssertions;
using Xunit;

namespace UnitTests.Application.Mappings.Products.Fashion;

public class MappingTheShirtProfileTests
{
    private readonly IMapper _mapper;

    public MappingTheShirtProfileTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingTheShirtProfile>();
            cfg.AddProfile<MappingTheProductProfile>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Should_Map_ShirtDto_To_Shirt()
    {
        // Arrange
        var shirtDto = new ShirtDto
        {
            Id = 1,
            Name = "Test Shirt",
            Description = "A test shirt description",
            ImagesUrl = ["image1.jpg", "image2.jpg"],
            Stock = 10,
            CategoryId = 1,
            DataObjectValue = new DataDtoObjectValue("January", 2023),
            FlagsObjectValue = new FlagsDtoObjectValue(true, true, true),
            PriceObjectValue = new PriceDtoObjectValue(19.99m, 19.99m),
            SpecificationObjectValue = new SpecificationDtoObjectValue("Model1", "Brand1", "Line1", "1kg", "Type1"),
            WarrantyObjectValue = new WarrantyDtoObjectValue("1 year", "2 years"),
            CommonPropertiesObjectValue = new CommonPropertiesDtoObjectValue("Unisex", "Blue", "Adult", "No", "L"),
            MainFeaturesObjectValue = new MainFeaturesDtoObjectValue("T-Shirt", "Plain"),
            OtherFeaturesObjectValue = new OtherFeaturesDtoObjectValue("100% Cotton", "Cotton", 1, true, false)
        };

        // Act
        var shirt = _mapper.Map<Shirt>(shirtDto);

        // Assert
        shirt.Id.Should().Be(shirtDto.Id);
        shirt.Name.Should().Be(shirtDto.Name);
        shirt.Description.Should().Be(shirtDto.Description);
        shirt.ImagesUrl.Should().BeEquivalentTo(shirtDto.ImagesUrl);
        shirt.Stock.Should().Be(shirtDto.Stock);
        shirt.CategoryId.Should().Be(shirtDto.CategoryId);
        shirt.MainFeaturesObjectValue.Should().NotBeNull();
        shirt.MainFeaturesObjectValue?.TypeOfClothing.Should().Be(shirtDto.MainFeaturesObjectValue.TypeOfClothing);
        shirt.MainFeaturesObjectValue?.FabricDesign.Should().Be(shirtDto.MainFeaturesObjectValue.FabricDesign);
        shirt.OtherFeaturesObjectValue?.Should().NotBeNull();
        shirt.OtherFeaturesObjectValue?.Composition.Should().Be(shirtDto.OtherFeaturesObjectValue.Composition);
        shirt.OtherFeaturesObjectValue?.MainMaterial.Should().Be(shirtDto.OtherFeaturesObjectValue.MainMaterial);
        shirt.OtherFeaturesObjectValue?.UnitsPerKit.Should().Be(shirtDto.OtherFeaturesObjectValue.UnitsPerKit);
        shirt.OtherFeaturesObjectValue.Should().NotBeNull();
        shirt.OtherFeaturesObjectValue.Should().NotBeNull();
    }

    [Fact]
    public void Should_Map_Shirt_To_ShirtDto()
    {
        // Arrange
        var shirt = new Shirt(
            "Test Shirt",
            "A test shirt description",
            ["image1.jpg", "image2.jpg"],
            10,
            new DataObjectValue(),
            new FlagsObjectValue(),
            new PriceObjectValue(),
            new SpecificationObjectValue(),
            new WarrantyObjectValue(),
            new MainFeaturesObjectValue(),
            new OtherFeaturesObjectValue(),
            new CommonPropertiesObjectValue(),
            1
        );

        shirt.SetId(1);

        // Act
        var shirtDto = _mapper.Map<ShirtDto>(shirt);

        // Assert
        shirtDto.Id.Should().Be(shirt.Id);
        shirtDto.Name.Should().Be(shirt.Name);
        shirtDto.Description.Should().Be(shirt.Description);
        shirtDto.ImagesUrl.Should().BeEquivalentTo(shirt.ImagesUrl);
        shirtDto.Stock.Should().Be(shirt.Stock);
        shirtDto.CategoryId.Should().Be(shirt.CategoryId);
        shirtDto.MainFeaturesObjectValue.Should().NotBeNull();
        shirtDto.MainFeaturesObjectValue?.TypeOfClothing.Should().Be(shirt.MainFeaturesObjectValue?.TypeOfClothing);
        shirtDto.MainFeaturesObjectValue?.FabricDesign.Should().Be(shirt.MainFeaturesObjectValue?.FabricDesign);
        shirtDto.OtherFeaturesObjectValue.Should().NotBeNull();
        shirtDto.OtherFeaturesObjectValue?.Composition.Should().Be(shirt.OtherFeaturesObjectValue?.Composition);
        shirtDto.OtherFeaturesObjectValue?.MainMaterial.Should().Be(shirt.OtherFeaturesObjectValue?.MainMaterial);
        shirtDto.OtherFeaturesObjectValue?.UnitsPerKit.Should().Be(shirt.OtherFeaturesObjectValue?.UnitsPerKit);
        shirtDto.OtherFeaturesObjectValue.Should().NotBeNull();
        shirtDto.OtherFeaturesObjectValue.Should().NotBeNull();
    }
}
