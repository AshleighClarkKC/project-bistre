using Bistre.Data.Contracts.Base;
using Bistre.Data.Entities;
using Bistre.Data.Models;
using Bistre.Data.Models.Queries.ItemMasterSummary;
using Bistre.Data.Models.Results.Base;
using LiteBus.Queries.Abstractions;
using System.Net;

namespace Bistre.Data.Handlers.Queries.ItemMasterSummary;

public class GetItemMasterSummaryQueryHandler(IBaseRepository<ItemMasterSummaryEntity> repository) : IQueryHandler<GetItemMasterSummaryQueryModel, BaseQueryResult<ItemMasterSummaryModel>>
{
    private readonly IBaseRepository<ItemMasterSummaryEntity> _repository = repository;

    public async Task<BaseQueryResult<ItemMasterSummaryModel>> HandleAsync(GetItemMasterSummaryQueryModel message, CancellationToken cancellationToken = default)
    {
        BaseQueryResult<ItemMasterSummaryModel> result = new ();

        try
        {
            var data = await _repository.GetByIdAsync(message.Id);

            result.Success = data != null;
            result.Status = data != null ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound;

            result.Data = data?.ToModel<ItemMasterSummaryModel>() ?? null;
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