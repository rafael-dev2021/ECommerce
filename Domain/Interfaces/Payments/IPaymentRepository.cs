using Domain.Entities.Payments;

namespace Domain.Interfaces.Payments;

public interface IPaymentRepository
{
    Task<IEnumerable<PaymentMethod>> ListPaymentsAsync();
    Task<IEnumerable<CreditCard>> ListPaymentCreditCardsAsync();
    Task<IEnumerable<DebitCard>> ListPaymentDebitCardsAsync();

    Task<PaymentMethod> GetByIdPaymentAsync(int? id);
    Task<CreditCard> GetByIdPaymentCreditCardAsync(Guid? id);
    Task<DebitCard> GetByIdPaymentDebitCardAsync(Guid? id);
    //Task<IEnumerable<Payment>> ListPaymentBankSlipAsync();
}