using Bistre.Data.Models.Results.Base;
using LiteBus.Queries.Abstractions;

namespace Bistre.Data.Models.Queries.ItemMasterSummary;

public class ListItemMasterSummaryQueryModel : IQuery<BaseQueryResult<IQueryable<ItemMasterSummaryModel>>>
{
    public int Limit { get; set; }
}