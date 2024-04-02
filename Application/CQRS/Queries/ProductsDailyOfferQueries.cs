using Domain.Entities;
using MediatR;

namespace Application.CQRS.Queries;

public class ProductsDailyOfferQueries: IRequest<IEnumerable<Product>>
{
    
}