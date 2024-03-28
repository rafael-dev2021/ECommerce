namespace Domain.Entities.Products.Fashion.Shoes.ObjectValues;

public class MaterialObjectValue
{
    public string MaterialsFromAbroad { get; private set; } = string.Empty;
    public string InteriorMaterials { get; private  set; } = string.Empty;
    public string SoleMaterials { get; private  set; } = string.Empty;
    
    public void SetMaterialsFromAbroad(string materialsFromAbroad) => MaterialsFromAbroad = materialsFromAbroad;
    public void SetInteriorMaterials(string interiorMaterials) => InteriorMaterials = interiorMaterials;
    public void SetSoleMaterials(string soleMaterials) => SoleMaterials = soleMaterials;
}