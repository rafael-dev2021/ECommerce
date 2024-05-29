using Application.Dtos;
using Application.Dtos.ObjectsValues.ProductObjectValue;
using Application.Dtos.Reviews;
using Application.Services.Discounts;
using Domain.Entities;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos;

public class ProductDtoTests
{
    [Fact]
    public void CalculateWeightedAverage_ShouldCalculateWeightedAverage()
    {
        // Arrange
        var productDto = new ProductDto();
        var reviewDto1 = new ReviewDto(1, "Great product!", "image.jpg", 4, new DateTime(), 1,new Product());
        var reviewDto2 = new ReviewDto(1, "Great product!", "image.jpg", 5, new DateTime(), 1, new Product());
        productDto.Reviews.Add(reviewDto1);
        productDto.Reviews.Add(reviewDto2);

        // Act
        var result = productDto.CalculateWeightedAverage();

        // Assert
        Assert.Equal(4.5, result.WeightedAverage);
    }

    [Fact]
    public void CategoryId_ShouldSetAndGetCorrectly()
    {
        // Arrange
        var productDto = new ProductDto();
        var categoryId = 123;

        // Act
        productDto.CategoryId = categoryId;
        var result = productDto.CategoryId;

        // Assert
        Assert.Equal(categoryId, result);
    }

    [Fact]
    public void Category_ShouldSetAndGetCorrectly()
    {
        // Arrange
        var productDto = new ProductDto();
        var category = new Category(1, "TestCategory", "TestImageUrl", true);

        // Act
        productDto.Category = category;
        var result = productDto.Category;

        // Assert
        Assert.Equal(category, result);
    }

    [Fact]
    public void WarrantyObjectValue_ShouldSetAndGetCorrectly()
    {
        // Arrange
        var productDto = new ProductDto();
        var warrantyObjectValue = new WarrantyDtoObjectValue("1 year", "Test warranty information");

        // Act
        productDto.WarrantyObjectValue = warrantyObjectValue;
        var result = productDto.WarrantyObjectValue;

        // Assert
        Assert.Equal(warrantyObjectValue, result);
    }

    [Fact]
    public void CommonPropertiesObjectValue_ShouldSetAndGetCorrectly()
    {
        // Arrange
        var productDto = new ProductDto();
        var commonPropertiesObjectValue = new CommonPropertiesDtoObjectValue("Male", "Blue", "Adult", "Casual", "XL");

        // Act
        productDto.CommonPropertiesObjectValue = commonPropertiesObjectValue;
        var result = productDto.CommonPropertiesObjectValue;

        // Assert
        Assert.Equal(commonPropertiesObjectValue, result);
    }

    [Fact]
    public void DataObjectValue_ShouldSetAndGetCorrectly()
    {
        // Arrange
        var productDto = new ProductDto();
        var dataObjectValue = new DataDtoObjectValue("January", 2024);

        // Act
        productDto.DataObjectValue = dataObjectValue;
        var result = productDto.DataObjectValue;

        // Assert
        Assert.Equal(dataObjectValue, result);
    }

    [Fact]
    public void FlagsObjectValue_ShouldSetAndGetCorrectly()
    {
        // Arrange
        var productDto = new ProductDto();
        var flagsObjectValue = new FlagsDtoObjectValue(true, false, true);

        // Act
        productDto.FlagsObjectValue = flagsObjectValue;
        var result = productDto.FlagsObjectValue;

        // Assert
        Assert.Equal(flagsObjectValue, result);
    }

    [Fact]
    public void PriceObjectValue_ShouldSetAndGetCorrectly()
    {
        // Arrange
        var productDto = new ProductDto();
        var priceObjectValue = new PriceDtoObjectValue(99.99m, 89.99m);

        // Act
        productDto.PriceObjectValue = priceObjectValue;
        var result = productDto.PriceObjectValue;

        // Assert
        Assert.Equal(priceObjectValue, result);
    }

    [Fact]
    public void Reviews_ShouldSetAndGetCorrectly()
    {
        // Arrange
        var productDto = new ProductDto();
        var reviewDto1 = new ReviewDto(1, "Great product!", "image.jpg", 4, new DateTime(), 1, new Product());
        var reviewDto2 = new ReviewDto(1, "Great product!", "image.jpg", 5, new DateTime(), 1, new Product());
        var reviews = new List<ReviewDto> { reviewDto1, reviewDto2 };

        // Act
        productDto.Reviews = reviews;
        var result = productDto.Reviews;

        // Assert
        Assert.Equal(reviews, result);
    }

    [Fact]
    public void CalculateDiscountService_ReturnsValidInstance()
    {
        // Act
        var result = ProductDto.CalculateDiscountService();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<CalculateDiscountService>(result);
    }
}

