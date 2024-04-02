using Domain.Entities.Products.Fashion.T_Shirts;
using MediatR;

namespace Application.CQRS.Queries.Products.Fashion.T_Shirts;

public class ShirtsQueries : IRequest<IEnumerable<Shirt>>
{
}