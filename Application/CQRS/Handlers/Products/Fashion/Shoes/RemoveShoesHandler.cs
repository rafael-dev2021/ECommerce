using System.Net;
using Application.CQRS.Command.Products.Fashion.Shoes;
using Domain.Entities.Products.Fashion.Shoes;
using Domain.Interfaces.Products.Fashion;
using MediatR;

namespace Application.CQRS.Handlers.Products.Fashion.Shoes;

public class RemoveShoesHandler(IShoesRepository shoesRepository) : IRequestHandler<RemoveShoesCommand, Shoe>
{
    private readonly IShoesRepository _shoesRepository = shoesRepository;

    public async Task<Shoe> Handle(RemoveShoesCommand request, CancellationToken cancellationToken)
    {
        var product = await _shoesRepository.GetByIdAsync(request.Id);

        var result = await _shoesRepository.DeleteAsync(product);
        return result;
    }
}