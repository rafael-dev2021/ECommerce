using Application.CQRS.Queries.Products.Fashion.Shoes;
using Domain.Entities.Products.Fashion.Shoes;
using Domain.Interfaces.Products.Fashion;
using MediatR;

namespace Application.CQRS.Handlers.Products.Fashion.Shoes;

public class GetByIdShoesQueryHandler(IShoesRepository shoesRepository) : IRequestHandler<GetByIdShoesQuery, Shoe>
{
    private readonly IShoesRepository _shoesRepository = shoesRepository;
    public async Task<Shoe> Handle(GetByIdShoesQuery request, CancellationToken cancellationToken)
    {
        return await _shoesRepository.GetByIdAsync(request.Id);
    }
}
