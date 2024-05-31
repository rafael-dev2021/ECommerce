using Domain.Entities;
using Domain.Entities.Products.Technology.Games;
using Domain.Entities.Reviews;
using Infra_Data.Context;
using Infra_Data.Repositories.Products.Technology;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Repositories.Products.Technology;

public abstract class GameRepositoryTests
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
        public async Task GetEntitiesAsync_ShouldReturnListOfGamesWithCategoryAndReviews()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new GameRepository(context);

            var categories = new List<Category>
            {
                new(1, "Category1", "imageUrl1", true),
                new(2, "Category2", "imageUrl2", true)
            };
            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();

            var reviews = new List<Review>
            {
                new(1, "Good game", "image1", 5, DateTime.Now, 1),
                new(2, "Nice game", "image2", 4, DateTime.Now, 2)
            };
            context.Reviews.AddRange(reviews);
            await context.SaveChangesAsync();

            var games = new List<Game>
            {
                new(1, "Game1", "Description1", [], 10, 1),
                new(2, "Game2", "Description2", [], 20, 1),
                new(3, "Game3", "Description3", [], 30, 2)
            };
            context.Games.AddRange(games);
            await context.SaveChangesAsync();

            foreach (var game in games)
            {
                var gameReviews = reviews.Where(r => r.ProductId == game.Id).ToList();
                foreach (var review in gameReviews)
                {
                    game.Reviews.Add(review);
                }
            }

            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetEntitiesAsync();

            // Assert
            Assert.NotNull(result);
            var enumerable = result as Game[] ?? result.ToArray();
            Assert.Equal(3, enumerable.Length);
        }
    }

    public class GetByIdAsyncTests
    {
        [Fact]
        public async Task GetByIdAsync_ShouldReturnGame()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new GameRepository(context);

            var game = new Game(1, "Game", "Description", [], 10, 1);

            context.Games.Add(game);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Game", result.Name);
        }
    }

    public class CreateAsyncTests
    {
        [Fact]
        public async Task CreateAsync_ShouldAddGame()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new GameRepository(context);

            var game = new Game(3, "Game", "Description", [], 10, 1);

            // Act
            var result = await repository.CreateAsync(game);

            // Assert
            Assert.Equal(3, result.Id);
            Assert.Equal("Game", result.Name);

            var gameInDb = await context.Games.FindAsync(3);
            Assert.NotNull(gameInDb);
            Assert.Equal("Game", gameInDb.Name);
        }
    }

    public class UpdateAsyncTests
    {
        [Fact]
        public async Task UpdateAsync_ShouldUpdateGame()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new GameRepository(context);

            var game = new Game(1, "Game", "Description", [], 10, 1);

            context.Games.Add(game);
            await context.SaveChangesAsync();

            game.SetName("UpdatedGame");

            // Act
            var result = await repository.UpdateAsync(game);

            // Assert
            Assert.Equal("UpdatedGame", result.Name);

            var updatedGameInDb = await context.Games.FindAsync(1);
            Assert.NotNull(updatedGameInDb);
            Assert.Equal("UpdatedGame", updatedGameInDb.Name);
        }
    }

    public class DeleteAsyncTests
    {
        [Fact]
        public async Task DeleteAsync_ShouldRemoveGame()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new GameRepository(context);

            var game = new Game(1, "Game", "Description", [], 10, 1);

            context.Games.Add(game);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.DeleteAsync(game);

            // Assert
            Assert.Equal(1, result.Id);

            var gameInDb = await context.Games.FindAsync(1);
            Assert.Null(gameInDb);
        }
    }
}