using Domain.Entities.Payments.ObjectValues;

namespace Application.Dtos.PaymentsDto;

public class PaymentDto
{
    public int Id { get; protected set; }
    public string Ssn { get; protected set; } = string.Empty;
    public decimal Amount { get; protected set; }
    public PaymentMethodObjectValue PaymentMethodObjectValue { get; } = new();
}
