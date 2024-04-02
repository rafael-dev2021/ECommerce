using Domain.Entities.Products.Fashion.Shoes;
using MediatR;

namespace Application.CQRS.Queries.Products.Fashion.Shoes;

public class ShoesQueries : IRequest<IEnumerable<Shoe>>
{ }
