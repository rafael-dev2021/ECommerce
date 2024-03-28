namespace Domain.Entities.Products.Fashion;

public class CommonProperties
{
    public string Gender { get; private set; } = string.Empty;
    public string Color { get; private  set; } = string.Empty;
    public string Age { get; private  set; } = string.Empty;
    public string RecommendedUses { get; private set; } = string.Empty;
    public string Size { get; protected set; } = string.Empty;

    public void SetGender(string gender) => Gender = gender;
    public void SetColor(string color) => Color = color;
    public void SetAge(string age) => Age = age;
    public void SetRecommendedUses(string recommendedUses) => RecommendedUses = recommendedUses;
    public void SetSize(string size) => Size = size;
}