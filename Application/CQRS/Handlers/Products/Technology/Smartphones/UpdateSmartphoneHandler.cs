using Application.CQRS.Command.Products.Technology.Smartphones;
using Domain.Entities.Products.Technology.Smartphones;
using Domain.Interfaces.Products.Technology;
using MediatR;

namespace Application.CQRS.Handlers.Products.Technology.Smartphones;

public class UpdateSmartphoneHandler(ISmartphoneRepository smartphoneRepository) :
    IRequestHandler<UpdateSmartphoneCommand, Smartphone>
{
    private readonly ISmartphoneRepository _smartphoneRepository = smartphoneRepository;

    public async Task<Smartphone> Handle(UpdateSmartphoneCommand request, CancellationToken cancellationToken)
    {
        var product = await _smartphoneRepository.GetByIdAsync(request.Id);

        product.UpdateSmartphone(
            request.Name,
            request.Description,
            request.ImagesUrl,
            request.Stock,
            request.DataObjectValue,
            request.FlagsObjectValue,
            request.PriceObjectValue,
            request.SpecificationObjectValue,
            request.WarrantyObjectValue,
            request.BatteryObjectValue,
            request.CameraObjectValue,
            request.DimensionObjectValue,
            request.DisplayObjectValue,
            request.FeatureObjectValue,
            request.PlatformObjectValue,
            request.StorageObjectValue,
            request.CommonPropertiesObjectValue,
            request.CategoryId);

        return await _smartphoneRepository.UpdateAsync(product);
    }
}