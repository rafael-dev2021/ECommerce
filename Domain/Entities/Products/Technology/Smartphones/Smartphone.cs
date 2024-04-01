using Domain.Entities.ObjectValues.ProductObjectValue;
using Domain.Entities.Products.Technology.Smartphones.ObjectValues;

namespace Domain.Entities.Products.Technology.Smartphones;

public sealed class Smartphone : Product
{
    public Smartphone(int id, string name, string description, List<string> imagesUrl,
        int stock, int categoryId) : base(id, name, description, imagesUrl, stock, categoryId)
    {
    }

    public Smartphone(
        string name,
        string description,
        List<string> imagesUrl,
        int stock,
        DataObjectValue? dataObjectValue,
        FlagsObjectValue? flagsObjectValue,
        PriceObjectValue? priceObjectValue,
        SpecificationObjectValue? specificationObjectValue,
        WarrantyObjectValue? warrantyObjectValue,
        BatteryObjectValue? batteryObjectValue,
        CameraObjectValue? cameraObjectValue,
        DimensionObjectValue? dimensionObjectValue,
        DisplayObjectValue? displayObjectValue,
        FeatureObjectValue? featureObjectValue,
        PlatformObjectValue? platformObjectValue,
        StorageObjectValue? storageObjectValue,
        CommonPropertiesObjectValue? commonPropertiesObjectValue,
        int categoryId
    ) : base(
        name,
        description,
        imagesUrl,
        stock,
        dataObjectValue,
        flagsObjectValue,
        priceObjectValue,
        specificationObjectValue,
        warrantyObjectValue,
        commonPropertiesObjectValue,
        categoryId)
    {
        BatteryObjectValue = batteryObjectValue;
        CameraObjectValue = cameraObjectValue;
        DimensionObjectValue = dimensionObjectValue;
        DisplayObjectValue = displayObjectValue;
        FeatureObjectValue = featureObjectValue;
        PlatformObjectValue = platformObjectValue;
        StorageObjectValue = storageObjectValue;
    }

    public void UpdateSmartphone(
        string name,
        string description,
        List<string> imagesUrl,
        int stock,
        DataObjectValue? dataObjectValue,
        FlagsObjectValue? flagsObjectValue,
        PriceObjectValue? priceObjectValue,
        SpecificationObjectValue? specificationObjectValue,
        WarrantyObjectValue? warrantyObjectValue,
        BatteryObjectValue? batteryObjectValue,
        CameraObjectValue? cameraObjectValue,
        DimensionObjectValue? dimensionObjectValue,
        DisplayObjectValue? displayObjectValue,
        FeatureObjectValue? featureObjectValue,
        PlatformObjectValue? platformObjectValue,
        StorageObjectValue? storageObjectValue,
        CommonPropertiesObjectValue? commonPropertiesObjectValue,
        int categoryId)
    {
        UpdateProduct(
            name,
            description,
            imagesUrl,
            stock,
            dataObjectValue,
            flagsObjectValue,
            priceObjectValue,
            specificationObjectValue,
            warrantyObjectValue,
            commonPropertiesObjectValue,
            categoryId);
        BatteryObjectValue = batteryObjectValue;
        CameraObjectValue = cameraObjectValue;
        DimensionObjectValue = dimensionObjectValue;
        DisplayObjectValue = displayObjectValue;
        FeatureObjectValue = featureObjectValue;
        PlatformObjectValue = platformObjectValue;
        StorageObjectValue = storageObjectValue;
    }

    public BatteryObjectValue? BatteryObjectValue { get; private set; }
    public CameraObjectValue? CameraObjectValue { get; private set; }
    public DimensionObjectValue? DimensionObjectValue { get; private set; }
    public DisplayObjectValue? DisplayObjectValue { get; private set; }
    public FeatureObjectValue? FeatureObjectValue { get; private set; }
    public PlatformObjectValue? PlatformObjectValue { get; private set; }
    public StorageObjectValue? StorageObjectValue { get; private set; }
}