using Domain.Entities;
using MediatR;

namespace Application.CQRS.Queries;

public class GetByIdProductQuery(int id) : IRequest<Product>
{
    public int Id { get; set; } = id;
}