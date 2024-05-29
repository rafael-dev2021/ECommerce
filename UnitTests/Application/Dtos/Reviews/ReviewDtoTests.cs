using Application.Dtos.Reviews;
using Domain.Entities;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Dtos.Reviews;

public class ReviewDtoTests
{
    [Fact]
    public void ReviewDto_ShouldCreateInstanceWithCorrectValues()
    {
        // Arrange
        int id = 1;
        string comment = "Great product!";
        string image = "product.jpg";
        int rating = 5;
        DateTime reviewDate = DateTime.Now;
        int productId = 123;
        Product product = new();

        // Act
        var reviewDto = new ReviewDto(id, comment, image, rating, reviewDate, productId, product);

        // Assert
        Assert.Equal(id, reviewDto.Id);
        Assert.Equal(comment, reviewDto.Comment);
        Assert.Equal(image, reviewDto.Image);
        Assert.Equal(rating, reviewDto.Rating);
        Assert.Equal(reviewDate, reviewDto.ReviewDate);
        Assert.Equal(productId, reviewDto.ProductId);
        Assert.Equal(product, reviewDto.Product);
    }
}
