using Application.Dtos.Products.Technology.Smartphones.ObjectValues;

namespace Application.Dtos.Products.Technology.Smartphones;

public class SmartphoneDto
{
    public BatteryDtoObjectValue? BatteryObjectValue { get; set; }
    public CameraDtoObjectValue? CameraObjectValue { get; set; }
    public DimensionDtoObjectValue? DimensionObjectValue { get; set; }
    public DisplayDtoObjectValue? DisplayObjectValue { get; set; }
    public FeatureDtoObjectValue? FeatureObjectValue { get; set; }
    public PlatformDtoObjectValue? PlatformObjectValue { get; set; }
    public StorageDtoObjectValue? StorageObjectValue { get; set; }
}