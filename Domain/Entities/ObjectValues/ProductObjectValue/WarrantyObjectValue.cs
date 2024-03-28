namespace Domain.Entities.ObjectValues.ProductObjectValue;

public class WarrantyObjectValue
{
    public string WarrantyLength { get; private set; } = string.Empty;
    public string WarrantyInformation { get; private  set; } = string.Empty;
    
    public void SetWarrantyLength(string warrantyLength) => WarrantyLength = warrantyLength;
    public void SetWarrantyInformation(string warrantyInformation) => WarrantyInformation = warrantyInformation;
}