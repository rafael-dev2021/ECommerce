namespace Application.Dtos.CartDto;

public record ShoppingCartItemDto(
    int Id,
    int ProductId,
    ProductDto? Product,
    int CategoryId,
    CategoryDto? Category,
    int Quantity) { }
