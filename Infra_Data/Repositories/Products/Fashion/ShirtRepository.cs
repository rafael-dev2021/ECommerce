using Domain.Entities.Products.Fashion.T_Shirts;
using Domain.Interfaces.Products.Fashion;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.Products.Fashion;

public class ShirtRepository(AppDbContext appDbContext) : IShirtRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<IEnumerable<Shirt>> GetEntitiesAsync()
    {
        return await _appDbContext.Shirts
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Reviews)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Shirt> GetByIdAsync(int? id) =>
        await _appDbContext.Shirts.FindAsync(id);

    public async Task<Shirt> CreateAsync(Shirt entity)
    {
        _appDbContext.Add(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Shirt> UpdateAsync(Shirt entity)
    {
        _appDbContext.Update(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Shirt> DeleteAsync(Shirt entity)
    {
        _appDbContext.Remove(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }
}