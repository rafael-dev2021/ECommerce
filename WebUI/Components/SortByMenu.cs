using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components;

public class SortByMenu(IProductDtoService productDtoService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var productDtos = await productDtoService.GetProductsDtoAsync();

        var uniqueFlags = productDtos
            .Select(p => p.FlagsObjectValue)
            .Distinct()
            .ToList();

        return View(uniqueFlags);
    }
}