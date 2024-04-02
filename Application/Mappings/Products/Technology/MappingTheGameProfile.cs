using Application.Dtos.Products.Technology.Games;
using Application.Dtos.Products.Technology.Games.ObjectValues;
using AutoMapper;
using Domain.Entities.Products.Technology.Games;
using Domain.Entities.Products.Technology.Games.ObjectValues;

namespace Application.Mappings.Products.Technology;

public class MappingTheGameProfile : Profile
{
    public MappingTheGameProfile()
    {
        CreateMap<Game, GameDto>().ReverseMap();
        CreateMap<GeneralFeaturesObjectValue, GeneralFeaturesDtoObjectValue>().ReverseMap();
        CreateMap<MediaSpecificationObjectValue, MediaSpecificationDtoObjectValue>().ReverseMap();
        CreateMap<RequirementObjectValue, RequirementDtoObjectValue>().ReverseMap();
    }
}