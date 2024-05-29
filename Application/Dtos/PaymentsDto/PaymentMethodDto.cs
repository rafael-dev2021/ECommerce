namespace Application.Dtos.PaymentsDto;

public record PaymentMethodDto(CreditCardDto CreditCard, DebitCardDto DebitCard) { }
