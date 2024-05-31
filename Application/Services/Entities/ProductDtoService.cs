using Application.CQRS.Queries;
using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Services.Entities;

public class ProductDtoService(IMapper mapper, IMediator mediator) : IProductDtoService
{
    public async Task<IEnumerable<ProductDto>> GetProductsDtoAsync()
    {
        var getProducts = new ProductsQueries();
        var result = await mediator.Send(getProducts);
        return mapper.Map<IEnumerable<ProductDto>>(result);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsDtoFavoritesAsync()
    {
        var getFavoriteProducts = new ProductsFavoritesQueries();
        var result = await mediator.Send(getFavoriteProducts);
        return mapper.Map<IEnumerable<ProductDto>>(result);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsDtoDailyOffersAsync()
    {
        var getDailyOfferProducts = new ProductsDailyOfferQueries();
        var result = await mediator.Send(getDailyOfferProducts);
        return mapper.Map<IEnumerable<ProductDto>>(result);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsDtoBestSellersAsync()
    {
        var getBestSellerProducts = new ProductsBestSellerQueries();
        var result = await mediator.Send(getBestSellerProducts);
        return mapper.Map<IEnumerable<ProductDto>>(result);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsDtoByCategoriesAsync(string categoryStr)
    {
        var getProductByIdCategory = await
            mediator.Send(new ProductByCategoryQueries(categoryStr));

        return mapper.Map<IEnumerable<ProductDto>>(getProductByIdCategory);
    }

    public async Task<IEnumerable<ProductDto>> GetSearchProductsDtoAsync(string keyword)
    {
        var getSearchProduct =
            await mediator.Send(new SearchProductQueries(keyword));

        return mapper.Map<IEnumerable<ProductDto>>(getSearchProduct);
    }

    public async Task<ProductDto> GetByIdAsync(int? id)
    {
        if (id is null or <= 0)
            throw new ArgumentException("Invalid product id");
        
        var getProductId = new GetByIdProductQuery(id.Value);
        var result = await mediator.Send(getProductId);
        return mapper.Map<ProductDto>(result);
    }
}