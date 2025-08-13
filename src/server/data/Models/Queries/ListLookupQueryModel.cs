using Bistre.Data.Models.Results.Base;
using LiteBus.Queries.Abstractions;

namespace Bistre.Data.Models.Queries;

public class ListLookupQueryModel : IQuery<BaseQueryResult<IReadOnlyList<LookupModel>>>
{
    public int Limit { get; set; }
}