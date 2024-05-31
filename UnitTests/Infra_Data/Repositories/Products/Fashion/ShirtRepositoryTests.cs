using Domain.Entities;
using Domain.Entities.Products.Fashion.T_Shirts;
using Domain.Entities.Reviews;
using Infra_Data.Context;
using Infra_Data.Repositories.Products.Fashion;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Repositories.Products.Fashion;

public abstract class ShirtRepositoryTests
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
        public async Task GetEntitiesAsync_ShouldReturnListOfShirtsWithCategoryAndReviews()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ShirtRepository(context);

            var categories = new List<Category>
            {
                new(1, "Category1", "imageUrl1", true),
                new(2, "Category2", "imageUrl2", true)
            };
            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();

            var reviews = new List<Review>
            {
                new(1, "Good shirt", "image1", 5, DateTime.Now, 1),
                new(2, "Nice design", "image2", 4, DateTime.Now, 2)
            };
            context.Reviews.AddRange(reviews);
            await context.SaveChangesAsync();

            var shirts = new List<Shirt>
            {
                new(1, "Shirt1", "Description1", [], 10, 1),
                new(2, "Shirt2", "Description2", [], 20, 1),
                new(3, "Shirt3", "Description3", [], 30, 2)
            };
            context.Shirts.AddRange(shirts);
            await context.SaveChangesAsync();

            foreach (var shirt in shirts)
            {
                var shirtReviews = reviews.Where(r => r.ProductId == shirt.Id).ToList();
                foreach (var review in shirtReviews)
                {
                    shirt.Reviews.Add(review);
                }
            }

            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetEntitiesAsync();

            // Assert
            Assert.NotNull(result);
            var enumerable = result as Shirt[] ?? result.ToArray();
            Assert.Equal(3, enumerable.Length);
        }
    }

    public class GetByIdAsyncTests
    {
        [Fact]
        public async Task GetByIdAsync_ShouldReturnShirt()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ShirtRepository(context);

            var shirt = new Shirt(1, "Shirt1", "Description", [], 10, 1);

            context.Shirts.Add(shirt);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Shirt1", result.Name);
        }
    }

    public class CreateAsyncTests
    {
        [Fact]
        public async Task CreateAsync_ShouldAddShirt()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ShirtRepository(context);

            var shirt = new Shirt(3, "Shirt3", "Description", [], 10, 1);

            // Act
            var result = await repository.CreateAsync(shirt);

            // Assert
            Assert.Equal(3, result.Id);
            Assert.Equal("Shirt3", result.Name);

            var shirtInDb = await context.Shirts.FindAsync(3);
            Assert.NotNull(shirtInDb);
            Assert.Equal("Shirt3", shirtInDb.Name);
        }
    }

    public class UpdateAsyncTests
    {
        [Fact]
        public async Task UpdateAsync_ShouldUpdateShirt()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ShirtRepository(context);

            var shirt = new Shirt(1, "Shirt1", "Description", [], 10, 1);

            context.Shirts.Add(shirt);
            await context.SaveChangesAsync();

            shirt.SetName("UpdatedShirt1");

            // Act
            var result = await repository.UpdateAsync(shirt);

            // Assert
            Assert.Equal("UpdatedShirt1", result.Name);

            var updatedShirtInDb = await context.Shirts.FindAsync(1);
            Assert.NotNull(updatedShirtInDb);
            Assert.Equal("UpdatedShirt1", updatedShirtInDb.Name);
        }
    }

    public class DeleteAsyncTests
    {
        [Fact]
        public async Task DeleteAsync_ShouldRemoveShirt()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ShirtRepository(context);

            var shirt = new Shirt(1, "Shirt1", "Description", [], 10, 1);

            context.Shirts.Add(shirt);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.DeleteAsync(shirt);

            // Assert
            Assert.Equal(1, result.Id);

            var shirtInDb = await context.Shirts.FindAsync(1);
            Assert.Null(shirtInDb);
        }
    }
}