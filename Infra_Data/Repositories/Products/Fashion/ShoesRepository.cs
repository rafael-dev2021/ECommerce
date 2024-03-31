using Domain.Entities.Products.Fashion.Shoes;
using Domain.Interfaces.Products.Fashion;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.Products.Fashion;

public class ShoesRepository(AppDbContext appDbContext) : IShoesRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<IEnumerable<Shoe>> GetEntitiesAsync()
    {
        return await _appDbContext.Shoes
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Reviews)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Shoe> GetByIdAsync(int? id) =>
        await _appDbContext.Shoes.FindAsync(id);

    public async Task<Shoe> CreateAsync(Shoe entity)
    {
        _appDbContext.Add(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Shoe> UpdateAsync(Shoe entity)
    {
        _appDbContext.Update(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Shoe> DeleteAsync(Shoe entity)
    {
        _appDbContext.Remove(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }
}