using Application.Dtos;
using Application.Services.Entities;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using NSubstitute;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Services.Entities;

public class CategoryDtoServiceTests
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;
    private readonly CategoryDtoService _categoryDtoService;

    public CategoryDtoServiceTests()
    {
        _mapper = Substitute.For<IMapper>();
        _categoryRepository = Substitute.For<ICategoryRepository>();
        _categoryDtoService = new CategoryDtoService(_mapper, _categoryRepository);
    }

    [Fact]
    [Test]
    public async Task GetEntitiesAsync_ReturnsMappedCategories_WhenCategoriesExist()
    {
        // Arrange
        var categories = new List<Category> { new(1, "Test", "Image.jpg", true) };
        var categoriesDto = new List<CategoryDto> { new(1, "Test", "Image.jpg", true) };

        _categoryRepository.GetEntitiesAsync().Returns(categories);
        _mapper.Map<IEnumerable<CategoryDto>>(categories).Returns(categoriesDto);

        // Act
        var result = await _categoryDtoService.GetEntitiesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(categoriesDto, result);
    }

    [Fact]
    [Test]
    public async Task GetEntitiesAsync_ReturnsEmptyList_WhenNoCategoriesExist()
    {
        // Arrange
        _categoryRepository.GetEntitiesAsync().Returns(new List<Category>());

        // Act
        var result = await _categoryDtoService.GetEntitiesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    [Test]
    public async Task GetByIdAsync_ReturnsMappedCategory_WhenCategoryExists()
    {
        // Arrange
        var categoryGetId = new Category(1, "Test", "Image.jpg", true);
        var categoryDtoGetId = new CategoryDto(1, "Test", "Image.jpg", true);

        _categoryRepository.GetByIdAsync(1).Returns(categoryGetId);
        _mapper.Map<CategoryDto>(categoryGetId).Returns(categoryDtoGetId);

        // Act
        var result = await _categoryDtoService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(categoryDtoGetId, result);
    }


    [Fact]
    [Test]
    public async Task AddAsync_CallsRepositoryCreateAsync_WhenCategoryIsValid()
    {
        // Arrange
        var categoryDtoAddSuccess = new CategoryDto(1, "Test", "Image.jpg", true);
        var categoryAddSuccess = new Category(1, "Test", "Image.jpg", true);

        _mapper.Map<Category>(categoryDtoAddSuccess).Returns(categoryAddSuccess);

        // Act
        await _categoryDtoService.AddAsync(categoryDtoAddSuccess);

        // Assert
        await _categoryRepository.Received(1).CreateAsync(categoryAddSuccess);
    }

    [Fact]
    [Test]
    public async Task UpdateAsync_CallsRepositoryUpdateAsync_WhenCategoryIsValid()
    {
        // Arrange
        var categoryDtoUpdateSuccess = new CategoryDto(1, "Test", "Image.jpg", true);
        var categoryUpdateSuccess = new Category(1, "Test", "Image.jpg", true);

        _mapper.Map<Category>(categoryDtoUpdateSuccess).Returns(categoryUpdateSuccess);

        // Act
        await _categoryDtoService.UpdateAsync(categoryDtoUpdateSuccess);

        // Assert
        await _categoryRepository.Received(1).UpdateAsync(categoryUpdateSuccess);
    }

    [Fact]
    [Test]
    public async Task DeleteAsync_CallsRepositoryDeleteAsync_WhenCategoryExists()
    {
        // Arrange
        var categoryDelete = new Category(1, "Test", "Image.jpg", true);

        _categoryRepository.GetByIdAsync(1).Returns(categoryDelete);

        // Act
        await _categoryDtoService.DeleteAsync(1);

        // Assert
        await _categoryRepository.Received(1).DeleteAsync(categoryDelete);
    }

    [Fact]
    [Test]
    public async Task GetCategoriesWithProductDtoCountAsync_ReturnsMappedCategoriesWithProductCount_WhenCategoriesExist()
    {
        // Arrange
        var categoriesWithProductCount = new List<CategoryWithProductCount>
            {
                new("Category1", 10 )
            };
        var categoriesWithProductCountDto = new List<CategoryWithProductCountDto>
            {
                new("Category1", 10 )
            };

        _categoryRepository.GetCategoriesWithProductCountAsync().Returns(categoriesWithProductCount);
        _mapper.Map<List<CategoryWithProductCountDto>>(categoriesWithProductCount).Returns(categoriesWithProductCountDto);

        // Act
        var result = await _categoryDtoService.GetCategoriesWithProductDtoCountAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(categoriesWithProductCountDto, result);
    }
}
