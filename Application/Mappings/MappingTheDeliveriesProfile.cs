using Application.Dtos.DeliveriesDto;
using AutoMapper;
using Domain.Entities.Deliveries;

namespace Application.Mappings;

public class MappingTheDeliveriesProfile : Profile
{
    public MappingTheDeliveriesProfile()
    {
        CreateMap<DeliveryAddress, DeliveryAddressDto>().ReverseMap();
        CreateMap<UserDelivery, UserDeliveryDto>().ReverseMap();
    }
}
