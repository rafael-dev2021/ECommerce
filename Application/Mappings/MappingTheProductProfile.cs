using Application.Dtos;
using Application.Dtos.ObjectsValues.ProductObjectValue;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.ObjectValues.ProductObjectValue;

namespace Application.Mappings;

public class MappingTheProductProfile : Profile
{
    public MappingTheProductProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<DataObjectValue, DataDtoObjectValue>().ReverseMap();
        CreateMap<FlagsObjectValue, FlagsDtoObjectValue>().ReverseMap();
        CreateMap<PriceObjectValue, PriceDtoObjectValue>().ReverseMap();
        CreateMap<SpecificationObjectValue, SpecificationDtoObjectValue>().ReverseMap();
        CreateMap<WarrantyObjectValue, WarrantyDtoObjectValue>().ReverseMap();
        CreateMap<CommonPropertiesObjectValue, CommonPropertiesDtoObjectValue>().ReverseMap();
    }
}