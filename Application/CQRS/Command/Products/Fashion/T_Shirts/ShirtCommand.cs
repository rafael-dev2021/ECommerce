using Domain.Entities.ObjectValues.ProductObjectValue;
using Domain.Entities.Products.Fashion.T_Shirts;
using Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;
using MediatR;

namespace Application.CQRS.Command.Products.Fashion.T_Shirts;

public class ShirtCommand : IRequest<Shirt>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; }= string.Empty;
    public List<string> ImagesUrl { get; set; } =[];
    public int Stock { get; set; }
    public DataObjectValue? DataObjectValue { get; set; }
    public FlagsObjectValue? FlagsObjectValue { get; set; }
    public PriceObjectValue? PriceObjectValue { get; set; }
    public SpecificationObjectValue? SpecificationObjectValue { get; set; }
    public WarrantyObjectValue? WarrantyObjectValue { get; set; }
    public CommonPropertiesObjectValue? CommonPropertiesObjectValue { get; set; }
    public MainFeaturesObjectValue? MainFeaturesObjectValue { get; set; }
    public OtherFeaturesObjectValue? OtherFeaturesObjectValue { get; set; }
    public int CategoryId { get; set; }
}