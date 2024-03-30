namespace Domain.Entities.Payments;

public class Card
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string CardNumber { get; private set; } = string.Empty;
    public string CardHolderName { get; private set; } = string.Empty;
    public string CardExpirationDate { get; private set; } = string.Empty;
    public string CardCvv { get; private set; } = string.Empty;
    public string Ssn { get; private set; } = string.Empty;

    public Card(){}
    public void SetId(Guid id) => Id = id;
    public void SetCardNumber(string cardNumber) => CardNumber = cardNumber;
    public void SetCardHolderName(string cardHolderName) => CardHolderName = cardHolderName;
    public void SetCardExpirationDate(string cardExpirationDate) => CardExpirationDate = cardExpirationDate;
    public void SetCardCvv(string cardCvv) => CardCvv = cardCvv;
    public void SetSsn(string ssn) => Ssn = ssn;
}