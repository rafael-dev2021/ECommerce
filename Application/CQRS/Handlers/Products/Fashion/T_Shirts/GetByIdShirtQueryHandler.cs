using Application.CQRS.Queries.Products.Fashion.T_Shirts;
using Domain.Entities.Products.Fashion.T_Shirts;
using Domain.Interfaces.Products.Fashion;
using MediatR;

namespace Application.CQRS.Handlers.Products.Fashion.T_Shirts;

public class GetByIdShirtQueryHandler(IShirtRepository shirtRepository) : IRequestHandler<GetByIdShirtQuery, Shirt>
{
    private readonly IShirtRepository _shirtRepository = shirtRepository;

    public async Task<Shirt> Handle(GetByIdShirtQuery request, CancellationToken cancellationToken)
    {
        return await _shirtRepository.GetByIdAsync(request.Id);
    }
}