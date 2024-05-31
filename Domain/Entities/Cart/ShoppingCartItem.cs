namespace Domain.Entities.Cart;

public class ShoppingCartItem
{
    public int Id { get;  set; }
    public int ProductId { get;  set; }
    public Product? Product { get; set; }
    public int CategoryId { get; private set; }
    public Category? Category { get; set; }
    public int Quantity { get;  set; }
    public string ShoppingCartId { get;  set; } = string.Empty;
    public string UserId { get;  set; } = string.Empty;

    public void SetId(int id) => Id = id;
    public void SetProductId(int productId) => ProductId = productId;
    public void SetCategoryId(int categoryId) => CategoryId = categoryId;
    public void SetQuantity(int quantity) => Quantity = quantity;
    public void SetShoppingCartId(string shoppingCartId) => ShoppingCartId = shoppingCartId;
    public void SetUserId(string userId) => UserId = userId;
}