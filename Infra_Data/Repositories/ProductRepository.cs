using Domain.Entities;
using Domain.Interfaces;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories;

public class ProductRepository(AppDbContext appDbContext) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await appDbContext.Products
            .AsNoTracking()
            .Include(review => review.Reviews)
            .Include(category => category.Category)
            .ToListAsync();
    }
    public async Task<Product> GetByIdAsync(int? id)
    {
        return await appDbContext.Products
           .Include(review => review.Reviews)
           .Include(category => category.Category)
           .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProductsFavoritesAsync()
    {
        var products = await GetProductsAsync();

        return products
            .Where(item => item.FlagsObjectValue is { IsFavorite: true })
            .OrderBy(x => x.Id)
            .ToList();
    }
    public async Task<IEnumerable<Product>> GetProductsDailyOffersAsync()
    {
        var products = await GetProductsAsync();

        return products
            .Where(item => item.FlagsObjectValue is { IsDailyOffer: true })
            .OrderBy(x => x.Id)
            .ThenBy(x => x.Name)
            .ToList();
    }
    public async Task<IEnumerable<Product>> GetProductsBestSellersAsync()
    {
        var products = await GetProductsAsync();

        return products
            .Where(item => item.FlagsObjectValue is { IsBestSeller: true })
            .OrderBy(x => x.Id)
            .ThenBy(x => x.Name)
            .ToList();
    }
    public async Task<IEnumerable<Product>> GetProductsByCategoriesAsync(string categoryStr)
    {
        return await (appDbContext.Products ?? throw new InvalidOperationException())
             .AsNoTracking()
             .Where(category => category.Category != null && category.Category.Name.Equals(categoryStr))
             .Include(review => review.Reviews)
             .Include(category => category.Category)
             .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetSearchProductAsync(string keyword)
    {
        var products = await appDbContext.Products
            .AsNoTracking()
            .Include(product => product.SpecificationObjectValue)
            .Include(x => x.Category)
            .ToListAsync();

        var filteredProducts = products
            .Where(x =>
                x.Category != null && (x.Name.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                                       x.Category.Name.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                                       x.SpecificationObjectValue != null && (
                                           x.SpecificationObjectValue.Brand.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                                           x.SpecificationObjectValue.Model.Contains(keyword, StringComparison.CurrentCultureIgnoreCase))))
            .OrderBy(x => x.Id)
            .ThenBy(x => x.Name)
            .ToList();

        return filteredProducts;
    }
}