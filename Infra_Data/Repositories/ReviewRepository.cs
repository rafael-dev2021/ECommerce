using Domain.Entities.Reviews;
using Domain.Interfaces;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories;

public class ReviewRepository(AppDbContext appDbContext) : IReviewRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;


    public async Task<IEnumerable<Review>> GetEntitiesAsync()
    {
        return await _appDbContext.Reviews
            .AsNoTracking()
            .Include(x => x.Product)
            .ToListAsync();
    }

    public async Task<Review> GetByIdAsync(int? id)
    {
        return await _appDbContext.Reviews
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Review> CreateAsync(Review entity)
    {
        _appDbContext.Add(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Review> UpdateAsync(Review entity)
    {
        _appDbContext.Update(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Review> DeleteAsync(Review entity)
    {
        _appDbContext.Remove(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }
}