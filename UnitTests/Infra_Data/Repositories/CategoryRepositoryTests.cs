using Domain.Entities;
using Infra_Data.Context;
using Infra_Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Repositories;

public class CategoryRepositoryTests
{

    private static AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"TestDatabase-{Guid.NewGuid()}")
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task GetEntitiesAsync_ShouldReturnCategories()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new CategoryRepository(context);

        var categories = new List<Category>
            {
                new(1, "Category1", "image.jpg", true),
                new(2, "Category2", "image.jpg", true)
            };

        context.Categories.AddRange(categories);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetEntitiesAsync();

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Contains(result, c => c.Name == "Category1");
        Assert.Contains(result, c => c.Name == "Category2");
    }

    [Fact]
    public async Task CreateAsync_ShouldAddCategory()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new CategoryRepository(context);

        var category = new Category(3, "Category3", "image.jpg", true);

        // Act
        var result = await repository.CreateAsync(category);

        // Assert
        Assert.Equal(3, result.Id);
        Assert.Equal("Category3", result.Name);

        var categoryInDb = await context.Categories.FindAsync(3);
        Assert.NotNull(categoryInDb);
        Assert.Equal("Category3", categoryInDb.Name);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCategory()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new CategoryRepository(context);

        var category = new Category(1, "Category1", "image.jpg", true);
        context.Categories.Add(category);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Category1", result.Name);
    }

    [Fact]
    public async Task GetCategoriesWithProductCountAsync_ShouldReturnCategoriesWithProductCount()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new CategoryRepository(context);

        var categories = new List<Category>
            {
                new(1, "Category1", "image.jpg", true),
                new(2, "Category2", "image.jpg", true)
            };

        context.Categories.AddRange(categories);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetCategoriesWithProductCountAsync();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(result, c => c.CategoryName == "Category1" && c.ProductCount == 0);
        Assert.Contains(result, c => c.CategoryName == "Category2" && c.ProductCount == 0);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateCategory()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new CategoryRepository(context);

        var category = new Category(1, "Category1", "image.jpg", true);
        context.Categories.Add(category);
        await context.SaveChangesAsync();

        category.SetName("UpdatedCategory1");

        // Act
        var result = await repository.UpdateAsync(category);

        // Assert
        Assert.Equal("UpdatedCategory1", result.Name);

        var updatedCategoryInDb = await context.Categories.FindAsync(1);
        Assert.NotNull(updatedCategoryInDb);
        Assert.Equal("UpdatedCategory1", updatedCategoryInDb.Name);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveCategory()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new CategoryRepository(context);

        var category = new Category(1, "Category1", "image.jpg", true);
        context.Categories.Add(category);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.DeleteAsync(category);

        // Assert
        Assert.Equal(1, result.Id);

        var categoryInDb = await context.Categories.FindAsync(1);
        Assert.Null(categoryInDb);
    }
}
