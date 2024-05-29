using Application.CustomExceptions;
using Application.Dtos;
using Application.Errors;
using Application.Services.Entities;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Services.Entities;

public class CategoryDtoServiceTests
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;
    private readonly CategoryDtoService _categoryDtoService;
    private readonly string _message = "An unexpected error occurred while processing the request.";

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
    public async Task GetByIdAsync_ShouldThrowCategoryException_WhenCategoryNotFound()
    {
        // Arrange
        int? id = 1;
        _categoryRepository.GetByIdAsync(id).ReturnsNull();

        // Act & Assert
        await Assert.ThrowsAsync<CategoryException>(() => _categoryDtoService.GetByIdAsync(id));
    }

    [Fact]
    [Test]
    public async Task GetByIdAsync_ShouldReturnMappedCategoryDto_WhenCategoryFound()
    {
        // Arrange
        int? id = 1;
        var category = new Category(1, "Test", "Image.jpg", true);
        var categoryDto = new CategoryDto(1, "Test", "Image.jpg", true);

        _categoryRepository.GetByIdAsync(id).Returns(category);
        _mapper.Map<CategoryDto>(category).Returns(categoryDto);

        // Act
        var result = await _categoryDtoService.GetByIdAsync(id);

        // Assert
        Assert.NotNull(result);
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
    public async Task AddAsync_ShouldThrowArgumentNullException_WhenCategoryDtoIsNull()
    {
        // Arrange
        CategoryDto? nullCategoryDto = null;

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _categoryDtoService.AddAsync(nullCategoryDto));
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
    public async Task UpdateAsync_ShouldThrowArgumentNullException_WhenCategoryDtoIsNull()
    {
        // Arrange
        CategoryDto? nullCategoryDto = null;

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _categoryDtoService.UpdateAsync(nullCategoryDto));
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
    public async Task DeleteAsync_ShouldThrowArgumentNullException_WhenCategoryDtoIsNull()
    {
        // Arrange
        int? id = null;

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _categoryDtoService.DeleteAsync(id));
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

    [Fact]
    [Test]
    public async Task GetCategoriesWithProductDtoCountAsync_ReturnsEmptyList_WhenCategoriesWithProductCountIsNull()
    {

        // Mocking the repository call
        _categoryRepository.GetCategoriesWithProductCountAsync().ReturnsNull();

        // Act
        var result = await _categoryDtoService.GetCategoriesWithProductDtoCountAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    [Test]
    public async Task GetCategoriesWithProductDtoCountAsync_ReturnsEmptyList_WhenCategoriesWithProductCountIsEmpty()
    {
        // Arrange
        List<CategoryWithProductCount> emptyCategoriesWithProductCount = [];

        // Mocking the repository call
        _categoryRepository.GetCategoriesWithProductCountAsync().Returns(Task.FromResult(emptyCategoriesWithProductCount));

        // Act
        var result = await _categoryDtoService.GetCategoriesWithProductDtoCountAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    [Test]
    public async Task GetByIdAsync_ShouldThrowCategoryException_WhenRepositoryThrowsException()
    {
        // Arrange
        int categoryId = 1;
        _categoryRepository.GetByIdAsync(categoryId).Returns(Task.FromException<Category>(new Exception(_message)));

        // Act & Assert
        await Assert.ThrowsAsync<CategoryException>(async () => await _categoryDtoService.GetByIdAsync(categoryId));
    }

    [Fact]
    [Test]
    public async Task AddAsync_ShouldThrowCategoryException_WhenRepositoryThrowsException()
    {
        // Arrange
        var categoryDto = new CategoryDto(1, "Name", "image.jpg", true);
        _categoryRepository.When(repo => repo.CreateAsync(Arg.Any<Category>())).Do(x => throw new Exception(_message));

        // Act & Assert
        await Assert.ThrowsAsync<CategoryException>(async () => await _categoryDtoService.AddAsync(categoryDto));
    }

    [Fact]
    [Test]
    public async Task UpdateAsync_ShouldThrowCategoryException_WhenRepositoryThrowsException()
    {
        // Arrange
        var categoryDto = new CategoryDto(1, "Name", "image.jpg", true);
        _categoryRepository.When(repo => repo.UpdateAsync(Arg.Any<Category>())).Do(x => throw new Exception(_message));

        // Act & Assert
        await Assert.ThrowsAsync<CategoryException>(async () => await _categoryDtoService.UpdateAsync(categoryDto));
    }

    [Fact]
    [Test]
    public async Task DeleteAsync_ShouldThrowCategoryException_WhenRepositoryThrowsException()
    {
        // Arrange
        int? categoryId = 1;
        _categoryRepository.GetByIdAsync(categoryId).ThrowsAsync(new Exception(_message));

        // Act & Assert
        await Assert.ThrowsAsync<CategoryException>(async () => await _categoryDtoService.DeleteAsync(categoryId));
    }

    [Fact]
    [Test]
    public void CategoryIdNull_ShouldThrowArgumentNullException_WhenIdIsNull()
    {
        // Arrange
        int? id = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => CategoryDtoService.CategoryIdNull(id));
    }

    [Fact]
    [Test]
    public void CategoryIdNull_ShouldNotThrowException_WhenIdIsNotNull()
    {
        // Arrange
        int? id = 1;

        // Act & Assert
        Assert.Null(Record.Exception(() => CategoryDtoService.CategoryIdNull(id)));
    }

    [Fact]
    [Test]
    public void CategoryNull_ShouldThrowArgumentNullException_WhenCategoryDtoIsNull()
    {
        // Arrange
        CategoryDto? categoryDto = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => CategoryDtoService.CategoryNull(categoryDto));
    }

    [Fact]
    [Test]
    public void CategoryNull_ShouldNotThrowException_WhenCategoryDtoIsNotNull()
    {
        // Arrange
        var categoryDto = new CategoryDto(1, "Name", "image.jpg", true);

        // Act & Assert
        Assert.Null(Record.Exception(() => CategoryDtoService.CategoryNull(categoryDto)));
    }
}
