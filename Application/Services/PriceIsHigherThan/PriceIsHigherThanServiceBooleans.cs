using Application.Dtos;

namespace Application.Services.PriceIsHigherThan;

public class PriceIsHigherThanServiceBooleans
{
    public ProductDto? ProductDto { get; set; }
    public bool IsPriceHigherThanTwoThousand
    {
        get { return ProductDto?.PriceObjectValue?.Price >= 2000; }
    }
    public bool IsPriceIsBetweenTwoHundredAndAThousand
    {
        get
        {
            var price = ProductDto?.PriceObjectValue?.Price;
            return price.HasValue && price >= 200 && price <= 1000;
        }
    }
    public bool IsPriceIsLowerThanOneHundred
    {
        get { return ProductDto?.PriceObjectValue?.Price <= 100; }
    }
}
