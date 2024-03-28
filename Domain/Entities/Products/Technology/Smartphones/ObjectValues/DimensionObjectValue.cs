namespace Domain.Entities.Products.Technology.Smartphones.ObjectValues;

public class DimensionObjectValue
{
    public double HeightInches { get; private set; }
    public double WidthInches { get; private set; }
    public double ThicknessInches { get; private set; }
    
    public void SetHeightInches(double heightInches) => HeightInches = heightInches;
    public void SetWidthInches(double widthInches) => WidthInches = widthInches;
    public void SetThicknessInches(double thicknessInches) => ThicknessInches = thicknessInches;
}