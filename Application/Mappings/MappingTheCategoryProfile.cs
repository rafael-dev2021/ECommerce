using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class MappingTheCategoryProfile : Profile
{
    public MappingTheCategoryProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
