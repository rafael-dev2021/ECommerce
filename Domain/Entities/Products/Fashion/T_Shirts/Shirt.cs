using Domain.Entities.ObjectValues.ProductObjectValue;
using Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;

namespace Domain.Entities.Products.Fashion.T_Shirts;

public sealed class Shirt : Product
{
    public Shirt(int id, string name, string description, List<string> imagesUrl, int stock, int categoryId) :
        base(id, name, description, imagesUrl, stock, categoryId)
    {
    }

    public Shirt(
        string name,
        string description,
        List<string> imagesUrl,
        int stock, 
        DataObjectValue? dataObjectValue,
        FlagsObjectValue? flagsObjectValue,
        PriceObjectValue? priceObjectValue,
        SpecificationObjectValue? specificationObjectValue, 
        WarrantyObjectValue? warrantyObjectValue,
        MainFeaturesObjectValue? mainFeaturesObjectValue,
        OtherFeaturesObjectValue? otherFeaturesObjectValue,
        CommonPropertiesObjectValue? commonPropertiesObjectValue,
        int categoryId) :
        base(
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
        MainFeaturesObjectValue = mainFeaturesObjectValue;
        OtherFeaturesObjectValue = otherFeaturesObjectValue;
    }
    
    public void UpdateShirt(        
        string name,
        string description,
        List<string> imagesUrl,
        int stock, 
        DataObjectValue? dataObjectValue,
        FlagsObjectValue? flagsObjectValue,
        PriceObjectValue? priceObjectValue,
        SpecificationObjectValue? specificationObjectValue, 
        WarrantyObjectValue? warrantyObjectValue,
        MainFeaturesObjectValue? mainFeaturesObjectValue,
        OtherFeaturesObjectValue? otherFeaturesObjectValue,
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
        MainFeaturesObjectValue = mainFeaturesObjectValue;
        OtherFeaturesObjectValue = otherFeaturesObjectValue;
    }

    public MainFeaturesObjectValue? MainFeaturesObjectValue { get; private set; }
    public OtherFeaturesObjectValue? OtherFeaturesObjectValue { get; private set; } 
}