namespace Domain.Entities.ObjectValues.ProductObjectValue;

public class SpecificationObjectValue
{
    public string Model { get; private set; } = string.Empty;
    public string Brand { get; private  set; } = string.Empty;
    public string Line { get; private  set; } = string.Empty;
    public string Weight { get; private  set; } = string.Empty;
    public string Type { get; private  set; } = string.Empty;
    
    public void SetModel(string model) => Model = model;
    public void SetBrand(string brand) => Brand = brand;
    public void SetLine(string line) => Line = line;
    public void SetWeight(string weight) => Weight = weight;
    public void SetType(string type) => Type = type;
}