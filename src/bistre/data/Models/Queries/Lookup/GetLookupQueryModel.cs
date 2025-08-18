using Bistre.Data.Models.Results.Base;
using LiteBus.Queries.Abstractions;

namespace Bistre.Data.Models.Queries.Lookup;

public class GetLookupQueryModel : IQuery<BaseQueryResult<LookupModel>>
{
    public int Id { get; set; }
}