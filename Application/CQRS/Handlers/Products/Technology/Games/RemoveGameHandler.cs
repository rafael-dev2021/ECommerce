using Application.CQRS.Command.Products.Technology.Games;
using Domain.Entities.Products.Technology.Games;
using Domain.Interfaces.Products.Technology;
using MediatR;

namespace Application.CQRS.Handlers.Products.Technology.Games;

public class RemoveGameHandler(IGameRepository gameRepository) : IRequestHandler<RemoveGameCommand, Game>
{
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<Game> Handle(RemoveGameCommand request, CancellationToken cancellationToken)
    {
        var product = await _gameRepository.GetByIdAsync(request.Id);

        var result = await _gameRepository.DeleteAsync(product);
        return result;
    }
}