using Application.Dtos.Reviews;
using Application.Mappings;
using AutoMapper;
using Domain.Entities.Reviews;
using FluentAssertions;
using Xunit;

namespace UnitTests.Application.Mappings;

public class MappingTheReviewProfileTests
{
    private readonly IMapper _mapper;

    public MappingTheReviewProfileTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingTheReviewProfile>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Should_Map_Review_To_ReviewDto()
    {
        // Arrange
        var review = new Review(
            id: 1,
            comment: "Great product!",
            image: "image1.jpg",
            rating: 5,
            reviewDate: new DateTime(2023, 5, 1),
            productId: 10
        );

        // Act
        var reviewDto = _mapper.Map<ReviewDto>(review);

        // Assert
        reviewDto.Id.Should().Be(review.Id);
        reviewDto.Comment.Should().Be(review.Comment);
        reviewDto.Image.Should().Be(review.Image);
        reviewDto.Rating.Should().Be(review.Rating);
        reviewDto.ReviewDate.Should().Be(review.ReviewDate);
        reviewDto.ProductId.Should().Be(review.ProductId);
        reviewDto.Product.Should().BeNull();
    }

    [Fact]
    public void Should_Map_ReviewDto_To_Review()
    {
        // Arrange
        var reviewDto = new ReviewDto(
            Id: 1,
            Comment: "Great product!",
            Image: "image1.jpg",
            Rating: 5,
            ReviewDate: new DateTime(2023, 5, 1),
            ProductId: 10,
            Product: null
        );

        // Act
        var review = _mapper.Map<Review>(reviewDto);

        // Assert
        review.Id.Should().Be(reviewDto.Id);
        review.Comment.Should().Be(reviewDto.Comment);
        review.Image.Should().Be(reviewDto.Image);
        review.Rating.Should().Be(reviewDto.Rating);
        review.ReviewDate.Should().Be(reviewDto.ReviewDate);
        review.ProductId.Should().Be(reviewDto.ProductId);
        review.Product.Should().BeNull();
    }
}
