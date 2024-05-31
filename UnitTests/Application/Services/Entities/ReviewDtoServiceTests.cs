using System.Net;
using Application.CustomExceptions;
using Application.Dtos.Reviews;
using Application.Errors;
using Application.Services.Entities;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Reviews;
using Domain.Interfaces;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.Services.Entities;

public class ReviewDtoServiceTests
{
    private readonly IMapper _mapper;
    private readonly IReviewRepository _repository;
    private readonly ReviewDtoService _reviewDtoService;

    protected ReviewDtoServiceTests()
    {
        _mapper = Substitute.For<IMapper>();
        _repository = Substitute.For<IReviewRepository>();
        _reviewDtoService = new ReviewDtoService(_repository, _mapper);
    }

    public class GetEntitiesAsyncTests : ReviewDtoServiceTests
    {
        [Fact]
        public async Task GetEntitiesAsync_ReturnsMappedReviews_WhenReviewsExist()
        {
            // Arrange
            var reviews = new List<Review> { new(1, "Great product!", "image.jpg", 1, new DateTime(), 1) };
            var reviewsDto = new List<ReviewDto>
                { new(1, "Great product!", "image.jpg", 1, new DateTime(), 1, new Product()) };

            _repository.GetEntitiesAsync().Returns(reviews);
            _mapper.Map<IEnumerable<ReviewDto>>(reviews).Returns(reviewsDto);

            // Act
            var result = await _reviewDtoService.GetEntitiesAsync();

            // Assert
            Assert.NotNull(result);
            var reviewDtos = result as ReviewDto[] ?? result.ToArray();
            Assert.Single(reviewDtos);
            Assert.Equal(reviewsDto, reviewDtos);
        }

        [Fact]
        public async Task GetEntitiesAsync_ReturnsEmptyList_WhenNoReviewsExist()
        {
            // Arrange
            _repository.GetEntitiesAsync().Returns(new List<Review>());

            // Act
            var result = await _reviewDtoService.GetEntitiesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }

