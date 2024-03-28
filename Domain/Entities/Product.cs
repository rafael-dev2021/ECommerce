namespace Domain.Entities;

public class Product
{
    public int Id { get; protected set; }
    public string Name { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;
    public List<string> ImagesUrl { get; protected set; } = [];
    public byte[] RowVersion { get; protected set; } = [];
    public int Stock { get; protected set; }
    public int CategoryId { get; protected set; }
    public Category? Category { get; }

    public Product()
    {
    }

    public Product(int id, string name, string description, List<string> imagesUrl, int stock, int categoryId)
    {
        Id = id;
        Name = name;
        Description = description;
        ImagesUrl = imagesUrl;
        Stock = stock;
        CategoryId = categoryId;
    }

    public void SetId(int id) => Id = id;
    public void SetStock(int stock) => Stock = stock;
    public void SetCategoryId(int categoryId) => CategoryId = categoryId;
}