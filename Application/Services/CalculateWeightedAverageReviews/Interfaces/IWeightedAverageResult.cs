using Application.Dtos.Reviews;
using Application.Services.CalculateWeightedAverageReviews.ObjectValues;

namespace Application.Services.CalculateWeightedAverageReviews.Interfaces;

public interface IWeightedAverageResult
{
    public WeightedAverageResultOV CalculateWeightedAverage(IEnumerable<ReviewDto> reviews);
}