    public class GetByIdAsyncTests : ReviewDtoServiceTests
    {
        [Fact]
        public async Task GetByIdAsync_ReturnsMappedReview_WhenReviewExists()
        {
            // Arrange
            var review = new Review(1, "Great product!", "image.jpg", 1, new DateTime(), 1);
            var reviewDto = new ReviewDto(1, "Great product!", "image.jpg", 1, new DateTime(), 1, new Product());

            _repository.GetByIdAsync(1).Returns(review);
            _mapper.Map<ReviewDto>(review).Returns(reviewDto);

            // Act
            var result = await _reviewDtoService.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(reviewDto, result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrowReviewException_WhenReviewNotFound()
        {
            // Arrange
            int? id = 1;
            _repository.GetByIdAsync(id).ReturnsNull();

            // Act & Assert
            await Assert.ThrowsAsync<ReviewException>(() => _reviewDtoService.GetByIdAsync(id));
        }
    }

    public class AddAsyncTests : ReviewDtoServiceTests
    {
        [Fact]
        public async Task AddAsync_CallsRepositoryCreateAsync_WhenReviewIsValid()
        {
            // Arrange
            var review = new Review(1, "Great product!", "image.jpg", 1, new DateTime(), 1);
            var reviewDto = new ReviewDto(1, "Great product!", "image.jpg", 1, new DateTime(), 1, new Product());

            _mapper.Map<Review>(reviewDto).Returns(review);

            // Act
            await _reviewDtoService.AddAsync(reviewDto);

            // Assert
            await _repository.Received(1).CreateAsync(review);
        }

        [Fact]
        public async Task AddAsync_ThrowsReviewException_WhenReviewIsInvalid()
        {
            // Arrange
            var reviewDto = new ReviewDto(1, "Great product!", "image.jpg", 1, new DateTime(), 1, new Product());

            _mapper.Map<Review>(reviewDto).Returns((Review?)null);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<ReviewException>(() => _reviewDtoService.AddAsync(reviewDto));
            Assert.Equal("An unexpected error occurred while processing the request.", ex.Message);
        }
    }

    public class UpdateAsyncTests : ReviewDtoServiceTests
    {
        [Fact]
        public async Task UpdateAsync_CallsRepositoryUpdateAsync_WhenReviewIsValid()
        {
            // Arrange
            var review = new Review(1, "Update Comment", "image.jpg", 1, new DateTime(), 1);
            var reviewDto = new ReviewDto(1, "Update Comment", "image.jpg", 1, new DateTime(), 1, new Product());

            _mapper.Map<Review>(reviewDto).Returns(review);

            // Act
            await _reviewDtoService.UpdateAsync(reviewDto);

            // Assert
            await _repository.Received(1).UpdateAsync(review);
        }

        [Fact]
        public async Task UpdateAsync_ThrowsReviewException_WhenReviewIsInvalid()
        {
            // Arrange
            var reviewDto = new ReviewDto(1, "Update Comment", "image.jpg", 1, new DateTime(), 1, new Product());

            _mapper.Map<Review>(reviewDto).Returns((Review?)null);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<ReviewException>(() => _reviewDtoService.UpdateAsync(reviewDto));
            Assert.Equal("An unexpected error occurred while processing the request.", ex.Message);
        }
    }

    public class DeleteAsyncTests : ReviewDtoServiceTests
    {
        [Fact]
        public async Task DeleteAsync_CallsRepositoryDeleteAsync_WhenReviewExists()
        {
            // Arrange
            var review = new Review(1, "Update Comment", "image.jpg", 1, new DateTime(), 1);

            _repository.GetByIdAsync(1).Returns(review);

            // Act
            await _reviewDtoService.DeleteAsync(1);

            // Assert
            await _repository.Received(1).DeleteAsync(review);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowArgumentNullException_WhenReviewDtoIsNull()
        {
            // Arrange
            int? id = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _reviewDtoService.DeleteAsync(id));
        }

        [Fact]
        public async Task DeleteAsync_ThrowsOrderException_WhenRepositoryThrowsException()
        {
            // Arrange
            int? id = 1;
            _repository.GetByIdAsync(id).ThrowsAsync(new Exception("Simulated exception"));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ReviewException>(() => _reviewDtoService.DeleteAsync(id));
            Assert.Equal("An unexpected error occurred while processing the request.", exception.Message);
            Assert.NotNull(exception.InnerException);
            Assert.IsType<Exception>(exception.InnerException);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowRequestException_WhenReviewNotFound()
        {
            // Arrange
            int? id = 1;
            _repository.GetByIdAsync(id).ReturnsNull();

            // Act & Assert
            var ex = await Assert.ThrowsAsync<ReviewException>(() => _reviewDtoService.DeleteAsync(id));

            var innerException = Assert.IsType<RequestException>(ex.InnerException);

            Assert.Equal("Error when removing review.", innerException.Message);
            Assert.Equal(HttpStatusCode.BadRequest, innerException.StatusCode);
            Assert.Equal("Error", innerException.Severity);
        }
    }

    public class ReviewIdNullTests
    {
        [Fact]
        public void ReviewIdNull_ShouldThrowArgumentNullException_WhenIdIsNull()
        {
            // Arrange
            int? id = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => ReviewDtoService.ReviewIdNull(id));
        }

        [Fact]
        public void ReviewIdNull_ShouldNotThrowException_WhenIdIsNotNull()
        {
            // Arrange
            int? id = 1;

            // Act & Assert
            Assert.Null(Record.Exception(() => ReviewDtoService.ReviewIdNull(id)));
        }
    }

    public class ReviewNullTests
    {
        [Fact]
        public void ReviewNull_ShouldThrowArgumentNullException_WhenReviewDtoIsNull()
        {
            // Arrange
            ReviewDto? reviewDto = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => ReviewDtoService.ReviewNull(reviewDto));
        }

        [Fact]
        public void ReviewNull_ShouldNotThrowException_WhenReviewDtoIsNotNull()
        {
            // Arrange
            var review = new ReviewDto(1, "Update Comment", "image.jpg", 1, new DateTime(), 1, new Product());

            // Act & Assert
            Assert.Null(Record.Exception(() => ReviewDtoService.ReviewNull(review)));
        }
    }
}