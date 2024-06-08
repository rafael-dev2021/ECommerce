using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components;

public class CategoryWithProductCountList(ICategoryDtoService categoryDtoService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categoriesWithProductCount = await
            categoryDtoService.GetCategoriesWithProductDtoCountAsync();
            
        return View(categoriesWithProductCount);
    }
}