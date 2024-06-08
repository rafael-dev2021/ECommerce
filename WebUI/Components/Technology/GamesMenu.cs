using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components.Technology;

public class GamesMenu(IProductDtoService productDtoService, ICategoryDtoService categoryDtoService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await categoryDtoService.GetEntitiesAsync();
        var gamesCategory = categories.FirstOrDefault(c => c.Name == "Games");

        if (gamesCategory == null) return View(Enumerable.Empty<ProductDto>());

        var gamesProducts = (await productDtoService.GetProductsDtoAsync())
            .Where(p => p.CategoryId == gamesCategory.Id)
            .ToList();

        return View(gamesProducts);
    }
}