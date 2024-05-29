using Application.Dtos;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos;

public class CategoryWithProductCountDtoTests
{
    [Fact]
    public void CategoryWithProductCountDto_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        string categoryName = "Test Category";
        int productCount = 10;

        // Act
        var categoryWithProductCountDto = new CategoryWithProductCountDto(categoryName, productCount);

        // Assert
        Assert.Equal(categoryName, categoryWithProductCountDto.CategoryName);
        Assert.Equal(productCount, categoryWithProductCountDto.ProductCount);
    }
}
