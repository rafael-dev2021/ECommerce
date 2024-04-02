using Domain.Entities;
using MediatR;

namespace Application.CQRS.Queries;

public class ProductsBestSellerQueries: IRequest<IEnumerable<Product>>
{
    
}