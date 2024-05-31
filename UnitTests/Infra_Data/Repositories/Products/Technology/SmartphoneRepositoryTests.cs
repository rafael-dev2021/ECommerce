using Domain.Entities;
using Domain.Entities.Products.Technology.Smartphones;
using Domain.Entities.Reviews;
using Infra_Data.Context;
using Infra_Data.Repositories.Products.Technology;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Repositories.Products.Technology;

public abstract class SmartphoneRepositoryTests
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
        public async Task GetEntitiesAsync_ShouldReturnListOfSmartphonesWithCategoryAndReviews()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new SmartphoneRepository(context);

            var categories = new List<Category>
            {
                new(1, "Category1", "imageUrl1", true),
                new(2, "Category2", "imageUrl2", true)
            };
            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();

            var reviews = new List<Review>
            {
                new(1, "Good phone", "image1", 5, DateTime.Now, 1),
                new(2, "Nice phone", "image2", 4, DateTime.Now, 2)
            };
            context.Reviews.AddRange(reviews);
            await context.SaveChangesAsync();

            var smartphones = new List<Smartphone>
            {
                new(1, "Phone1", "Description1", [], 10, 1),
                new(2, "Phone2", "Description2", [], 20, 1),
                new(3, "Phone3", "Description3", [], 30, 2)
            };
            context.Smartphones.AddRange(smartphones);
            await context.SaveChangesAsync();

            foreach (var phone in smartphones)
            {
                var phoneReviews = reviews.Where(r => r.ProductId == phone.Id).ToList();
                foreach (var review in phoneReviews)
                {
                    phone.Reviews.Add(review);
                }
            }

            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetEntitiesAsync();

            // Assert
            Assert.NotNull(result);
            var enumerable = result as Smartphone[] ?? result.ToArray();
            Assert.Equal(3, enumerable.Length);
        }
    }

    public class GetByIdAsyncTests
    {
        [Fact]
        public async Task GetByIdAsync_ShouldReturnSmartphone()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new SmartphoneRepository(context);

            var smartphone = new Smartphone(1, "Phone", "Description", [], 10, 1);

            context.Smartphones.Add(smartphone);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Phone", result.Name);
        }
    }

    public class CreateAsyncTests
    {
        [Fact]
        public async Task CreateAsync_ShouldAddSmartphone()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new SmartphoneRepository(context);

            var smartphone = new Smartphone(3, "Phone", "Description", [], 10, 1);

            // Act
            var result = await repository.CreateAsync(smartphone);

            // Assert
            Assert.Equal(3, result.Id);
            Assert.Equal("Phone", result.Name);

            var phoneInDb = await context.Smartphones.FindAsync(3);
            Assert.NotNull(phoneInDb);
            Assert.Equal("Phone", phoneInDb.Name);
        }
    }

    public class UpdateAsyncTests
    {
        [Fact]
        public async Task UpdateAsync_ShouldUpdateSmartphone()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new SmartphoneRepository(context);

            var smartphone = new Smartphone(1, "Phone", "Description", [], 10, 1);

            context.Smartphones.Add(smartphone);
            await context.SaveChangesAsync();

            smartphone.SetName("UpdatedPhone");

            // Act
            var result = await repository.UpdateAsync(smartphone);

            // Assert
            Assert.Equal("UpdatedPhone", result.Name);

            var updatedPhoneInDb = await context.Smartphones.FindAsync(1);
            Assert.NotNull(updatedPhoneInDb);
            Assert.Equal("UpdatedPhone", updatedPhoneInDb.Name);
        }
    }

    public class DeleteAsyncTests
    {
        [Fact]
        public async Task DeleteAsync_ShouldRemoveSmartphone()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new SmartphoneRepository(context);

            var smartphone = new Smartphone(1, "Phone", "Description", [], 10, 1);

            context.Smartphones.Add(smartphone);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.DeleteAsync(smartphone);

            // Assert
            Assert.Equal(1, result.Id);

            var phoneInDb = await context.Smartphones.FindAsync(1);
            Assert.Null(phoneInDb);
        }
    }
}