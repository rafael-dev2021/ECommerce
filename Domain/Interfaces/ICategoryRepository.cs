using Domain.Entities;

namespace Domain.Interfaces;

public interface ICategoryRepository : IGenericCrudRepository<Category>
{
    Task<List<CategoryWithProductCount>> GetCategoriesWithProductCountAsync();
}