using Application.CQRS.Command.Products.Fashion.Shoes;
using Application.CQRS.Queries.Products.Fashion.Shoes;
using Application.Dtos.Products.Fashion.Shoes;
using Application.Interfaces.Products.Fashion;
using AutoMapper;
using MediatR;

namespace Application.Services.Entities.Products.Fashion;

public class ShoesDtoService(IMediator mediator, IMapper mapper) : IShoeDtoService
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;


    public async Task<IEnumerable<ShoeDto>> GetEntitiesDtoAsync()
    {
        var getProducts = new ShoesQueries();
        var result = await _mediator.Send(getProducts);

        return _mapper.Map<IEnumerable<ShoeDto>>(result);
    }

    public async Task<ShoeDto> GetByIdAsync(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));
        
        var getShoesId = new GetByIdShoesQuery(id.Value);
        var result = await _mediator.Send(getShoesId);

        return _mapper.Map<ShoeDto>(result);
    }

    public async Task AddAsync(ShoeDto entityDto)
    {
        var addShoes = _mapper.Map<CreateShoesCommand>(entityDto);
        await _mediator.Send(addShoes);
    }

    public async Task UpdateAsync(ShoeDto entityDto)
    {
        var updateShoes = _mapper.Map<UpdateShoesCommand>(entityDto);
        await _mediator.Send(updateShoes);
    }

    public async Task DeleteAsync(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));
        
        var deleteShoes = new RemoveShoesCommand(id.Value);
        await _mediator.Send(deleteShoes);
    }
}