using Domain.Entities;
using Domain.Entities.Reviews;

namespace Domain.Interfaces;

public interface IReviewRepository : IGenericCRUDRepository<Review>
{
    Task<IEnumerable<Product>> GetProductsByReviewsAsync(string reviewStr);
    Task<IEnumerable<Review>> GetSearchReviewAsync(string keyword);
}