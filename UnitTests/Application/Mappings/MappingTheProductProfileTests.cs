using Application.Dtos;
using Application.Dtos.ObjectsValues.ProductObjectValue;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentAssertions;
using Xunit;

namespace UnitTests.Application.Mappings;

public class MappingTheProductProfileTests
{
    private readonly IMapper _mapper;

    public MappingTheProductProfileTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingTheProductProfile>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Should_Map_Product_To_ProductDto()
    {
        // Arrange
        var product = new Product();
        product.SetId(1);
        product.UpdateProduct(
            "Product Name",
            "Product Description",
            new List<string> { "image1.jpg", "image2.jpg" },
            10,
            new DataObjectValue(),
            new FlagsObjectValue(),
            new PriceObjectValue(),
            new SpecificationObjectValue(),
            new WarrantyObjectValue(),
            new CommonPropertiesObjectValue(),
            1
        );

        // Act
        var productDto = _mapper.Map<ProductDto>(product);

        // Assert
        productDto.Id.Should().Be(product.Id);
        productDto.Name.Should().Be(product.Name);
        productDto.Description.Should().Be(product.Description);
        productDto.ImagesUrl.Should().BeEquivalentTo(product.ImagesUrl);
        productDto.Stock.Should().Be(product.Stock);
        productDto.CategoryId.Should().Be(product.CategoryId);
        productDto.DataObjectValue.Should().NotBeNull();
        productDto.FlagsObjectValue.Should().NotBeNull();
        productDto.PriceObjectValue.Should().NotBeNull();
        productDto.SpecificationObjectValue.Should().NotBeNull();
        productDto.WarrantyObjectValue.Should().NotBeNull();
        productDto.CommonPropertiesObjectValue.Should().NotBeNull();
    }

    [Fact]
    public void Should_Map_ProductDto_To_Product()
    {
        // Arrange
        var productDto = new ProductDto
        {
            Id = 1,
            Name = "Product Name",
            Description = "Product Description",
            ImagesUrl = new List<string> { "image1.jpg", "image2.jpg" },
            Stock = 10,
            CategoryId = 1,
            DataObjectValue = new DataDtoObjectValue("January", 2023),
            FlagsObjectValue = new FlagsDtoObjectValue(true, true, true),
            PriceObjectValue = new PriceDtoObjectValue(12m, 12m),
            SpecificationObjectValue = new SpecificationDtoObjectValue("Model", "Brand", "Line", "Weight", "Type"),
            WarrantyObjectValue = new WarrantyDtoObjectValue("W", "W"),
            CommonPropertiesObjectValue = new CommonPropertiesDtoObjectValue("Gender", "Color", "Age", "Rec", "Size")
        };

        // Act
        var product = _mapper.Map<Product>(productDto);

        // Assert
        product.Id.Should().Be(productDto.Id);
        product.Name.Should().Be(productDto.Name);
        product.Description.Should().Be(productDto.Description);
        product.ImagesUrl.Should().BeEquivalentTo(productDto.ImagesUrl);
        product.Stock.Should().Be(productDto.Stock);
        product.CategoryId.Should().Be(productDto.CategoryId);
        product.DataObjectValue.Should().NotBeNull();
        product.FlagsObjectValue.Should().NotBeNull();
        product.PriceObjectValue.Should().NotBeNull();
        product.SpecificationObjectValue.Should().NotBeNull();
        product.WarrantyObjectValue.Should().NotBeNull();
        product.CommonPropertiesObjectValue.Should().NotBeNull();
    }

    [Fact]
    public void Should_Map_DataObjectValue_To_DataDtoObjectValue()
    {
        // Arrange
        var dataObjectValue = new DataObjectValue();

        // Act
        var dataDtoObjectValue = _mapper.Map<DataDtoObjectValue>(dataObjectValue);

        // Assert
        dataDtoObjectValue.ReleaseMonth.Should().Be(dataObjectValue.ReleaseMonth);
        dataDtoObjectValue.ReleaseYear.Should().Be(dataObjectValue.ReleaseYear);
    }

