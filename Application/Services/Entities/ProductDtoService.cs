using Application.CQRS.Queries;
using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Services.Entities;

public class ProductDtoService(IMapper mapper, IMediator mediator) : IProductDtoService
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;

    public async Task<IEnumerable<ProductDto>> GetProductsDtoAsync()
    {
        var getProducts = new ProductsQueries();
        var result = await _mediator.Send(getProducts);
        return _mapper.Map<IEnumerable<ProductDto>>(result);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsDtoFavoritesAsync()
    {
        var getFavoriteProducts = new ProductsFavoritesQueries();
        var result = await _mediator.Send(getFavoriteProducts);
        return _mapper.Map<IEnumerable<ProductDto>>(result);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsDtoDailyOffersAsync()
    {
        var getDailyOfferProducts = new ProductsDailyOfferQueries();
        var result = await _mediator.Send(getDailyOfferProducts);
        return _mapper.Map<IEnumerable<ProductDto>>(result);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsDtoBestSellersAsync()
    {
        var getBestSellerProducts = new ProductsBestSellerQueries();
        var result = await _mediator.Send(getBestSellerProducts);
        return _mapper.Map<IEnumerable<ProductDto>>(result);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsDtoByCategoriesAsync(string categoryStr)
    {
        var getProductByIdCategory = await
            _mediator.Send(new ProductByCategoryQueries(categoryStr));

        return _mapper.Map<IEnumerable<ProductDto>>(getProductByIdCategory);
    }

    public async Task<IEnumerable<ProductDto>> GetSearchProductsDtoAsync(string keyword)
    {
        var getSearchProduct =
            await _mediator.Send(new SearchProductQueries(keyword));

        return _mapper.Map<IEnumerable<ProductDto>>(getSearchProduct);
    }

    public async Task<ProductDto> GetByIdAsync(int? id)
    {
        if (id is null or <= 0)
            throw new ArgumentException("Invalid product id");
        
        var getProductId = new GetByIdProductQuery(id.Value);
        var result = await _mediator.Send(getProductId);
        return _mapper.Map<ProductDto>(result);
    }
}