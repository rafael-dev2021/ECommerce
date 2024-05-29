using Application.Dtos;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Xunit;

namespace UnitTests.Application.Mappings;

public class MappingTheCategoryProfileTests
{
    private readonly IMapper _mapper;

    public MappingTheCategoryProfileTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingTheCategoryProfile>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Should_Map_Category_To_CategoryDto()
    {
        // Arrange
        var category = new Category(1, "Electronics", "imageUrl", true);

        // Act
        var categoryDto = _mapper.Map<CategoryDto>(category);

        // Assert
        categoryDto.Id.Should().Be(category.Id);
        categoryDto.Name.Should().Be(category.Name);
        categoryDto.ImageUrl.Should().Be(category.ImageUrl);
        categoryDto.IsActive.Should().Be(category.IsActive);
    }

    [Fact]
    public void Should_Map_CategoryDto_To_Category()
    {
        // Arrange
        var categoryDto = new CategoryDto(1, "Electronics", "imageUrl", true);

        // Act
        var category = _mapper.Map<Category>(categoryDto);

        // Assert
        category.Id.Should().Be(categoryDto.Id);
        category.Name.Should().Be(categoryDto.Name);
        category.ImageUrl.Should().Be(categoryDto.ImageUrl);
        category.IsActive.Should().Be(categoryDto.IsActive);
    }

    [Fact]
    public void Should_Map_CategoryWithProductCount_To_CategoryWithProductCountDto()
    {
        // Arrange
        var categoryWithProductCount = new CategoryWithProductCount("Electronics", 10);

        // Act
        var categoryWithProductCountDto = _mapper.Map<CategoryWithProductCountDto>(categoryWithProductCount);

        // Assert
        categoryWithProductCountDto.CategoryName.Should().Be(categoryWithProductCount.CategoryName);
        categoryWithProductCountDto.ProductCount.Should().Be(categoryWithProductCount.ProductCount);
    }

    [Fact]
    public void Should_Map_CategoryWithProductCountDto_To_CategoryWithProductCount()
    {
        // Arrange
        var categoryWithProductCountDto = new CategoryWithProductCountDto("Electronics", 10);

        // Act
        var categoryWithProductCount = _mapper.Map<CategoryWithProductCount>(categoryWithProductCountDto);

        // Assert
        categoryWithProductCount.CategoryName.Should().Be(categoryWithProductCountDto.CategoryName);
        categoryWithProductCount.ProductCount.Should().Be(categoryWithProductCountDto.ProductCount);
    }
}
