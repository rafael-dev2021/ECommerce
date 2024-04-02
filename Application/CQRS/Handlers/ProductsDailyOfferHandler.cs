using Application.CQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.Handlers;

public class ProductsDailyOfferHandler(IProductRepository productRepository) :
    IRequestHandler<ProductsDailyOfferQueries, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IEnumerable<Product>> Handle(
        ProductsDailyOfferQueries request,
        CancellationToken cancellationToken) =>
        await _productRepository.GetProductsDailyOffersAsync();
}