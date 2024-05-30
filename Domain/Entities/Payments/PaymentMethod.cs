using Domain.Entities.Payments.Enums;

namespace Domain.Entities.Payments;

public class PaymentMethod : Payment
{
    public CreditCard CreditCard { get; private set; } = new();
    public DebitCard DebitCard { get; private set; } = new();

    public void SetCreditCard(CreditCard value) => CreditCard = value;
    public void SetDebitCard(DebitCard value) => DebitCard = value;

    public override void DefaultPayment(EPaymentMethod ePaymentMethod)
    {
        switch (ePaymentMethod)
        {
            case EPaymentMethod.CreditCard:
                PaymentMethodObjectValue.CreditCardPaymentMethod(CreditCard.CardNumber);
                break;
            case EPaymentMethod.DebitCard:
                PaymentMethodObjectValue.DebitCardPaymentMethod(DebitCard.CardNumber);
                break;
            case EPaymentMethod.BankSlip:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(ePaymentMethod), ePaymentMethod, null);
        }
    }
}