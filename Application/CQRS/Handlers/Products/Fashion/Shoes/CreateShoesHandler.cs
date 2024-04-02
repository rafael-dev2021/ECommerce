using Application.CQRS.Command.Products.Fashion.Shoes;
using Domain.Entities.Products.Fashion.Shoes;
using Domain.Interfaces.Products.Fashion;
using MediatR;

namespace Application.CQRS.Handlers.Products.Fashion.Shoes;

public class CreateShoesHandle(IShoesRepository shoesRepository) : IRequestHandler<CreateShoesCommand, Shoe>
{
    private readonly IShoesRepository _shoesRepository = shoesRepository;
    public async Task<Shoe> Handle(CreateShoesCommand request, CancellationToken cancellationToken)
    {
        var product = new Shoe(
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

        product.SetCategoryId(request.CategoryId);
        return await _shoesRepository.CreateAsync(product);
    }
}
