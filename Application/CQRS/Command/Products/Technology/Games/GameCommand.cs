using Domain.Entities.ObjectValues.ProductObjectValue;
using Domain.Entities.Products.Technology.Games;
using Domain.Entities.Products.Technology.Games.ObjectValues;
using MediatR;

namespace Application.CQRS.Command.Products.Technology.Games;

public class GameCommand : IRequest<Game>
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
    public GeneralFeaturesObjectValue? GeneralFeaturesObjectValue { get; set; }
    public MediaSpecificationObjectValue? MediaSpecificationObjectValue { get; set; }
    public RequirementObjectValue? RequirementObjectValue { get; set; }
    public CommonPropertiesObjectValue? CommonPropertiesObjectValue { get; set; }
    public int CategoryId { get; set; }
}