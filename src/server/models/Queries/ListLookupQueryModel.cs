using Bistre.Models.Results.Base;
using LiteBus.Queries.Abstractions;

namespace Bistre.Models.Queries;

public class ListLookupQueryModel : IQuery<BaseQueryResult<IReadOnlyList<LookupModel>>>
{
    public int Limit { get; set; }
}