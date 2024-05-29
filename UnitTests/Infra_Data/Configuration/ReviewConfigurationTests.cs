using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Infra_Data.Configuration;

public class ReviewConfigurationTests
{
    [Fact]
    public void Should_Configure_Review()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        using var context = new TestDbContext(options);

        // Ensure database is created and seeded
        context.Database.EnsureCreated();

        // Act
        var reviews = context.Reviews.ToList();

        // Assert
        Assert.Equal(15, reviews.Count); 
        Assert.Contains(reviews, r => r.Id == 1 && r.Comment == "The quality of the photos is incredible.");
        Assert.Contains(reviews, r => r.Id == 12 && r.Comment == "It was small on me. I want to return it. To get my refund.");
    }
}
