using Application.Dtos.Reviews;
using Application.Services.CalculateWeightedAverageReviews;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.CalculateWeightedAverageReviews;

public class WeightedAverageCalculatorTests
{
    private readonly WeightedAverageCalculator _weightedAverageCalculator = new();

    [Fact]
    public void CalculateWeightedAverage_ShouldReturnZero_WhenNoReviews()
    {
        // Arrange
        var reviews = new List<ReviewDto>();

        // Act
        var result = _weightedAverageCalculator.CalculateWeightedAverage(reviews);

        // Assert
        Assert.Equal(0, result.CountReviews);
        Assert.Equal(0.0, result.WeightedAverage);
    }

    [Fact]
    public void CalculateWeightedAverage_ShouldCalculateWeightedAverage_WhenSingleReview()
    {
        // Arrange
        var reviews = new List<ReviewDto>
            {
                new (1, "Great product", "", 5, DateTime.Now, 1, null)
            };

        // Act
        var result = _weightedAverageCalculator.CalculateWeightedAverage(reviews);

        // Assert
        Assert.Equal(1, result.CountReviews);
        Assert.Equal(5.0, result.WeightedAverage);
    }
}
