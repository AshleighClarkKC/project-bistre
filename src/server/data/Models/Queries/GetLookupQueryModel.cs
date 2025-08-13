using Bistre.Data.Models.Results.Base;
using LiteBus.Queries.Abstractions;

namespace Bistre.Data.Models.Queries;

public class GetLookupQueryModel : IQuery<BaseQueryResult<LookupModel>>
{
    public int Id { get; set; }
}