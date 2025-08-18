using Bistre.Data.Models.Results.Base;
using LiteBus.Queries.Abstractions;

namespace Bistre.Data.Models.Queries.ItemMasterSummary;

public class GetItemMasterSummaryQueryModel : IQuery<BaseQueryResult<ItemMasterSummaryModel>>
{
    public int Id { get; set; }
}