using Application.CQRS.Queries.Products.Fashion.T_Shirts;
using Domain.Entities.Products.Fashion.T_Shirts;
using Domain.Interfaces.Products.Fashion;
using MediatR;

namespace Application.CQRS.Handlers.Products.Fashion.T_Shirts;

public class ShirtsQueriesHandler(IShirtRepository shirtRepository) : IRequestHandler<ShirtsQueries, IEnumerable<Shirt>>
{
    private readonly IShirtRepository _shirtRepository = shirtRepository;

    public async Task<IEnumerable<Shirt>> Handle(ShirtsQueries request, CancellationToken cancellationToken)
    {
        return await _shirtRepository.GetEntitiesAsync();
    }
}