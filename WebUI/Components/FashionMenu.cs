using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components;

public class FashionMenu(
    IProductDtoService productDtoService,
    ICategoryDtoService categoryDtoService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await categoryDtoService.GetEntitiesAsync();
        var fashionCategory = categories.FirstOrDefault(x => x.Name == "Fashion");

        if (fashionCategory == null) return View(Enumerable.Empty<ProductDto>());
        {
            var fashionProducts = (await productDtoService.GetProductsDtoAsync())
                .Where(x => x.CategoryId == fashionCategory.Id)
                .ToList();

            return View(fashionProducts);
        }
    }
}