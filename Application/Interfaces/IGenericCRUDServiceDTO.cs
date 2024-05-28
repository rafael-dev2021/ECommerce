namespace Application.Interfaces;

public interface IGenericCrudServiceDto<T> where T : class
{
    Task<IEnumerable<T>> GetEntitiesAsync();
    Task<T> GetByIdAsync(int? id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int? id);
}
