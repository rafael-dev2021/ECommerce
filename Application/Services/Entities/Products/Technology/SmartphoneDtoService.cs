using Application.CQRS.Command.Products.Technology.Smartphones;
using Application.CQRS.Queries.Products.Technology.Smartphones;
using Application.Dtos.Products.Technology.Smartphones;
using Application.Interfaces.Products.Technology;
using AutoMapper;
using MediatR;

namespace Application.Services.Entities.Products.Technology;

public class SmartphoneDtoService(IMediator mediator, IMapper mapper) : ISmartphoneDtoService
{
    
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;
    
    
    public async Task<IEnumerable<SmartphoneDto>> GetEntitiesDtoAsync()
    {
        var getProducts = new SmartphonesQueries();
        var result = await _mediator.Send(getProducts);

        return _mapper.Map<IEnumerable<SmartphoneDto>>(result);
    }

    public async Task<SmartphoneDto> GetByIdAsync(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        var getProductId = new GetByIdSmartphoneQuery(id.Value);
        var result = await _mediator.Send(getProductId);
        
        return _mapper.Map<SmartphoneDto>(result);
    }

    public async Task AddAsync(SmartphoneDto entityDto)
    {
        var addProduct = _mapper.Map<CreateSmartphoneCommand>(entityDto);
        await _mediator.Send(addProduct);
    }

    public async Task UpdateAsync(SmartphoneDto entityDto)
    {
        var updateProduct = _mapper.Map<UpdateSmartphoneCommand>(entityDto);
        await _mediator.Send(updateProduct);
    }

    public async Task DeleteAsync(int? id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));
        
        var deleteProduct = new RemoveSmartphoneCommand(id.Value);
        await _mediator.Send(deleteProduct);
    }
}