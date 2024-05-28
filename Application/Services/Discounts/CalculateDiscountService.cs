using Application.Dtos.ObjectsValues.ProductObjectValue;
using Application.Services.Discounts.Interfaces;

namespace Application.Services.Discounts;

public class CalculateDiscountService : ICalculateDiscountService
{

    public decimal DiscountPercentage(PriceDtoObjectValue price)
    {
        if (price.HistoryPrice > 0)
        {
            var calculate = (price.HistoryPrice - price.Price) / price.HistoryPrice * 100;
            return calculate;
        }
        return 0;
    }

    public decimal InSixInstallmentWithoutInterest(PriceDtoObjectValue price)
    {
        var calculate = price.Price / 6;
        return calculate;
    }

    public decimal InThreeInstallmentWithInterest(PriceDtoObjectValue price)
    {
        var calculate = price.Price / 3;
        var addingInterest = calculate * 1.03m;
        return addingInterest;
    }

    public decimal InTwelveInstallmentWithoutInterest(PriceDtoObjectValue price)
    {
        var calculate = price.Price / 12;
        return calculate;
    }
}
