using Application.CQRS.Command.Products.Technology.Smartphones;
using Domain.Entities.Products.Technology.Smartphones;
using Domain.Interfaces.Products.Technology;
using MediatR;

namespace Application.CQRS.Handlers.Products.Technology.Smartphones;

public class CreateGameHandler(ISmartphoneRepository smartphoneRepository)
    : IRequestHandler<CreateSmartphoneCommand, Smartphone>
{
    private readonly ISmartphoneRepository _smartphoneRepository = smartphoneRepository ?? throw new ArgumentNullException(nameof(smartphoneRepository));

    public async Task<Smartphone> Handle(CreateSmartphoneCommand request, CancellationToken cancellationToken)
    {
        var product = new Smartphone( 
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

        product.SetCategoryId(request.CategoryId);
        return await _smartphoneRepository.CreateAsync(product);
    }
}
