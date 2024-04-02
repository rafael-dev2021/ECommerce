using Application.CQRS.Command.Products.Fashion.T_Shirts;
using Domain.Entities.Products.Fashion.T_Shirts;
using Domain.Interfaces.Products.Fashion;
using MediatR;

namespace Application.CQRS.Handlers.Products.Fashion.T_Shirts;

public class UpdateShirtHandler(IShirtRepository shirtRepository) : IRequestHandler<UpdateShirtCommand, Shirt>
{
    private readonly IShirtRepository _shirtRepository = shirtRepository;
    public async Task<Shirt> Handle(UpdateShirtCommand request, CancellationToken cancellationToken)
    {
        var product = await _shirtRepository.GetByIdAsync(request.Id);
       
            product.UpdateShirt(
                request.Name,
                request.Description,
                request.ImagesUrl,
                request.Stock,
                request.DataObjectValue,
                request.FlagsObjectValue,
                request.PriceObjectValue,
                request.SpecificationObjectValue,
                request.WarrantyObjectValue,
                request.MainFeaturesObjectValue,
                request.OtherFeaturesObjectValue,
                request.CommonPropertiesObjectValue,
                request.CategoryId);

            return await _shirtRepository.UpdateAsync(product);
    }
}
