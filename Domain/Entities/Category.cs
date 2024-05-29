namespace Domain.Entities;

public sealed class Category(int id, string name, string imageUrl, bool isActive)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string ImageUrl { get; private set; } = imageUrl;
    public bool IsActive { get; private set; } = isActive;
    public ICollection<Product> Products { get; } = [];

    public void SetName(string name) => Name = name;
}