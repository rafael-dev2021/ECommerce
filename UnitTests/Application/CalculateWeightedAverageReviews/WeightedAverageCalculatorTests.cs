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
    public void CalculateWeightedAverage_ShouldApplyWeight_WhenWeightIsLessThanOne()
    {
        // Arrange
        var reviews = new List<ReviewDto>
        {
            new(1, "Decent product", "", 2, DateTime.Now, 1, null),
            new(2, "Good product", "", 2, DateTime.Now, 1, null),
            new(3, "Okay product", "", 2, DateTime.Now, 1, null)
        };

        // Act
        var result = _weightedAverageCalculator.CalculateWeightedAverage(reviews);

        // Assert
        Assert.Equal(3, result.CountReviews);
        Assert.Equal(2.0, result.WeightedAverage);
    }

    [Fact]
    public void CalculateWeightedAverage_ShouldNotApplyWeight_WhenWeightIsGreaterThanOrEqualToOne()
    {
        // Arrange
        var reviews = new List<ReviewDto>
        {
            new(1, "Great product", "", 4, DateTime.Now, 1, null),
            new(2, "Good product", "", 4, DateTime.Now, 1, null),
            new(3, "Excellent product", "", 4, DateTime.Now, 1, null)
        };

        // Act
        var result = _weightedAverageCalculator.CalculateWeightedAverage(reviews);

        // Assert
        Assert.Equal(3, result.CountReviews);
        Assert.Equal(4.0, result.WeightedAverage);
    }

    [Fact]
    public void CalculateWeightedAverage_ShouldHandleAverageRatingExactlyOne()
    {
        // Arrange
        var reviews = new List<ReviewDto>
        {
            new(1, "Bad product", "", 1, DateTime.Now, 1, null)
        };

        // Act
        var result = _weightedAverageCalculator.CalculateWeightedAverage(reviews);

        // Assert
        Assert.Equal(1, result.CountReviews);
        Assert.Equal(1.0, result.WeightedAverage);
    }

    [Fact]
    public void CalculateWeightedAverage_ShouldHandleAverageRatingExactlyMaxRating()
    {
        // Arrange
        var reviews = new List<ReviewDto>
        {
            new(1, "Perfect product", "", 5, DateTime.Now, 1, null)
        };

        // Act
        var result = _weightedAverageCalculator.CalculateWeightedAverage(reviews);

        // Assert
        Assert.Equal(1, result.CountReviews);
        Assert.Equal(5.0, result.WeightedAverage);
    }

    [Fact]
    public void CalculateWeightedAverage_ShouldApplyWeightCorrectly_WhenWeightIsFractional()
    {
        // Arrange
        var reviews = new List<ReviewDto>
        {
            new(1, "Good product", "", 2, DateTime.Now, 1, null),
            new(2, "Good product", "", 3, DateTime.Now, 1, null)
        };

        // Act
        var result = _weightedAverageCalculator.CalculateWeightedAverage(reviews);

        // Assert
        Assert.Equal(2, result.CountReviews);
        Assert.Equal(2.5, result.WeightedAverage);
    }
}
