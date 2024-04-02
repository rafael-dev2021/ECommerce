using Domain.Entities.Products.Fashion.T_Shirts;
using MediatR;

namespace Application.CQRS.Queries.Products.Fashion.T_Shirts;

public class GetByIdShirtQuery(int id) : IRequest<Shirt>
{
    public int Id { get; set; } = id;
}