namespace Application.Dtos.PaymentsDto;

public class CardDto
{
    public Guid Id { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public string CardHolderName { get; set; } = string.Empty;
    public string CardExpirationDate { get; set; } = string.Empty;
    public string CardCvv { get; set; } = string.Empty;
    public string Ssn { get; set; } = string.Empty;
}

