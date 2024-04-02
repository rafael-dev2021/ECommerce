using Domain.Entities.ObjectValues.ProductObjectValue;
using Domain.Entities.Products.Fashion.Shoes;
using Domain.Entities.Products.Fashion.Shoes.ObjectValues;
using MediatR;

namespace Application.CQRS.Command.Products.Fashion.Shoes;

public class ShoesCommand : IRequest<Shoe>
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
    public MaterialObjectValue? MaterialObjectValue { get; set; }
    public int CategoryId { get; set; }
}