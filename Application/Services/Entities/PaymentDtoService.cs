using Application.CustomExceptions;
using Application.Dtos.PaymentsDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces.Payments;

namespace Application.Services.Entities;

public class PaymentDtoService(IPaymentRepository paymentRepository, IMapper mapper) : IPaymentDtoService
{
    public async Task<IEnumerable<PaymentMethodDto>> ListPaymentsDtoAsync()
    {
        var payments = await paymentRepository.ListPaymentsAsync();

        return mapper.Map<IEnumerable<PaymentMethodDto>>(payments);
    }

    public async Task<IEnumerable<CreditCardDto>> ListPaymentCreditCardsDtoAsync()
    {
        var creditCards = await paymentRepository.ListPaymentCreditCardsAsync();

        return mapper.Map<IEnumerable<CreditCardDto>>(creditCards);
    }

    public async Task<IEnumerable<DebitCardDto>> ListPaymentDebitCardsDtoAsync()
    {
        var debitCards = await paymentRepository.ListPaymentDebitCardsAsync();

        return mapper.Map<IEnumerable<DebitCardDto>>(debitCards);
    }

    public async Task<PaymentMethodDto> GetByIdPaymentDtoAsync(int? id)
    {
        try
        {
            var paymentId = await paymentRepository.GetByIdPaymentAsync(id);
            return mapper.Map<PaymentMethodDto>(paymentId);
        }
        catch (Exception ex)
        {
            throw new PaymentException("ID not found", ex);
        }
    }

    public async Task<CreditCardDto> GetByIdPaymentCreditCardDtoAsync(Guid? id)
    {
        try
        {
            var creditCardId = await paymentRepository.GetByIdPaymentCreditCardAsync(id);
            return mapper.Map<CreditCardDto>(creditCardId);
        }
        catch (Exception ex)
        {
            throw new PaymentException("ID not found", ex);
        }
    }

    public async Task<DebitCardDto> GetByIdPaymentDebitCardDtoAsync(Guid? id)
    {
        try
        {
            var debitCardId = await paymentRepository.GetByIdPaymentDebitCardAsync(id);
            return mapper.Map<DebitCardDto>(debitCardId);
        }
        catch (Exception ex)
        {
            throw new PaymentException("ID not found", ex);
        }
    }
}