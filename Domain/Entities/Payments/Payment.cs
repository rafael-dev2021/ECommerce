using Domain.Entities.Payments.Enums;
using Domain.Entities.Payments.ObjectValues;

namespace Domain.Entities.Payments;

public abstract class Payment
{
    public int Id { get; protected set; }
    public string Ssn { get; protected set; } = string.Empty;
    public decimal Amount { get; protected set; }
    public PaymentMethodObjectValue PaymentMethodObjectValue { get; } = new();

    
    public void SetId(int id) => Id = id;
    public void SetSsn(string ssn) => Ssn = ssn;
    public void SetAmount(decimal amount) => Amount = amount;
    public abstract void DefaultPayment(EPaymentMethod ePaymentMethod);
}