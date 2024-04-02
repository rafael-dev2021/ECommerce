using Domain.Entities;
using MediatR;

namespace Application.CQRS.Queries;

public class ProductsFavoritesQueries : IRequest<IEnumerable<Product>>
{
    
}