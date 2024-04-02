using Domain.Entities;
using MediatR;

namespace Application.CQRS.Queries;

public class ProductsQueries: IRequest<IEnumerable<Product>>
{
    
}