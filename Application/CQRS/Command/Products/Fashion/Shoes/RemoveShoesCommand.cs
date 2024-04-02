using Domain.Entities.Products.Fashion.Shoes;
using MediatR;

namespace Application.CQRS.Command.Products.Fashion.Shoes;

public class RemoveShoesCommand(int id) : IRequest<Shoe>
{
    public int Id { get; set; } = id;
}
