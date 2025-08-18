using Bistre.Data.Contracts.Base;
using Bistre.Data.Entities;
using Bistre.Data.Models.Commands.ItemMasterSummary;
using Bistre.Data.Models.Results.Base;
using LiteBus.Commands.Abstractions;
using System.Net;

namespace Bistre.Data.Handlers.Commands.ItemMasterSummary;

public class UpdateItemMasterSummaryCommandHandler(IBaseRepository<ItemMasterSummaryEntity> repository) : ICommandHandler<UpdateItemMasterSummaryCommandModel, BaseCommandResult>
{
    private readonly IBaseRepository<ItemMasterSummaryEntity> _repository = repository;

    public async Task<BaseCommandResult> HandleAsync(UpdateItemMasterSummaryCommandModel message, CancellationToken cancellationToken = default)
    {
        BaseCommandResult result = new();

        try
        {
            var entity = message.ToEntity<ItemMasterSummaryEntity>();
            await _repository.UpdateAsync(entity, message.CreatedBy);

            result.Success = true;
            result.Status = (int)HttpStatusCode.Accepted;

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