using Domain.Entities.Products.Technology.Smartphones;
using MediatR;

namespace Application.CQRS.Queries.Products.Technology.Smartphones;

public class SmartphonesQueries : IRequest<IEnumerable<Smartphone>>
{
}