using Domain.Entities.Products.Fashion.Shoes;
using Domain.Interfaces.Products.Fashion;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.Products.Fashion;

public class ShoesRepository(AppDbContext appDbContext) : IShoesRepository
{
    public async Task<IEnumerable<Shoe>> GetEntitiesAsync()
    {
        return await appDbContext.Shoes
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Reviews)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Shoe> GetByIdAsync(int? id) =>
        await appDbContext.Shoes.FindAsync(id);

    public async Task<Shoe> CreateAsync(Shoe entity)
    {
        await appDbContext.AddAsync(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Shoe> UpdateAsync(Shoe entity)
    {
        appDbContext.Update(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Shoe> DeleteAsync(Shoe entity)
    {
        appDbContext.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }
}