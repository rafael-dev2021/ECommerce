using Domain.Entities;
using Domain.Entities.Products.Fashion.Shoes;
using Domain.Entities.Reviews;
using Infra_Data.Context;
using Infra_Data.Repositories.Products.Fashion;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Repositories.Products.Fashion;

public abstract class ShoesRepositoryTests
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
        public async Task GetEntitiesAsync_ShouldReturnListOfShoesWithCategoryAndReviews()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ShoesRepository(context);

            var categories = new List<Category>
            {
                new(1, "Category1", "imageUrl1", true),
                new(2, "Category2", "imageUrl2", true)
            };
            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();

            var reviews = new List<Review>
            {
                new(1, "Good shoes", "image1", 5, DateTime.Now, 1),
                new(2, "Nice shoes", "image2", 4, DateTime.Now, 2)
            };
            context.Reviews.AddRange(reviews);
            await context.SaveChangesAsync();

            var shoes = new List<Shoe>
            {
                new(1, "Shoes", "Description1", [], 10, 1),
                new(2, "Shoes", "Description2", [], 20, 1),
                new(3, "Shoes", "Description3", [], 30, 2)
            };
            context.Shoes.AddRange(shoes);
            await context.SaveChangesAsync();

            foreach (var shoe in shoes)
            {
                var shoeReviews = reviews.Where(r => r.ProductId == shoe.Id).ToList();
                foreach (var review in shoeReviews)
                {
                    shoe.Reviews.Add(review);
                }
            }

            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetEntitiesAsync();

            // Assert
            Assert.NotNull(result);
            var enumerable = result as Shoe[] ?? result.ToArray();
            Assert.Equal(3, enumerable.Length);
        }
    }

    public class GetByIdAsyncTests
    {
        [Fact]
        public async Task GetByIdAsync_ShouldReturnShoe()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ShoesRepository(context);

            var shoe = new Shoe(1, "Shoes", "Description", [], 10, 1);

            context.Shoes.Add(shoe);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Shoes", result.Name);
        }
    }
    
    public class CreateAsyncTests
    {
        [Fact]
        public async Task CreateAsync_ShouldAddShoe()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ShoesRepository(context);

            var shoe = new Shoe(3, "Shoe", "Description", [], 10, 1);

            // Act
            var result = await repository.CreateAsync(shoe);

            // Assert
            Assert.Equal(3, result.Id);
            Assert.Equal("Shoe", result.Name);

            var shoeInDb = await context.Shoes.FindAsync(3);
            Assert.NotNull(shoeInDb);
            Assert.Equal("Shoe", shoeInDb.Name);
        }
    }

    public class UpdateAsyncTests
    {
        [Fact]
        public async Task UpdateAsync_ShouldUpdateShoe()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ShoesRepository(context);

            var shoe = new Shoe(1, "Shoe", "Description", [], 10, 1);

            context.Shoes.Add(shoe);
            await context.SaveChangesAsync();

            shoe.SetName("UpdatedShoe");

            // Act
            var result = await repository.UpdateAsync(shoe);

            // Assert
            Assert.Equal("UpdatedShoe", result.Name);

            var updatedShoeInDb = await context.Shoes.FindAsync(1);
            Assert.NotNull(updatedShoeInDb);
            Assert.Equal("UpdatedShoe", updatedShoeInDb.Name);
        }
    }

    public class DeleteAsyncTests
    {
        [Fact]
        public async Task DeleteAsync_ShouldRemoveShoe()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ShoesRepository(context);

            var shoe = new Shoe(1, "Shoe", "Description", [], 10, 1);

            context.Shoes.Add(shoe);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.DeleteAsync(shoe);

            // Assert
            Assert.Equal(1, result.Id);

            var shoeInDb = await context.Shoes.FindAsync(1);
            Assert.Null(shoeInDb);
        }
    }
}