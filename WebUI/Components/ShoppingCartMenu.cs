using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Components;

public class ShoppingCartMenu(
    IShoppingCartItemDtoService shoppingCartDtoService,
    IProductDtoService productDtoService,
    ICategoryDtoService categoryDtoService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var cartVw = new ShoppingCartViewModel()
        {
            ShoppingCartItemsDto = await shoppingCartDtoService.GetShoppingCartItemsDtoAsync(),
            CategoriesDto = await categoryDtoService.GetEntitiesAsync(),
            GetCartTotalItems = await shoppingCartDtoService.GetTotalCartItemsServiceAsync(),
            GetTotalAmount = await shoppingCartDtoService.GetTotalAmountCartServiceAsync(),
            ProductDtos = await productDtoService.GetProductsDtoAsync()
        };
        return View(cartVw);
    }
}