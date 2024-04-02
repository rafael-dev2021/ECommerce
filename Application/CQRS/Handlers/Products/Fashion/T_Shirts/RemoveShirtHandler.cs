using Application.CQRS.Command.Products.Fashion.T_Shirts;
using Domain.Entities.Products.Fashion.T_Shirts;
using Domain.Interfaces.Products.Fashion;
using MediatR;

namespace Application.CQRS.Handlers.Products.Fashion.T_Shirts;

public class RemoveShirtHandler(IShirtRepository shirtRepository) : IRequestHandler<RemoveShirtCommand, Shirt>
{
    private readonly IShirtRepository _shirtRepository = shirtRepository;

    public async Task<Shirt> Handle(RemoveShirtCommand request, CancellationToken cancellationToken)
    {
        var product = await _shirtRepository.GetByIdAsync(request.Id);
        
        var result = await _shirtRepository.DeleteAsync(product);
        return result;
    }
}