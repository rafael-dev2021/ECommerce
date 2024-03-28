namespace Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class DisplayObjectValue
{
    public string DisplayType { get; private set; } = string.Empty;
    public string DisplayResolution { get; private set; } = string.Empty;
    public string DisplayProtection { get; private set; } = string.Empty;
    public double DisplaySizeInches { get; private set; }
    
    public void SetDisplayType(string displayType) => DisplayType = displayType;
    public void SetDisplayResolution(string displayResolution) => DisplayResolution = displayResolution;
    public void SetDisplayProtection(string displayProtection) => DisplayProtection = displayProtection;
    public void SetDisplaySizeInches(double displaySizeInches) => DisplaySizeInches = displaySizeInches;
}