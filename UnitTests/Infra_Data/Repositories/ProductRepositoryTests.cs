using Domain.Entities;
using Domain.Entities.ObjectValues.ProductObjectValue;
using Infra_Data.Context;
using Infra_Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Repositories;

public class ProductRepositoryTests
{
    private static AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"TestDatabase-{Guid.NewGuid()}")
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task GetProductsAsync_ShouldReturnProducts()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new ProductRepository(context);

        var category = new Category(1, "Category1", "image.jpg", true);
        var products = new List<Product>
        {
            new(1, "Product1", "Description1", [], 10, category.Id),
            new(2, "Product2", "Description2", [], 5, category.Id)
        };

        context.Categories.Add(category);
        context.Products.AddRange(products);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetProductsAsync();

        // Assert
        var enumerable = result as Product[] ?? result.ToArray();
        Assert.Equal(2, enumerable.Length);
        Assert.Contains(enumerable, p => p.Name == "Product1");
        Assert.Contains(enumerable, p => p.Name == "Product2");
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnProduct()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new ProductRepository(context);

        var category = new Category(1, "Category1", "image.jpg", true);
        var product = new Product(1, "Product1", "Description1", [], 10, category.Id);

        context.Categories.Add(category);
        context.Products.Add(product);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Product1", result.Name);
    }

    [Fact]
    public async Task GetProductsFavoritesAsync_ShouldReturnFavoriteProducts()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new ProductRepository(context);

        var category = new Category(1, "Category1", "image.jpg", true);
        var favoriteProduct = new Product(1, "Product1", "Description1", [], 10, category.Id);
        var nonFavoriteProduct = new Product(2, "Product2", "Description2", [], 5, category.Id);

        favoriteProduct.SetFlagsObjectValue(new FlagsObjectValue());
        favoriteProduct.FlagsObjectValue?.SetIsFavorite(true);

        nonFavoriteProduct.SetFlagsObjectValue(new FlagsObjectValue());
        nonFavoriteProduct.FlagsObjectValue?.SetIsFavorite(false);

        context.Categories.Add(category);
        context.Products.AddRange(favoriteProduct, nonFavoriteProduct);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetProductsFavoritesAsync();

        // Assert
        var collection = result as Product[] ?? result.ToArray();
        Assert.Single(collection);
        Assert.Contains(collection, p => p.Name == "Product1" && p.FlagsObjectValue?.IsFavorite == true);
    }

    [Fact]
    public async Task GetProductsDailyOffersAsync_ShouldReturnDailyOfferProducts()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new ProductRepository(context);

        var category = new Category(1, "Category1", "image.jpg", true);
        var dailyOfferProduct = new Product(1, "Product1", "Description1", [], 10, category.Id);
        var nonDailyOfferProduct = new Product(2, "Product2", "Description2", [], 5, category.Id);

        dailyOfferProduct.SetFlagsObjectValue(new FlagsObjectValue());
        dailyOfferProduct.FlagsObjectValue?.SetIsDailyOffer(true);

        nonDailyOfferProduct.SetFlagsObjectValue(new FlagsObjectValue());
        nonDailyOfferProduct.FlagsObjectValue?.SetIsDailyOffer(false);

        context.Categories.Add(category);
        context.Products.AddRange(dailyOfferProduct, nonDailyOfferProduct);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetProductsDailyOffersAsync();

        // Assert
        var collection = result as Product[] ?? result.ToArray();
        Assert.Single(collection);
        Assert.Contains(collection, p => p.Name == "Product1" && p.FlagsObjectValue?.IsDailyOffer == true);
    }

    [Fact]
    public async Task GetProductsBestSellersAsync_ShouldReturnBestSellerProducts()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new ProductRepository(context);

        var category = new Category(1, "Category1", "image.jpg", true);
        var bestSellerProduct = new Product(1, "Product1", "Description1", [], 10, category.Id);
        var nonBestSellerProduct = new Product(2, "Product2", "Description2", [], 5, category.Id);

        bestSellerProduct.SetFlagsObjectValue(new FlagsObjectValue());
        bestSellerProduct.FlagsObjectValue?.SetIsBestSeller(true);

        nonBestSellerProduct.SetFlagsObjectValue(new FlagsObjectValue());
        nonBestSellerProduct.FlagsObjectValue?.SetIsBestSeller(false);

        context.Categories.Add(category);
        context.Products.AddRange(bestSellerProduct, nonBestSellerProduct);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetProductsBestSellersAsync();

        // Assert
        var collection = result as Product[] ?? result.ToArray();
        Assert.Single(collection);
        Assert.Contains(collection, p => p.Name == "Product1" && p.FlagsObjectValue?.IsBestSeller == true);
    }

    [Fact]
    public async Task GetProductsByCategoriesAsync_ShouldReturnProductsInCategory()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new ProductRepository(context);

        var category1 = new Category(1, "Category1", "image.jpg", true);
        var category2 = new Category(2, "Category2", "image.jpg", true);
        var products = new List<Product>
        {
            new(1, "Product1", "Description1", [], 10, category1.Id),
            new(2, "Product2", "Description2", [], 5, category2.Id)
        };

        context.Categories.AddRange(category1, category2);
        context.Products.AddRange(products);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetProductsByCategoriesAsync("Category1");

        // Assert
        var collection = result as Product[] ?? result.ToArray();
        Assert.Single(collection);
        Assert.Contains(collection, p => p.Name == "Product1" && p.Category?.Name == "Category1");
    }

    [Fact]
    public async Task GetSearchProductAsync_ShouldReturnFilteredProducts()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var repository = new ProductRepository(context);

        var category = new Category(1, "Category1", "image.jpg", true);
        var product1 = new Product(1, "Product1", "Description1", [], 10, category.Id);
        var product2 = new Product(2, "Product2", "Description2", [], 5, category.Id);

        var specification1 = new SpecificationObjectValue();
        specification1.SetBrand("BrandA");
        specification1.SetModel("ModelA");

        var specification2 = new SpecificationObjectValue();
        specification2.SetBrand("BrandB");
        specification2.SetModel("ModelB");

        product1.SetSpecificationObjectValue(specification1);
        product2.SetSpecificationObjectValue(specification2);

        context.Categories.Add(category);
        context.Products.AddRange(product1, product2);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetSearchProductAsync("BrandA");

        // Assert
        var collection = result as Product[] ?? result.ToArray();
        Assert.Single(collection);
        Assert.Contains(collection, p => p.Name == "Product1" && p.SpecificationObjectValue?.Brand == "BrandA");
    }
}