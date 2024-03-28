namespace Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;

public class OtherFeaturesObjectValue
{
    public string RecommendedUses { get; private set; } = string.Empty;
    public string Composition { get; private  set; } = string.Empty;
    public string MainMaterial { get; private  set; } = string.Empty;
    public int UnitsPerKit { get; private  set; }
    public bool WithRecycledMaterials { get; private  set; }
    public bool ItsSporty { get; private  set; }
    
    public void SetRecommendedUses(string recommendedUses) => RecommendedUses = recommendedUses;
    public void SetComposition(string composition) => Composition = composition;
    public void SetMainMaterial(string mainMaterial) => MainMaterial = mainMaterial;
    public void SetUnitsPerKit(int unitsPerKit) => UnitsPerKit = unitsPerKit;
    public void SetWithRecycledMaterials(bool withRecycledMaterials) => WithRecycledMaterials = withRecycledMaterials;
    public void SetItsSporty(bool itsSporty) => ItsSporty = itsSporty;
}