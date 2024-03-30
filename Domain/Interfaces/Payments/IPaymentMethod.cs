namespace Domain.Interfaces.Payments;

public interface IPaymentMethod
{
    void CreditCardPaymentMethod(string creditCardNumber);
    void DebitCardPaymentMethod(string debitCardNumber);
    void BankSlipPaymentMethod();
}