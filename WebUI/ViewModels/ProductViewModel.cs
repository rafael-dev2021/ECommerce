using Application.Dtos;
using Application.Dtos.Products.Fashion.Shoes;
using Application.Dtos.Products.Fashion.T_Shirts;
using Application.Dtos.Products.Technology.Games;
using Application.Dtos.Products.Technology.Smartphones;
using Application.Dtos.Reviews;
using Application.Services.CountProductByPrice;
using Application.Services.Discounts;
using Application.Services.GetMatchingProducts.Fashion;
using Application.Services.GetMatchingProducts.Technology;
using Application.Services.PriceIsHigherThan;

namespace WebUI.ViewModels;

public class ProductViewModel
{
    public IEnumerable<ProductDto> ProductsDto { get; set; } = [];
    public IEnumerable<SmartphoneDto> SmartphonesDto { get; set; } = [];
    public IEnumerable<ReviewDto> ReviewsDto { get; set; } = [];
    public IEnumerable<GameDto> GamesDto { get; set; } = [];
    public IEnumerable<ShoeDto> ShoesDto { get; set; } = [];
    public IEnumerable<ShirtDto> ShirtsDto { get; set; } = [];
    public ProductDto ProductDto { get; set; } = new();
    public SmartphoneDto SmartphoneDto { get; set; } = new();
    public GetMatchingProductsDtoTechnology? GetMatchingProductsDto { get; set; }
    public GetMatchingProductsDtoFashion? GetMatchingProductsDtoFashion { get; set; }
    public CountProductByPriceValuable? CountProductByPriceValuable { get; set; }
    public PriceIsHigherThanServiceBooleans? PriceIsHigherThanServiceBooleans { get; set; }
    public CalculateDiscountValuable? CalculateDiscountValuable { get; set; }

    public string CurrentCategory { get; set; } = string.Empty;
    public string CurrentBrand { get; set; } = string.Empty;
}