using Domain.Entities.Products.Fashion.T_Shirts;
using MediatR;

namespace Application.CQRS.Command.Products.Fashion.T_Shirts;

public class RemoveShirtCommand(int id) : IRequest<Shirt>
{
    public int Id { get; set; } = id;
}