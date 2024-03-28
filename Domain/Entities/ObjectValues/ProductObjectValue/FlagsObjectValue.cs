namespace Domain.Entities.ObjectValues.ProductObjectValue;

public class FlagsObjectValue
{
    public bool IsFavorite { get; private set; }
    public bool IsDailyOffer { get; private set; }
    public bool IsBestSeller { get; private set; }

    public void SetIsFavorite(bool value) => IsFavorite = value;
    public void SetIsDailyOffer(bool value) => IsDailyOffer = value;
    public void SetIsBestSeller(bool value) => IsBestSeller = value;
}