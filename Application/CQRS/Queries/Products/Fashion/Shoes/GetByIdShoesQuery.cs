using Domain.Entities.Products.Fashion.Shoes;
using MediatR;

namespace Application.CQRS.Queries.Products.Fashion.Shoes;

public class GetByIdShoesQuery(int id) : IRequest<Shoe>
{
    public int Id { get; set; } = id;
}
