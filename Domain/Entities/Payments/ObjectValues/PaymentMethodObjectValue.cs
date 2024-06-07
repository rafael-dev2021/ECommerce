using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Payments.Algorithms;
using Domain.Entities.Payments.Enums;
using Domain.Interfaces.Payments;

namespace Domain.Entities.Payments.ObjectValues;

public class PaymentMethodObjectValue : IPaymentMethod
{
    [EnumDataType(typeof(EPaymentMethod))] public string PaymentMethod { get; private set; } = string.Empty;
    [NotMapped] public EPaymentMethod EPaymentMethod { get; protected set; }
    public PaymentStatusObjectValue PaymentStatusObjectValue { get; private set; } = new();
    public Guid Reference { get; private set; }
    
    public DateTime PaymentDate { get; private set; }

    public void SetPaymentStatusObjectValue(PaymentStatusObjectValue value) => PaymentStatusObjectValue = value;
    private void PaymentDateConfirm() => PaymentDate = DateTime.Now;
    private void SetReference() => Reference = Guid.NewGuid();
    
    public void CreditCardPaymentMethod(string creditCardNumber) =>
        ProcessPayment(creditCardNumber, EPaymentMethod.CreditCard);

    public void DebitCardPaymentMethod(string debitCardNumber) =>
        ProcessPayment(debitCardNumber, EPaymentMethod.DebitCard);

    public void BankSlipPaymentMethod()
    {
        EPaymentMethod = EPaymentMethod.BankSlip;
        PaymentMethod = EPaymentMethod.BankSlip.ToString();
        SetReference();
        PaymentDateConfirm();
    }

    private void ProcessPayment(string cardNumber, EPaymentMethod method)
    {
        EPaymentMethod = method;
        PaymentMethod = method.ToString();
        var isPaymentCompleted = CardValidateNumber
            .ValidateCardNumber(cardNumber);
        if (isPaymentCompleted)
        {
            PaymentStatusObjectValue.PaymentProcessing();
            SetReference();

            Thread.Sleep(2500);

            PaymentStatusObjectValue.PaymentApproved();
            PaymentDateConfirm();
        }
        else
        {
            PaymentStatusObjectValue?.PaymentDeclined();

        }
    }
}