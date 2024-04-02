using Application.CQRS.Queries.Products.Technology.Games;
using Domain.Entities.Products.Technology.Games;
using Domain.Interfaces.Products.Technology;
using MediatR;

namespace Application.CQRS.Handlers.Products.Technology.Games;

public class GetByIdGamaQueryHandler(IGameRepository gameRepository) : IRequestHandler<GetByIdGameQuery, Game>
{
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<Game> Handle(GetByIdGameQuery request, CancellationToken cancellationToken)
    {
        return await _gameRepository.GetByIdAsync(request.Id);
    }
}