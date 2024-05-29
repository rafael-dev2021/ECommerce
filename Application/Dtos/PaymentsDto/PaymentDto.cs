using Domain.Entities.Payments.ObjectValues;

namespace Application.Dtos.PaymentsDto;

public class PaymentDto
{
    public int Id { get; set; }
    public string Ssn { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public PaymentMethodObjectValue PaymentMethodObjectValue { get; set; } = new();
}
