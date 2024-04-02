using Application.CQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.Handlers;

public class ProductByCategoryHandler(IProductRepository productRepository) :
    IRequestHandler<ProductByCategoryQueries, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IEnumerable<Product>> Handle(
        ProductByCategoryQueries request,
        CancellationToken cancellationToken) =>
        await _productRepository.GetProductsByCategoriesAsync(request.CategoryStr);
}