using Application.Dtos.ObjectsValues.ProductObjectValue;
using Application.Dtos.Products.Fashion.Shoes;
using Application.Dtos.Products.Fashion.Shoes.ObjectValues;
using Application.Mappings;
using Application.Mappings.Products.Fashion;
using AutoMapper;
using Domain.Entities.Products.Fashion.Shoes;
using FluentAssertions;
using Xunit;

namespace UnitTests.Application.Mappings.Products.Fashion;

public class MappingTheShoeProfileTests
{
    private readonly IMapper _mapper;

    public MappingTheShoeProfileTests()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingTheShoeProfile>();
            cfg.AddProfile<MappingTheProductProfile>();
        });
        _mapper = configuration.CreateMapper();
    }

    [Fact]
    public void Should_Map_ShoeDto_To_Shoe()
    {
        // Arrange
        var shoeDto = new ShoeDto
        {
            Id = 1,
            Name = "Test Shoe",
            Description = "A test shoe description",
            ImagesUrl = ["image1.jpg", "image2.jpg"],
            Stock = 10,
            CategoryId = 1,
            DataObjectValue = new DataDtoObjectValue("January", 2023),
            FlagsObjectValue = new FlagsDtoObjectValue(true, true, true),
            PriceObjectValue = new PriceDtoObjectValue(19.99m, 19.99m),
            SpecificationObjectValue = new SpecificationDtoObjectValue("Model1", "Brand1", "Line1", "1kg", "Type1"),
            WarrantyObjectValue = new WarrantyDtoObjectValue("1 year", "2 years"),
            CommonPropertiesObjectValue = new CommonPropertiesDtoObjectValue("Unisex", "Blue", "Adult", "No", "L"),
            MaterialObjectValue = new MaterialDtoObjectValue("Leather", "Fabric", "Rubber")
        };

        // Act
        var shoe = _mapper.Map<Shoe>(shoeDto);

        // Assert
        shoe.Id.Should().Be(shoeDto.Id);
        shoe.Name.Should().Be(shoeDto.Name);
        shoe.Description.Should().Be(shoeDto.Description);
        shoe.ImagesUrl.Should().BeEquivalentTo(shoeDto.ImagesUrl);
        shoe.Stock.Should().Be(shoeDto.Stock);
        shoe.CategoryId.Should().Be(shoeDto.CategoryId);
        shoe.MaterialObjectValue.Should().NotBeNull();
        shoe.MaterialObjectValue?.MaterialsFromAbroad.Should().Be(shoeDto.MaterialObjectValue.MaterialsFromAbroad);
        shoe.MaterialObjectValue?.InteriorMaterials.Should().Be(shoeDto.MaterialObjectValue.InteriorMaterials);
        shoe.MaterialObjectValue?.SoleMaterials.Should().Be(shoeDto.MaterialObjectValue.SoleMaterials);
    }
}
