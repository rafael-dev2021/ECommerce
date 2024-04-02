using Application.CQRS.Command.Products.Fashion.T_Shirts;
using Application.CQRS.Queries.Products.Fashion.T_Shirts;
using Application.Dtos.Products.Fashion.T_Shirts;
using Application.Interfaces.Products.Fashion;
using AutoMapper;
using MediatR;

namespace Application.Services.Entities.Products.Fashion;

public class ShirtDtoService(IMediator mediator, IMapper mapper) : IShirtDtoService
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;
    
    
    public async Task<IEnumerable<ShirtDto>> GetEntitiesDtoAsync()
    {
        var getProducts = new ShirtsQueries();
        var result = await _mediator.Send(getProducts);
        
        return _mapper.Map<IEnumerable<ShirtDto>>(result) ?? Enumerable.Empty<ShirtDto>();
    }

    public async Task<ShirtDto> GetByIdAsync(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));
        
        var getProductId = new GetByIdShirtQuery(id.Value);
        var result = await _mediator.Send(getProductId);
        
        return _mapper.Map<ShirtDto>(result); 
    }

    public async Task AddAsync(ShirtDto entityDto)
    {
        var addProduct = _mapper.Map<CreateShirtCommand>(entityDto);
        await _mediator.Send(addProduct);
    }

    public  async Task UpdateAsync(ShirtDto entityDto)
    {
        var updateProduct = _mapper.Map<UpdateShirtCommand>(entityDto);
        await _mediator.Send(updateProduct);
    }

    public async Task DeleteAsync(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));
        
        var deleteProduct = new RemoveShirtCommand(id.Value);
        await _mediator.Send(deleteProduct);
    }
}