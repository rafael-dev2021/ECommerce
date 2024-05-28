namespace Application.Interfaces.Products;

public interface IGenericProductsCrudService<T> where T : class
{
    Task<IEnumerable<T>> GetEntitiesDtoAsync();
    Task<T> GetByIdAsync(int? id);
    Task AddAsync(T entityDto);
    Task UpdateAsync(T entityDto);
    Task DeleteAsync(int? id);
}