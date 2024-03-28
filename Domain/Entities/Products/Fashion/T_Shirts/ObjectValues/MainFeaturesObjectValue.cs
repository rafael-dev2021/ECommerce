namespace Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;

public class MainFeaturesObjectValue
{
    public string Gender { get; private set; } = string.Empty;
    public string Age { get; private set; } = string.Empty;
    public string TypeOfClothing { get; private set; } = string.Empty;
    public string FabricDesign { get; private set; } = string.Empty;
    public string Size { get; private set; } = string.Empty;
    
    public void SetGender(string gender) => Gender = gender;
    public void SetAge(string age) => Age = age;
    public void SetTypeOfClothing(string typeOfClothing) => TypeOfClothing = typeOfClothing;
    public void SetFabricDesign(string fabricDesign) => FabricDesign = fabricDesign;
    public void SetSize(string size) => Size = size;
}