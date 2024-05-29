using Application.Dtos.Reviews;
using Application.Services.CalculateWeightedAverageReviews;
using Xunit;
using Assert = Xunit.Assert;

namespace UnitTests.Application.CalculateWeightedAverageReviews;

public class WeightedAverageCalculatorTests
{
    private readonly WeightedAverageCalculator _weightedAverageCalculator;

    public WeightedAverageCalculatorTests()
    {
        _weightedAverageCalculator = new WeightedAverageCalculator();
    }

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

    [Fact]
    public void CalculateWeightedAverage_ShouldCalculateWeightedAverage_WhenMultipleReviews()
    {
        // Arrange
        var reviews = new List<ReviewDto>
            {
                new(1, "Great product", "", 5, DateTime.Now, 1, null),
                new(2, "Good product", "", 4, DateTime.Now, 1, null),
                new(3, "Okay product", "", 3, DateTime.Now, 1, null)
            };

        // Act
        var result = _weightedAverageCalculator.CalculateWeightedAverage(reviews);

        // Assert
        Assert.Equal(3, result.CountReviews);
        Assert.Equal(4.0, result.WeightedAverage);
    }

    [Fact]
    public void CalculateWeightedAverage_ShouldCalculateWeightedAverage_WhenMultipleReviewsWithHighAverageRating()
    {
        // Arrange
        var reviews = new List<ReviewDto>
    {
        new(1, "Great product", "", 5, DateTime.Now, 1, null),
        new(2, "Good product", "", 5, DateTime.Now, 1, null),
        new(3, "Okay product", "", 5, DateTime.Now, 1, null)
    };

        // Act
        var result = _weightedAverageCalculator.CalculateWeightedAverage(reviews);

        // Assert
        Assert.Equal(3, result.CountReviews);
        Assert.Equal(5.0, result.WeightedAverage);
    }
}
