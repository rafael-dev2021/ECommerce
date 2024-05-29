using Application.Dtos;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos;

public class CategoryDtoTests
{
    [Fact]
    public void CategoryDto_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        int id = 1;
        string name = "Test Category";
        string imageUrl = "testImageUrl.jpg";
        bool isActive = true;

        // Act
        var categoryDto = new CategoryDto(id, name, imageUrl, isActive);

        // Assert
        Assert.Equal(id, categoryDto.Id);
        Assert.Equal(name, categoryDto.Name);
        Assert.Equal(imageUrl, categoryDto.ImageUrl);
        Assert.Equal(isActive, categoryDto.IsActive);
    }

    [Fact]
    public void CategoryDto_Equals_ShouldReturnTrue_WhenEqual()
    {
        // Arrange
        var categoryDto1 = new CategoryDto(1, "Test", "test.jpg", true);
        var categoryDto2 = new CategoryDto(1, "Test", "test.jpg", true);

        // Act
        var result = categoryDto1.Equals(categoryDto2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CategoryDto_Equals_ShouldReturnFalse_WhenNotEqual()
    {
        // Arrange
        var categoryDto1 = new CategoryDto(1, "Test", "test.jpg", true);
        var categoryDto2 = new CategoryDto(2, "Test2", "test2.jpg", false);

        // Act
        var result = categoryDto1.Equals(categoryDto2);

        // Assert
        Assert.False(result);
    }
}
