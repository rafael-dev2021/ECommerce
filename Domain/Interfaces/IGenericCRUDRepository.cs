namespace Domain.Interfaces;

public interface IGenericCRUDRepository<T> where T : class
{
    Task<IEnumerable<T>> GetEntitiesAsync();
    Task<T> GetByIdAsync(int? id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}