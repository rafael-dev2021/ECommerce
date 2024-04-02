using Application.Dtos.Products.Fashion.Shoes;
using Application.Dtos.Products.Fashion.Shoes.ObjectValues;
using AutoMapper;
using Domain.Entities.Products.Fashion.Shoes;
using Domain.Entities.Products.Fashion.Shoes.ObjectValues;

namespace Application.Mappings.Products.Fashion;

public class MappingTheShoeProfile : Profile
{
    public MappingTheShoeProfile()
    {
        CreateMap<Shoe, ShoeDto>().ReverseMap();
        CreateMap<MaterialObjectValue, MaterialDtoObjectValue>().ReverseMap();
    }
}