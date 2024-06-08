using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components;

public class CategoryMenu(ICategoryDtoService categoryDtoService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await categoryDtoService.GetEntitiesAsync();

        return View(categories);
    }
}