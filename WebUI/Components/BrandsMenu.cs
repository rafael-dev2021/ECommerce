using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components;

public class BrandsMenu(IProductDtoService productDtoService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var productDtos = await productDtoService.GetProductsDtoAsync();

        var countByBrand = productDtos
            .GroupBy(p => p.SpecificationObjectValue?.Brand)
            .Select(g => new { Brand = g.Key, Count = g.Count() })
            .ToList();

        return View(countByBrand);
    }
}