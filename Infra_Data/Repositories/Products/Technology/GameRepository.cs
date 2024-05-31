using Domain.Entities.Products.Technology.Games;
using Domain.Interfaces.Products.Technology;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.Products.Technology;

public class GameRepository(AppDbContext appDbContext) : IGameRepository
{
    public async Task<IEnumerable<Game>> GetEntitiesAsync()
    {
        return await appDbContext.Games
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Reviews)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Game> GetByIdAsync(int? id) =>
        await appDbContext.Games.FindAsync(id);
    
    public async Task<Game> CreateAsync(Game entity)
    {
        await appDbContext.AddAsync(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Game> UpdateAsync(Game entity)
    {
        appDbContext.Update(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Game> DeleteAsync(Game entity)
    {
        appDbContext.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }
}