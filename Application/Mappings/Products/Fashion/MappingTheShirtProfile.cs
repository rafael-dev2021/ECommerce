using Application.Dtos.Products.Fashion.T_Shirts;
using Application.Dtos.Products.Fashion.T_Shirts.ObjectValues;
using AutoMapper;
using Domain.Entities.Products.Fashion.T_Shirts;
using Domain.Entities.Products.Fashion.T_Shirts.ObjectValues;

namespace Application.Mappings.Products.Fashion;

public class MappingTheShirtProfile : Profile
{
    public MappingTheShirtProfile()
    {
        CreateMap<Shirt, ShirtDto>().ReverseMap();
        CreateMap<MainFeaturesObjectValue, MainFeaturesDtoObjectValue>().ReverseMap();
        CreateMap<OtherFeaturesObjectValue, OtherFeaturesDtoObjectValue>().ReverseMap();
    }
}