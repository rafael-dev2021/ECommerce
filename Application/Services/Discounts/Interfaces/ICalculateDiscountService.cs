using Application.Dtos.ObjectsValues.ProductObjectValue;

namespace Application.Services.Discounts.Interfaces;

public interface ICalculateDiscountService
{
    decimal DiscountPercentage(PriceDtoObjectValue price);
    decimal InTwelveInstallmentWithoutInterest(PriceDtoObjectValue price);
    decimal InSixInstallmentWithoutInterest(PriceDtoObjectValue price);
    decimal InThreeInstallmentWithInterest(PriceDtoObjectValue price);
}
