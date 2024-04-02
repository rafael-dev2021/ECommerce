using Domain.Entities;
using MediatR;

namespace Application.CQRS.Queries;

public class SearchProductQueries(string keyword): IRequest<IEnumerable<Product>>
{
    public string Keyword { get; set; } = keyword;
}