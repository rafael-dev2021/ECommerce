using Application.Dtos.PaymentsDto;
using AutoMapper;
using Domain.Entities.Payments;

namespace Application.Mappings;

public class MappingThePaymentProfile : Profile
{
    public MappingThePaymentProfile()
    {
        CreateMap<Card, CardDto>().ReverseMap();
        CreateMap<CreditCard, CreditCardDto>().ReverseMap();
        CreateMap<DebitCard, DebitCardDto>().ReverseMap();
        CreateMap<PaymentMethod, PaymentMethodDto>()
             .ForMember(dest => dest.CreditCard, opt => opt.MapFrom(src => src.CreditCard))
             .ForMember(dest => dest.DebitCard, opt => opt.MapFrom(src => src.DebitCard))
             .ReverseMap();
        CreateMap<Payment, PaymentDto>().ReverseMap();
    }
}
