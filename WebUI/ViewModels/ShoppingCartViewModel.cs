using Application.Dtos;
using Application.Dtos.CartDto;

namespace WebUI.ViewModels;

public class ShoppingCartViewModel
{
    public IEnumerable<ProductDto> ProductDtos { get; set; } = [];
    public IEnumerable<ShoppingCartItemDto> ShoppingCartItemsDto { get; set; } = [];
    public IEnumerable<CategoryDto> CategoriesDto { get; set; } = [];
    public int GetCartTotalItems { get; set; }
    public decimal GetTotalAmount { get; set; }
}