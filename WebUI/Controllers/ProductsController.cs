using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Products.Fashion;
using Application.Interfaces.Products.Technology;
using Application.Services.CountProductByPrice;
using Application.Services.CountProductByPrice.Interfaces;
using Application.Services.Discounts;
using Application.Services.Discounts.Interfaces;
using Application.Services.GetMatchingProducts.Fashion;
using Application.Services.GetMatchingProducts.Technology;
using Application.Services.PriceIsHigherThan;
using Application.Services.PriceIsHigherThan.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers;

public class ProductsController(
    ICountProductsByPriceService countProductsByPriceService,
    IPriceIsHigherThanService priceIsHigherThanService,
    ICalculateDiscountService calculateDiscountService,
    IProductDtoService productDtoService,
    IReviewDtoService reviewDtoService,
    ISmartphoneDtoService smartphoneDtoService,
    IGameDtoService gameDtoService,
    IShoeDtoService shoesDtoService,
    IShirtDtoService shirtDtoService) : Controller
{
    public async Task<IActionResult> IndexCategory(string categoryStr)
    {
        IEnumerable<ProductDto> products;
        await productDtoService.GetProductsDtoAsync();

        if (string.IsNullOrEmpty(categoryStr))
        {
            products = await productDtoService.GetProductsDtoAsync();
        }
        else
        {
            var productsForCategory = await
                productDtoService.GetProductsDtoByCategoriesAsync(categoryStr);

            var forCategory = productsForCategory as ProductDto[] ?? productsForCategory.ToArray();
            if (forCategory.Length == 0)
            {
                return RedirectToAction("IndexCategory");
            }

            products = forCategory;
        }

        var productVw = new ProductViewModel()
        {
            ProductsDto = products,
            CurrentCategory = categoryStr
        };

        return View(productVw);
    }

    // WIP: In construction, nothing is finished yet
    public async Task<IActionResult> Index(FilterProductsViewModel model)
    {
        IEnumerable<ProductDto> products;
        await productDtoService.GetProductsDtoAsync();

        if (string.IsNullOrEmpty(model.CategoryStr))
        {
            products = await productDtoService.GetProductsDtoAsync();
        }
        else
        {
            var productsForCategory = await
                productDtoService.GetProductsDtoByCategoriesAsync(model.CategoryStr);

            var forCategory = productsForCategory as ProductDto[] ?? productsForCategory.ToArray();
            if (forCategory.Length == 0)
                return RedirectToAction("Index");

            products = forCategory;
        }

        if (!string.IsNullOrEmpty(model.Brand))
            products = products.Where(p => p.SpecificationObjectValue!.Brand.Contains(model.Brand));

        if (!string.IsNullOrEmpty(model.Keyword))
        {
            var filteredProductsByKeyword = await
                productDtoService.GetSearchProductsDtoAsync(model.Keyword);

            var productsByKeyword = filteredProductsByKeyword as
                ProductDto[] ?? filteredProductsByKeyword.ToArray();

            if (productsByKeyword.Length == 0)
                return RedirectToAction("Index");

            products = productsByKeyword;
        }

        if (!string.IsNullOrEmpty(model.MinPrice))
        {
            if (decimal.TryParse(model.MinPrice, out var parsedMinPrice))
            {
                products = products.Where(p => p.PriceObjectValue!.Price >= parsedMinPrice);
            }
        }

        if (!string.IsNullOrEmpty(model.MaxPrice))
        {
            if (decimal.TryParse(model.MaxPrice, out var parsedMaxPrice))
            {
                products = products.Where(p => p.PriceObjectValue!.Price <= parsedMaxPrice);
            }
        }

        if (model.IsDailyOffer.HasValue)
            products = products.Where(p => p.FlagsObjectValue!.IsDailyOffer == model.IsDailyOffer);

        if (model.IsBestSeller.HasValue)
            products = products.Where(p => p.FlagsObjectValue!.IsBestSeller == model.IsBestSeller);

        if (model.IsPriceHigh is true)
            products = products.OrderByDescending(p => p.PriceObjectValue!.Price);

        if (model.IsPriceLow is true)
            products = products.OrderBy(p => p.PriceObjectValue!.Price);

        if (model.ShowAvailableOnly is true)
            products = products.Where(p => p.Stock > 0);

        if (model.HasReviews is true)
            products = products.Where(p => p.Reviews.Count != 0);

        var productDtos = products as ProductDto[] ?? products.ToArray();
        var totalProducts = productDtos.Length;

        var totalPages = (int)Math.Ceiling(totalProducts / (double)model.PageSize);
        var paginatedProducts = productDtos
            .Skip((model.Page - 1) * model.PageSize)
            .Take(model.PageSize).ToList();

        ViewBag.TotalPages = totalPages;
        ViewBag.CurrentPage = model.Page;
        ViewBag.Keyword = model.Keyword;

        var productVw = new ProductViewModel()
        {
            ProductsDto = paginatedProducts,
            CurrentCategory = model.CategoryStr,
            CurrentBrand = model.Brand
        };

        return View(productVw);
    }

    public IActionResult ClearFilter()
    {
        return RedirectToAction("Index");
    }

    //In construction, nothing is finished yet
    [AllowAnonymous]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var getIdProductDtoAsync = await productDtoService.GetByIdAsync(id);

        var getProductsDto = await productDtoService.GetProductsDtoAsync();
        var getSmartphonesDto = await smartphoneDtoService.GetEntitiesDtoAsync();
        var getGamesDto = await gameDtoService.GetEntitiesDtoAsync();
        var getShoesDto = await shoesDtoService.GetEntitiesDtoAsync();
        var getTshirtsDto = await shirtDtoService.GetEntitiesDtoAsync();
        var getReviewsDto = await reviewDtoService.GetEntitiesAsync();
        var discountPercentage =
            calculateDiscountService.DiscountPercentage(getIdProductDtoAsync.PriceObjectValue!);
        var inTwelveInstallmentWithoutInterest =
            calculateDiscountService.InTwelveInstallmentWithoutInterest(getIdProductDtoAsync.PriceObjectValue!);
        var inThreeInstallmentWithInterest =
            calculateDiscountService.InThreeInstallmentWithInterest(getIdProductDtoAsync.PriceObjectValue!);
        var inSixInstallmentWithoutInterest =
            calculateDiscountService.InSixInstallmentWithoutInterest(getIdProductDtoAsync.PriceObjectValue!);
        var priceIsHigherThanTwoThousand = await countProductsByPriceService.CountingProductsAbovePriceAsync(2000);
        var priceIsBetweenTwoHundredAndAThousand =
            await countProductsByPriceService.CountingProductsAboveOrBelowPriceAsync(200, 1000);
        var priceIsLowerThanOneHundred = await countProductsByPriceService.CountingProductsBelowPriceAsync(100);


        var productVw = new ProductViewModel()
        {
            ProductDto = getIdProductDtoAsync,
            ProductsDto = getProductsDto,
            SmartphonesDto = getSmartphonesDto,
            GamesDto = getGamesDto,
            ShoesDto = getShoesDto,
            ShirtsDto = getTshirtsDto,
            ReviewsDto = getReviewsDto,
            CalculateDiscountValuable = new CalculateDiscountValuable
            {
                DiscountPercentage = discountPercentage,
                InTwelveInstallmentWithoutInterest = inTwelveInstallmentWithoutInterest,
                InSixInstallmentWithoutInterest = inSixInstallmentWithoutInterest,
                InThreeInstallmentWithInterest = inThreeInstallmentWithInterest,
            },
            CountProductByPriceValuable = new CountProductByPriceValuable
            {
                CountPriceIsHigherThanTwoThousand = priceIsHigherThanTwoThousand,
                CountPriceIsBetweenTwoHundredAndAThousand = priceIsBetweenTwoHundredAndAThousand,
                CountPriceIsLowerThanOneHundred = priceIsLowerThanOneHundred
            },
            GetMatchingProductsDto = new GetMatchingProductsDtoTechnology
            {
                ProductDto = getIdProductDtoAsync,
                SmartphonesDto = getSmartphonesDto,
                GamesDto = getGamesDto,
            },
            GetMatchingProductsDtoFashion = new GetMatchingProductsDtoFashion
            {
                ProductDto = getIdProductDtoAsync,
                TshirtsDto = getTshirtsDto,
                ShoesDto = getShoesDto
            },
            PriceIsHigherThanServiceBooleans = new PriceIsHigherThanServiceBooleans
            {
                ProductDto = getIdProductDtoAsync
            }
        };

        return View(productVw);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Search(string search)
    {
        IEnumerable<ProductDto> productDtos = new List<ProductDto>();

        var productsDto = productDtos as ProductDto[] ?? productDtos.ToArray();

        if (string.IsNullOrEmpty(search))
        {
            await productDtoService.GetProductsDtoAsync();
        }
        else
        {
            await productDtoService.GetSearchProductsDtoAsync(search);
            if (productsDto.Length == 0)
            {
                return RedirectToAction("ProductNotFound");
            }
        }

        var productVw = new ProductViewModel()
        {
            ProductsDto = productsDto
        };
        return View("Index", productVw);
    }


    [AllowAnonymous]
    public IActionResult ProductNotFound()
    {
        return View();
    }

    [AllowAnonymous]
    public async Task<IActionResult> PriceIsHigherThanTwoThousand()
    {
        var filteredProducts = await priceIsHigherThanService.GetProductsAbovePriceAsync(2000);
        var productVm = new ProductViewModel()
        {
            ProductsDto = filteredProducts.ToList()
        };
        return View(productVm);
    }

    [AllowAnonymous]
    public async Task<IActionResult> PriceIsBetweenTwoHundredAndAThousand()
    {
        var filteredProducts = await priceIsHigherThanService.GetProductsAboveOrBelowPriceAsync(200, 1000);
        var productVm = new ProductViewModel()
        {
            ProductsDto = filteredProducts.ToList()
        };
        return View(productVm);
    }

    [AllowAnonymous]
    public async Task<IActionResult> PriceIsLowerThanOneHundred()
    {
        var filteredProducts = await priceIsHigherThanService.GetProductsBelowPriceAsync(100);
        var productVm = new ProductViewModel()
        {
            ProductsDto = filteredProducts.ToList()
        };
        return View(productVm);
    }
}