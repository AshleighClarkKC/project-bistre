using Bistre.Data.Contracts.Base;
using Bistre.Data.Entities;
using Bistre.Data.Models;
using Bistre.Data.Models.Queries.ItemMasterSummary;
using Bistre.Data.Models.Results.Base;
using LiteBus.Queries.Abstractions;
using System.Net;

namespace Bistre.Data.Handlers.Queries.ItemMasterSummary;

public class ListItemMasterSummaryQueryHandler(IBaseRepository<ItemMasterSummaryEntity> repository) : IQueryHandler<ListItemMasterSummaryQueryModel, BaseQueryResult<IQueryable<ItemMasterSummaryModel>>>
{
    private readonly IBaseRepository<ItemMasterSummaryEntity> _repository = repository;

    public async Task<BaseQueryResult<IQueryable<ItemMasterSummaryModel>>> HandleAsync(ListItemMasterSummaryQueryModel message, CancellationToken cancellationToken = default)
    {
        BaseQueryResult<IQueryable<ItemMasterSummaryModel>> result = new();

        try
        {
            var data = await _repository.ListAsync(message.Limit);

            result.Success = data != null;
            result.Status = data != null ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound;

            List<ItemMasterSummaryModel> lookups = [];

            if (data != null)
            {
                foreach (var item in data)
                {
                    var model = item.ToModel<ItemMasterSummaryModel>();
                    lookups.Add(model);
                }
            }

            result.Data = lookups.AsQueryable();
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Status = (int)HttpStatusCode.BadRequest;
            result.Message = ex.Message;
        }

        return result;
    }
}