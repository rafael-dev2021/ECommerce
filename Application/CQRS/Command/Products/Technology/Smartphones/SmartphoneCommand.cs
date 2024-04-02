using Domain.Entities.ObjectValues.ProductObjectValue;
using Domain.Entities.Products.Technology.Smartphones;
using Domain.Entities.Products.Technology.Smartphones.ObjectValues;
using MediatR;

namespace Application.CQRS.Command.Products.Technology.Smartphones;

public class SmartphoneCommand : IRequest<Smartphone>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; }= string.Empty;
    public List<string> ImagesUrl { get; set; } =[];
    public int Stock { get; set; }
    public DataObjectValue? DataObjectValue { get; set; }
    public FlagsObjectValue? FlagsObjectValue { get; set; }
    public PriceObjectValue? PriceObjectValue { get; set; }
    public SpecificationObjectValue? SpecificationObjectValue { get; set; }
    public WarrantyObjectValue? WarrantyObjectValue { get; set; }
    public BatteryObjectValue? BatteryObjectValue { get; set; }
    public CameraObjectValue? CameraObjectValue { get; set; }
    public DimensionObjectValue? DimensionObjectValue { get; set; }
    public DisplayObjectValue? DisplayObjectValue { get; set; }
    public FeatureObjectValue? FeatureObjectValue { get; set; }
    public PlatformObjectValue? PlatformObjectValue { get; set; }
    public StorageObjectValue? StorageObjectValue { get; set; }
    public CommonPropertiesObjectValue? CommonPropertiesObjectValue { get; set; }
    public int CategoryId { get; set; }
}