namespace WebUI.ViewModels;

public class FilterProductsViewModel
{
    public string CategoryStr { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 9;
    public string Keyword { get; set; } = "";
    public string? MinPrice { get; set; } = null;
    public string? MaxPrice { get; set; } = null;
    public bool? IsDailyOffer { get; set; } = null;
    public bool? IsBestSeller { get; set; } = null;
    public bool? IsPriceHigh { get; set; } = null;
    public bool? IsPriceLow { get; set; } = null;
    public bool? ShowAvailableOnly { get; set; } = null;
    public bool? HasReviews { get; set; } = null;
}
