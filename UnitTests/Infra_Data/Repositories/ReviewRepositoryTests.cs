using Domain.Entities;
using Domain.Entities.Payments;
using Domain.Entities.Reviews;
using Infra_Data.Context;
using Infra_Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Repositories;

public abstract class ReviewRepositoryTests
{
    private static AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"TestDatabase-{Guid.NewGuid()}")
            .Options;

        return new AppDbContext(options);
    }

    public class GetEntitiesAsyncTests
    {
        [Fact]
        public async Task GetEntitiesAsync_ShouldReturnReviews()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ReviewRepository(context);

            var product = new Product(1, "Product1", "Description1", [], 10, 1);
            var review1 = new Review(1, "Comment1", "Image1", 5, DateTime.Now, 1);
            var review2 = new Review(2, "Comment2", "Image2", 4, DateTime.Now, 1);

            context.Products.Add(product);
            context.Reviews.AddRange(review1, review2);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetEntitiesAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }
    }

    public class GetByIdAsyncTests
    {
        [Fact]
        public async Task GetByIdAsync_ShouldReturnReview()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ReviewRepository(context);

            var product = new Product(1, "Product1", "Description1", [], 10, 1);
            var review = new Review(1, "Comment1", "Image1", 5, DateTime.Now, product.Id);

            context.Products.Add(product);
            context.Reviews.Add(review);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
        }
    }

    public class CreateAsyncTests
    {
        [Fact]
        public async Task CreateAsync_ShouldCreateReview()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ReviewRepository(context);

            var review = new Review(1, "Comment1", "Image1", 5, DateTime.Now, 1);

            // Act
            var result = await repository.CreateAsync(review);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }
    }

    public class UpdateAsyncTests
    {
        [Fact]
        public async Task UpdateAsync_ShouldUpdateReview()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ReviewRepository(context);

            var review = new Review(1, "Comment1", "Image1", 5, DateTime.Now, 1);
            await repository.CreateAsync(review);

            // Modify the review properties
            review.SetComment("Updated Comment");
            review.SetRating(4);

            // Act
            var result = await repository.UpdateAsync(review);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Updated Comment", result.Comment);
            Assert.Equal(4, result.Rating);
        }
    }

    public class DeleteAsyncTests
    {
        [Fact]
        public async Task DeleteAsync_ShouldDeleteReview()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ReviewRepository(context);

            var review = new Review(1, "Comment1", "Image1", 5, DateTime.Now, 1);
            await repository.CreateAsync(review);

            // Act
            var result = await repository.DeleteAsync(review);

            // Assert
            Assert.NotNull(result);
        }
    }
}