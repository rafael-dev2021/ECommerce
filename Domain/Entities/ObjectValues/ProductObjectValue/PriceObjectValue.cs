namespace Domain.Entities.ObjectValues.ProductObjectValue;

public class PriceObjectValue
{
    public decimal Price { get; private set; }
    public decimal HistoryPrice { get; private set; }

    public void SetPrice(decimal price) => Price = price;
    public void SetHistoryPrice(decimal historyPrice) => HistoryPrice = historyPrice;
}