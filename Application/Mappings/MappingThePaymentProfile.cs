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
        CreateMap<PaymentMethod, PaymentMethodDto>().ReverseMap();
        CreateMap<Payment, PaymentDto>().ReverseMap();
    }
}
