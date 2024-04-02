using System.Net;
using Application.CQRS.Command.Products.Fashion.Shoes;
using Domain.Entities.Products.Fashion.Shoes;
using Domain.Interfaces.Products.Fashion;
using MediatR;

namespace Application.CQRS.Handlers.Products.Fashion.Shoes;

public class UpdateShoesHandler(IShoesRepository shoesRepository) : IRequestHandler<UpdateShoesCommand, Shoe>
{
    private readonly IShoesRepository _shoesRepository = shoesRepository;

    public async Task<Shoe> Handle(UpdateShoesCommand request, CancellationToken cancellationToken)
    {
        var product = await _shoesRepository.GetByIdAsync(request.Id);

        product.UpdateShoe(
            request.Name,
            request.Description,
            request.ImagesUrl,
            request.Stock,
            request.DataObjectValue,
            request.FlagsObjectValue,
            request.PriceObjectValue,
            request.SpecificationObjectValue,
            request.WarrantyObjectValue,
            request.MaterialObjectValue,
            request.CommonPropertiesObjectValue,
            request.CategoryId);

        return await _shoesRepository.UpdateAsync(product);
    }
}