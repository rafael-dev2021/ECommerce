namespace Domain.Entities;

public class CategoryWithProductCount
{
    public string CategoryName { get; protected set; } = string.Empty;
    public int ProductCount { get; protected set; } = 0;
}