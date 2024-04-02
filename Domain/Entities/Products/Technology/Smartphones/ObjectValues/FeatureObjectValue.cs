namespace Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class FeatureObjectValue
{
    public string CellNetworkTechnology { get; private set; } = string.Empty;
    public string VirtualAssistant { get; private set; } = string.Empty;
    public string ManufacturerPartNumber { get; private set; } = string.Empty;
    
    public void SetCellNetworkTechnology(string cellNetworkTechnology) => CellNetworkTechnology = cellNetworkTechnology;
    public void SetVirtualAssistant(string virtualAssistant) => VirtualAssistant = virtualAssistant;
    public void SetManufacturerPartNumber(string manufacturerPartNumber) => ManufacturerPartNumber = manufacturerPartNumber;
}