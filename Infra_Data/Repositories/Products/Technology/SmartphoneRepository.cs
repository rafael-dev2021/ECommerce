using Domain.Entities.Products.Technology.Smartphones;
using Domain.Interfaces.Products.Technology;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.Products.Technology;

public class SmartphoneRepository(AppDbContext appDbContext) : ISmartphoneRepository
{
    public async Task<IEnumerable<Smartphone>> GetEntitiesAsync()
    {
        return await appDbContext.Smartphones
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Reviews)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Smartphone> GetByIdAsync(int? id) =>
        await appDbContext.Smartphones.FindAsync(id);

    public async Task<Smartphone> CreateAsync(Smartphone entity)
    {
        await appDbContext.AddAsync(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }
    public async Task<Smartphone> UpdateAsync(Smartphone entity)
    {
        appDbContext.Update(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Smartphone> DeleteAsync(Smartphone entity)
    {
        appDbContext.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }
}