    [Fact]
    public void Should_Map_DataDtoObjectValue_To_DataObjectValue()
    {
        // Arrange
        var dataDtoObjectValue = new DataDtoObjectValue("January", 2023);

        // Act
        var dataObjectValue = _mapper.Map<DataObjectValue>(dataDtoObjectValue);

        // Assert
        dataObjectValue.ReleaseMonth.Should().Be(dataDtoObjectValue.ReleaseMonth);
        dataObjectValue.ReleaseYear.Should().Be(dataDtoObjectValue.ReleaseYear);
    }

    [Fact]
    public void Should_Map_FlagsObjectValue_To_FlagsDtoObjectValue()
    {
        // Arrange
        var flagsObjectValue = new FlagsObjectValue();

        // Act
        var flagsDtoObjectValue = _mapper.Map<FlagsDtoObjectValue>(flagsObjectValue);

        // Assert
        flagsDtoObjectValue.IsFavorite.Should().Be(flagsObjectValue.IsFavorite);
        flagsDtoObjectValue.IsDailyOffer.Should().Be(flagsObjectValue.IsDailyOffer);
        flagsDtoObjectValue.IsBestSeller.Should().Be(flagsObjectValue.IsBestSeller);
    }

    [Fact]
    public void Should_Map_FlagsDtoObjectValue_To_FlagsObjectValue()
    {
        // Arrange
        var flagsDtoObjectValue = new FlagsDtoObjectValue(true, true, true);

        // Act
        var flagsObjectValue = _mapper.Map<FlagsObjectValue>(flagsDtoObjectValue);

        // Assert
        flagsObjectValue.IsFavorite.Should().Be(flagsDtoObjectValue.IsFavorite);
        flagsObjectValue.IsDailyOffer.Should().Be(flagsDtoObjectValue.IsDailyOffer);
        flagsObjectValue.IsBestSeller.Should().Be(flagsDtoObjectValue.IsBestSeller);
    }

    [Fact]
    public void Should_Map_PriceObjectValue_To_PriceDtoObjectValue()
    {
        // Arrange
        var priceObjectValue = new PriceObjectValue();

        // Act
        var priceDtoObjectValue = _mapper.Map<PriceDtoObjectValue>(priceObjectValue);

        // Assert
        priceDtoObjectValue.Price.Should().Be(priceObjectValue.Price);
        priceDtoObjectValue.HistoryPrice.Should().Be(priceObjectValue.HistoryPrice);
    }

    [Fact]
    public void Should_Map_PriceDtoObjectValue_To_PriceObjectValue()
    {
        // Arrange
        var priceDtoObjectValue = new PriceDtoObjectValue(12m, 12m);

        // Act
        var priceObjectValue = _mapper.Map<PriceObjectValue>(priceDtoObjectValue);

        // Assert
        priceObjectValue.Price.Should().Be(priceDtoObjectValue.Price);
        priceObjectValue.HistoryPrice.Should().Be(priceDtoObjectValue.HistoryPrice);
    }

    [Fact]
    public void Should_Map_SpecificationObjectValue_To_SpecificationDtoObjectValue()
    {
        // Arrange
        var specificationObjectValue = new SpecificationObjectValue();

        // Act
        var specificationDtoObjectValue = _mapper.Map<SpecificationDtoObjectValue>(specificationObjectValue);

        // Assert
        specificationDtoObjectValue.Model.Should().Be(specificationObjectValue.Model);
        specificationDtoObjectValue.Brand.Should().Be(specificationObjectValue.Brand);
        specificationDtoObjectValue.Line.Should().Be(specificationObjectValue.Line);
        specificationDtoObjectValue.Weight.Should().Be(specificationObjectValue.Weight);
        specificationDtoObjectValue.Type.Should().Be(specificationObjectValue.Type);
    }

