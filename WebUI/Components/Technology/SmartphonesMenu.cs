using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components.Technology;

public class SmartphonesMenu(IProductDtoService productDtoService, ICategoryDtoService categoryDtoService)
    : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await categoryDtoService.GetEntitiesAsync();
        var smartphonesCategory = categories.FirstOrDefault(c => c.Name == "Smartphones");

        if (smartphonesCategory == null) return View(Enumerable.Empty<ProductDto>());

        var smartphonesProducts = (await productDtoService.GetProductsDtoAsync())
            .Where(p => p.CategoryId == smartphonesCategory.Id)
            .ToList();

        return View(smartphonesProducts);
    }
}