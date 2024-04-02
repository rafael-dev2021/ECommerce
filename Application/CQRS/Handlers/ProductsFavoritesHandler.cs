using Application.CQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.Handlers;

public class ProductsFavoritesHandler(IProductRepository productRepository) :
    IRequestHandler<ProductsFavoritesQueries, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IEnumerable<Product>> Handle(
        ProductsFavoritesQueries request,
        CancellationToken cancellationToken) =>
        await _productRepository.GetProductsFavoritesAsync();
}