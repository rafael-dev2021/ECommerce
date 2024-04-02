using Application.CQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.Handlers;

public class ProductDtoHandler(IProductRepository productRepository) :
    IRequestHandler<SearchProductQueries, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IEnumerable<Product>> Handle(
        SearchProductQueries request,
        CancellationToken cancellationToken) =>
        await _productRepository.GetSearchProductAsync(request.Keyword);
}