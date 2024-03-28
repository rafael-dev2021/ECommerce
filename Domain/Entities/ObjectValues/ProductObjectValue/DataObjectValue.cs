namespace Domain.Entities.ObjectValues.ProductObjectValue;

public class DataObjectValue
{
    public string ReleaseMonth { get; private set; } = string.Empty;
    public int ReleaseYear { get; private set; }
    
    public void SetReleaseMonth(string month) => ReleaseMonth = month;
    public void SetReleaseYear(int year) => ReleaseYear = year;
}