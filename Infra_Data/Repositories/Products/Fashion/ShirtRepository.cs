using Domain.Entities.Products.Fashion.T_Shirts;
using Domain.Interfaces.Products.Fashion;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.Products.Fashion;

public class ShirtRepository(AppDbContext appDbContext) : IShirtRepository
{
    public async Task<IEnumerable<Shirt>> GetEntitiesAsync()
    {
        return await appDbContext.Shirts
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Reviews)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Shirt> GetByIdAsync(int? id) =>
        await appDbContext.Shirts.FindAsync(id);

    public async Task<Shirt> CreateAsync(Shirt entity)
    {
        await appDbContext.AddAsync(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Shirt> UpdateAsync(Shirt entity)
    {
        appDbContext.Update(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Shirt> DeleteAsync(Shirt entity)
    {
        appDbContext.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }
}