namespace Domain.Entities;

public sealed class Category(int id, string name, string imagesUrl, bool isActive)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string ImageUrl { get; private set; } = imagesUrl;
    public bool IsActive { get; private set; } = isActive;
    public ICollection<Product> Products { get; } = [];
}