using Domain.Entities.Payments.Algorithms;
using Domain.Entities.Payments.Enums;
using Domain.Interfaces.Payments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Payments.ObjectValues;

public class PaymentMethodObjectValue : IPaymentMethod
{
    [EnumDataType(typeof(EPaymentMethod))]
    public string PaymentMethod { get; protected set; } = string.Empty;

    [NotMapped]
    public EPaymentMethod EPaymentMethod { get; protected set; }
    public PaymentStatusObjectValue PaymentStatusObjectValue { get; protected set; } = new();
    public Guid Reference { get; protected set; }
    public DateTime PaymentDate { get; protected set; }

    public void SetPaymentStatusObjectValue(PaymentStatusObjectValue value) => PaymentStatusObjectValue = value;

    public void CreditCardPaymentMethod(string cardNumber) =>
       ProcessPayment(cardNumber, EPaymentMethod.CreditCard);

    public void DebitCardPaymentMethod(string cardNumber) =>
        ProcessPayment(cardNumber, EPaymentMethod.DebitCard);

    public void BankSlipPaymentMethod()
    {
        EPaymentMethod = EPaymentMethod.BankSlip;
        PaymentMethod = EPaymentMethod.BankSlip.ToString();
        SetReference();
        PaymentDateConfirm();
    }

    private void PaymentDateConfirm() => PaymentDate = DateTime.Now;
    private void SetReference() => Reference = Guid.NewGuid();

    private void ProcessPayment(string cardNumber, EPaymentMethod method)
    {
        EPaymentMethod = method;
        PaymentMethod = method.ToString();
        bool isPaymentCompleted = CardValidateNumber
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