using Application.Dtos.CartDto;
using AutoMapper;
using Domain.Entities.Cart;

namespace Application.Mappings;

public class MappingTheShoppingCartProfile : Profile
{
    public MappingTheShoppingCartProfile()
    {
        CreateMap<ShoppingCartItem, ShoppingCartItemDto>().ReverseMap();
    }
}
