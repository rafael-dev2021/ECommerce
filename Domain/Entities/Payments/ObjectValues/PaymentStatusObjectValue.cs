using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Payments.Enums;
using Domain.Interfaces.Payments;

namespace Domain.Entities.Payments.ObjectValues;

public class PaymentStatusObjectValue : IPaymentStatus
{
    [EnumDataType(typeof(EPaymentStatus))] 
    public string PaymentStatus { get; protected set; } = string.Empty;

    [NotMapped] public EPaymentStatus EPaymentStatus { get; protected set; }

    public void SetPaymentStatus(EPaymentStatus status)
    {
        EPaymentStatus = status;
        PaymentStatus = status.ToString();
    }

    public void PaymentPending() => SetPaymentStatus(EPaymentStatus.Pending);
    public void PaymentProcessing() => SetPaymentStatus(EPaymentStatus.Processing);
    public void PaymentApproved() => SetPaymentStatus(EPaymentStatus.Approved);
    public void PaymentDeclined() => SetPaymentStatus(EPaymentStatus.Declined);
    public void PaymentRefunded() => SetPaymentStatus(EPaymentStatus.Refunded);
    public void PaymentCompleted() => SetPaymentStatus(EPaymentStatus.Completed);
    public void PaymentCanceled() => SetPaymentStatus(EPaymentStatus.Canceled);
}