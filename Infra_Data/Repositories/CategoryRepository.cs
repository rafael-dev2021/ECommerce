using Domain.Entities;
using Domain.Interfaces;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories;


public class CategoryRepository(AppDbContext appDbContext)  : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetEntitiesAsync()
    {
        return await appDbContext.Categories
            .AsNoTracking()
            .Include(products => products.Products)
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<List<CategoryWithProductCount>> GetCategoriesWithProductCountAsync()
    {
        var categoriesWithCount = await appDbContext.Categories
            .AsNoTracking()
            .Select(category => new
                CategoryWithProductCount(category.Name, category.Products.Count))
            .ToListAsync();

        return categoriesWithCount;
    }
    
    public async Task<Category> GetByIdAsync(int? id)
    {
        return await appDbContext.Categories
            .Include(products => products.Products)
            .FirstOrDefaultAsync(category => category.Id == id);
    }
    
    public async Task<Category> CreateAsync(Category category)
    {
        await appDbContext.AddAsync(category);
        await appDbContext.SaveChangesAsync();
        return category;
    }
    
    public async Task<Category> UpdateAsync(Category category)
    {
        appDbContext.Update(category);
        await appDbContext.SaveChangesAsync();
        return category;
    }
    
    public async Task<Category> DeleteAsync(Category category)
    {
        appDbContext.Remove(category);
        await appDbContext.SaveChangesAsync();
        return category;
    }
}