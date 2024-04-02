namespace Application.Interfaces.Products;

public interface IGenericCRUDService<T> where T : class
{
    Task<IEnumerable<T>> GetEntitiesDtoAsync();
    Task<T> GetByIdAsync(int? id);
    Task AddAsync(T entityDto);
    Task UpdateAsync(T entityDto);
    Task DeleteAsync(int? id);
}