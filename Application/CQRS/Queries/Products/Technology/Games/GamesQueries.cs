using Domain.Entities.Products.Technology.Games;
using MediatR;

namespace Application.CQRS.Queries.Products.Technology.Games;

public class GamesQueries : IRequest<IEnumerable<Game>>
{
}