using Application.CQRS.Command.Products.Technology.Games;
using Domain.Entities.Products.Technology.Games;
using Domain.Interfaces.Products.Technology;
using MediatR;

namespace Application.CQRS.Handlers.Products.Technology.Games;

public class UpdateGameHandler(IGameRepository gameRepository) : IRequestHandler<UpdateGameCommand, Game>
{
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<Game> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        var product = await _gameRepository.GetByIdAsync(request.Id);

        product.UpdateGame(
            request.Name,
            request.Description,
            request.ImagesUrl,
            request.Stock,
            request.DataObjectValue,
            request.FlagsObjectValue,
            request.PriceObjectValue,
            request.SpecificationObjectValue,
            request.WarrantyObjectValue,
            request.GeneralFeaturesObjectValue,
            request.MediaSpecificationObjectValue,
            request.RequirementObjectValue,
            request.CommonPropertiesObjectValue,
            request.CategoryId
        );

        return await _gameRepository.UpdateAsync(product);
    }
}