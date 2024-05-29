﻿using Application.CustomExceptions;
using Application.Dtos.PaymentsDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces.Payments;

namespace Application.Services.Entities;

public class PaymentDtoService(IPaymentRepository paymentRepository, IMapper mapper) : IPaymentDtoService
{
    private readonly IPaymentRepository _paymentRepository = paymentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<PaymentMethodDto>> ListPaymentsDtoAsync()
    {
        var payments = await _paymentRepository.ListPaymentsAsync();

        if (payments == null) return [];

        return _mapper.Map<IEnumerable<PaymentMethodDto>>(payments);
    }

    public async Task<IEnumerable<CreditCardDto>> ListPaymentCreditCardsDtoAsync()
    {
        var creditCards = await _paymentRepository.ListPaymentCreditCardsAsync();

        if (creditCards == null) return [];

        return _mapper.Map<IEnumerable<CreditCardDto>>(creditCards);
    }

    public async Task<IEnumerable<DebitCardDto>> ListPaymentDebitCardsDtoAsync()
    {
        var debitCards = await _paymentRepository.ListPaymentDebitCardsAsync();

        if (debitCards == null) return [];

        return _mapper.Map<IEnumerable<DebitCardDto>>(debitCards);
    }

    public async Task<PaymentMethodDto> GetByIdPaymentDtoAsync(int? id)
    {
        try
        {
            var paymentId = await _paymentRepository.GetByIdPaymentAsync(id);
            return _mapper.Map<PaymentMethodDto>(paymentId);
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
            var creditCardId = await _paymentRepository.GetByIdPaymentCreditCardAsync(id);
            return _mapper.Map<CreditCardDto>(creditCardId);
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
            var debitCardId = await _paymentRepository.GetByIdPaymentDebitCardAsync(id);
            return _mapper.Map<DebitCardDto>(debitCardId);
        }
        catch (Exception ex)
        {
            throw new PaymentException("ID not found", ex);
        }
    }
}