    [Fact]
    public void Should_Map_SpecificationDtoObjectValue_To_SpecificationObjectValue()
    {
        // Arrange
        var specificationDtoObjectValue = new SpecificationDtoObjectValue("Model", "Brand", "Line", "Weight", "Type");

        // Act
        var specificationObjectValue = _mapper.Map<SpecificationObjectValue>(specificationDtoObjectValue);

        // Assert
        specificationObjectValue.Model.Should().Be(specificationDtoObjectValue.Model);
        specificationObjectValue.Brand.Should().Be(specificationDtoObjectValue.Brand);
        specificationObjectValue.Line.Should().Be(specificationDtoObjectValue.Line);
        specificationObjectValue.Weight.Should().Be(specificationDtoObjectValue.Weight);
        specificationObjectValue.Type.Should().Be(specificationDtoObjectValue.Type);
    }

    [Fact]
    public void Should_Map_WarrantyObjectValue_To_WarrantyDtoObjectValue()
    {
        // Arrange
        var warrantyObjectValue = new WarrantyObjectValue();

        // Act
        var warrantyDtoObjectValue = _mapper.Map<WarrantyDtoObjectValue>(warrantyObjectValue);

        // Assert
        warrantyDtoObjectValue.WarrantyInformation.Should().Be(warrantyObjectValue.WarrantyInformation);
        warrantyDtoObjectValue.WarrantyLength.Should().Be(warrantyObjectValue.WarrantyLength);
    }

    [Fact]
    public void Should_Map_WarrantyDtoObjectValue_To_WarrantyObjectValue()
    {
        // Arrange
        var warrantyDtoObjectValue = new WarrantyDtoObjectValue("W", "W");

        // Act
        var warrantyObjectValue = _mapper.Map<WarrantyObjectValue>(warrantyDtoObjectValue);

        // Assert
        warrantyObjectValue.WarrantyInformation.Should().Be(warrantyDtoObjectValue.WarrantyInformation);
        warrantyObjectValue.WarrantyLength.Should().Be(warrantyDtoObjectValue.WarrantyLength);
    }

    [Fact]
    public void Should_Map_CommonPropertiesObjectValue_To_CommonPropertiesDtoObjectValue()
    {
        // Arrange
        var commonPropertiesObjectValue = new CommonPropertiesObjectValue();

        // Act
        var commonPropertiesDtoObjectValue = _mapper.Map<CommonPropertiesDtoObjectValue>(commonPropertiesObjectValue);

        // Assert
        commonPropertiesDtoObjectValue.Gender.Should().Be(commonPropertiesObjectValue.Gender);
        commonPropertiesDtoObjectValue.Color.Should().Be(commonPropertiesObjectValue.Color);
        commonPropertiesDtoObjectValue.Age.Should().Be(commonPropertiesObjectValue.Age);
        commonPropertiesDtoObjectValue.RecommendedUses.Should().Be(commonPropertiesObjectValue.RecommendedUses);
        commonPropertiesDtoObjectValue.Size.Should().Be(commonPropertiesObjectValue.Size);
    }

    [Fact]
    public void Should_Map_CommonPropertiesDtoObjectValue_To_CommonPropertiesObjectValue()
    {
        // Arrange
        var commonPropertiesDtoObjectValue = new CommonPropertiesDtoObjectValue("Gender", "Color", "Age", "Rec", "Size");

        // Act
        var commonPropertiesObjectValue = _mapper.Map<CommonPropertiesObjectValue>(commonPropertiesDtoObjectValue);

        // Assert
        commonPropertiesObjectValue.Gender.Should().Be(commonPropertiesDtoObjectValue.Gender);
        commonPropertiesObjectValue.Color.Should().Be(commonPropertiesDtoObjectValue.Color);
        commonPropertiesObjectValue.Age.Should().Be(commonPropertiesDtoObjectValue.Age);
        commonPropertiesObjectValue.RecommendedUses.Should().Be(commonPropertiesDtoObjectValue.RecommendedUses);
        commonPropertiesObjectValue.Size.Should().Be(commonPropertiesDtoObjectValue.Size);
    }
}
