namespace Domain.Entities.Products.Technology.Games.ObjectValues;

public class RequirementObjectValue
{
    public int MinimumRamRequirementInMb { get; private set; }
    public string MinimumOperatingSystemsRequired { get; private set; } = string.Empty;
    public string MinimumGraphicsProcessorsRequired { get; private set; } = string.Empty;
    public string MinimumProcessorsRequired { get; private set; } = string.Empty;
    
    public void SetMinimumRamRequirementInMb(int value) => MinimumRamRequirementInMb = value;
    public void SetMinimumOperatingSystemsRequired(string value) => MinimumOperatingSystemsRequired = value;
    public void SetMinimumGraphicsProcessorsRequired(string value) => MinimumGraphicsProcessorsRequired = value;
    public void SetMinimumProcessorsRequired(string value) => MinimumProcessorsRequired = value;

}