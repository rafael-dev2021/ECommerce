﻿using Domain.Entities.Products.Technology.Smartphones;
using Domain.Interfaces.Products.Technology;
using Infra_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra_Data.Repositories.Products.Technology;

public class SmartphoneRepository(AppDbContext appDbContext) : ISmartphoneRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<IEnumerable<Smartphone>> GetEntitiesAsync()
    {
        return await _appDbContext.Smartphones
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.Reviews)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Smartphone> GetByIdAsync(int? id) =>
        await _appDbContext.Smartphones.FindAsync(id);

    public async Task<Smartphone> CreateAsync(Smartphone entity)
    {
        _appDbContext.Add(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }
    public async Task<Smartphone> UpdateAsync(Smartphone entity)
    {
        _appDbContext.Update(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }


    public async Task<Smartphone> DeleteAsync(Smartphone entity)
    {
        _appDbContext.Remove(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }
}