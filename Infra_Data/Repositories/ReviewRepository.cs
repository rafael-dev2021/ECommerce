using Domain.Entities.Reviews;
using Domain.Interfaces;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories;

public class ReviewRepository(AppDbContext appDbContext) : IReviewRepository
{
    public async Task<IEnumerable<Review>> GetEntitiesAsync()
    {
        return await appDbContext.Reviews
            .AsNoTracking()
            .Include(x => x.Product)
            .ToListAsync();
    }

    public async Task<Review> GetByIdAsync(int? id)
    {
        return await appDbContext.Reviews
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Review> CreateAsync(Review entity)
    {
        await appDbContext.AddAsync(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Review> UpdateAsync(Review entity)
    {
        appDbContext.Update(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Review> DeleteAsync(Review entity)
    {
        appDbContext.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return entity;
    }
}