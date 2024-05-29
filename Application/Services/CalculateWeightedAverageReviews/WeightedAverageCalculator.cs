using Application.Dtos.Reviews;
using Application.Services.CalculateWeightedAverageReviews.Interfaces;
using Application.Services.CalculateWeightedAverageReviews.ObjectValues;

namespace Application.Services.CalculateWeightedAverageReviews
{
    public class WeightedAverageCalculator : IWeightedAverageResult
    {
        private const double MaxRating = 5.0;

        public WeightedAverageResultOV CalculateWeightedAverage(IEnumerable<ReviewDto> reviews)
        {
            var reviewList = reviews.ToList();
            var countReviews = reviewList.Count;

            var totalRating = reviewList.Sum(review => review.Rating);

            var result = new WeightedAverageResultOV
            {
                CountReviews = countReviews
            };

            if (countReviews > 0)
            {
                var averageRating = (double)totalRating / countReviews;

                var weight = MaxRating / averageRating;

                result.WeightedAverage = averageRating * (weight < 1 ? weight : 1);
            }
            else
            {
                result.WeightedAverage = 0.0;
            }

            return result;
        }
    }
}
