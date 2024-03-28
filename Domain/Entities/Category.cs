namespace Domain.Entities;

public sealed class Category(int id, string name, List<string> imagesUrl, bool isActive)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public List<string> ImagesUrl { get; private set; } = imagesUrl;
    public bool IsActive { get; private set; } = isActive;
    public ICollection<Product> Products { get; } = [];
}