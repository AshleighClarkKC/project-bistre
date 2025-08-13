using Bistre.Models.Base;
using Bistre.Models.Results.Base;
using LiteBus.Queries.Abstractions;

namespace Bistre.Models.Queries;

public class GetLookupQueryModel : IQuery<BaseQueryResult<LookupModel>>
{
    public int Id { get; set; }
}

