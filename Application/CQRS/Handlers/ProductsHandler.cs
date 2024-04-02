using Application.CQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.Handlers;

public class ProductsHandler(IProductRepository productRepository) :
    IRequestHandler<ProductsQueries, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IEnumerable<Product>> Handle(
        ProductsQueries request,
        CancellationToken cancellationToken) =>
        await _productRepository.GetProductsAsync();
}