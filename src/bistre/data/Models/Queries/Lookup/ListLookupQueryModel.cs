using Bistre.Data.Models.Results.Base;
using LiteBus.Queries.Abstractions;

namespace Bistre.Data.Models.Queries.Lookup;

public class ListLookupQueryModel : IQuery<BaseQueryResult<IReadOnlyList<LookupModel>>>
{
    public int Limit { get; set; }
}