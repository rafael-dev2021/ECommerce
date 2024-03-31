using Domain.Entities;

namespace Domain.Interfaces;

public interface ICategoryRepository : IGenericCRUDRepository<Category>
{
    Task<List<CategoryWithProductCount>> GetCategoriesWithProductCountAsync();
}