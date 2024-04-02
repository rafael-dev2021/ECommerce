using Application.CQRS.Queries.Products.Technology.Games;
using Domain.Entities.Products.Technology.Games;
using Domain.Interfaces.Products.Technology;
using MediatR;

namespace Application.CQRS.Handlers.Products.Technology.Games;

public class GetGameQueriesHandler(IGameRepository gameRepository) : IRequestHandler<GamesQueries, IEnumerable<Game>>
{
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<IEnumerable<Game>> Handle(GamesQueries request, CancellationToken cancellationToken)
    {
        return await _gameRepository.GetEntitiesAsync();
    }
}
