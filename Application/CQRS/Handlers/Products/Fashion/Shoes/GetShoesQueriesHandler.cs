using Application.CQRS.Queries.Products.Fashion.Shoes;
using Domain.Entities.Products.Fashion.Shoes;
using Domain.Interfaces.Products.Fashion;
using MediatR;

namespace Application.CQRS.Handlers.Products.Fashion.Shoes;

public class GetShoesQueriesHandler(IShoesRepository shoesRepository) : IRequestHandler<ShoesQueries, IEnumerable<Shoe>>
{
    private readonly IShoesRepository _shoesRepository = shoesRepository;
    public async Task<IEnumerable<Shoe>> Handle(ShoesQueries request, CancellationToken cancellationToken)
    {
        return await _shoesRepository.GetEntitiesAsync();
    }
}
