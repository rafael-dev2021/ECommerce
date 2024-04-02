using Application.CQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.Handlers;

public class ProductsBestSellerHandler(IProductRepository productRepository) :
    IRequestHandler<ProductsBestSellerQueries, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IEnumerable<Product>> Handle(
        ProductsBestSellerQueries request,
        CancellationToken cancellationToken) =>
        await _productRepository.GetProductsBestSellersAsync();
}