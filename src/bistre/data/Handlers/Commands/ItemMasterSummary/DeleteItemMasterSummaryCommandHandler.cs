using Bistre.Data.Contracts.Base;
using Bistre.Data.Entities;
using Bistre.Data.Models.Commands.ItemMasterSummary;
using Bistre.Data.Models.Results.Base;
using LiteBus.Commands.Abstractions;
using System.Net;

namespace Bistre.Data.Handlers.Commands.ItemMasterSummary;

public class DeleteItemMasterSummaryCommandHandler(IBaseRepository<ItemMasterSummaryEntity> repository) : ICommandHandler<DeleteItemMasterSummaryCommandModel, BaseCommandResult>
{
    private readonly IBaseRepository<ItemMasterSummaryEntity> _repository = repository;

    public async Task<BaseCommandResult> HandleAsync(DeleteItemMasterSummaryCommandModel message, CancellationToken cancellationToken = default)
    {
        BaseCommandResult result = new();

        try
        {
            await _repository.DeleteAsync(message.Id);

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