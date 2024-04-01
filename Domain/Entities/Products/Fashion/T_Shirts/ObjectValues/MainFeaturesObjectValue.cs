namespace Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;

public class MainFeaturesObjectValue 
{
    public string TypeOfClothing { get; private set; } = string.Empty;
    public string FabricDesign { get; private set; } = string.Empty;
    
    public void SetTypeOfClothing(string typeOfClothing) => TypeOfClothing = typeOfClothing;
    public void SetFabricDesign(string fabricDesign) => FabricDesign = fabricDesign;
}