using Application.CQRS.Command.Products.Technology.Games;
using Application.CQRS.Queries.Products.Technology.Games;
using Application.Dtos.Products.Technology.Games;
using Application.Interfaces.Products.Technology;
using AutoMapper;
using MediatR;

namespace Application.Services.Entities.Products.Technology;

public class GameDtoService(IMapper mapper, IMediator mediator) : IGameDtoService
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;


    public async Task<IEnumerable<GameDto>> GetEntitiesDtoAsync()
    {
        var getProducts = new GamesQueries();
        var result = await _mediator.Send(getProducts);

        return _mapper.Map<IEnumerable<GameDto>>(result) ?? Enumerable.Empty<GameDto>();
    }

    public async Task<GameDto> GetByIdAsync(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));
        
        var getProductId = new GetByIdGameQuery(id.Value);
        var result = await _mediator.Send(getProductId);

        return _mapper.Map<GameDto>(result);
    }

    public async Task AddAsync(GameDto entityDto)
    {
        var addProduct = _mapper.Map<CreateGameCommand>(entityDto);
        await _mediator.Send(addProduct);
    }

    public async Task UpdateAsync(GameDto entityDto)
    {
        var updateProduct = _mapper.Map<UpdateGameCommand>(entityDto);
        await _mediator.Send(updateProduct);
    }

    public async Task DeleteAsync(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));
        
        var deleteProduct = new RemoveGameCommand(id.Value);
        await _mediator.Send(deleteProduct);
    }
}