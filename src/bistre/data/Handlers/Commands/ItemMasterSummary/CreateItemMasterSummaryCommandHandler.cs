using Bistre.Data.Contracts.Base;
using Bistre.Data.Entities;
using Bistre.Data.Models.Commands.ItemMasterSummary;
using Bistre.Data.Models.Results.Base;
using LiteBus.Commands.Abstractions;
using System.Net;

namespace Bistre.Data.Handlers.Commands.ItemMasterSummary;

public class CreateItemMasterSummaryCommandHandler(IBaseRepository<ItemMasterSummaryEntity> repository) : ICommandHandler<CreateItemMasterSummaryCommandModel, BaseCommandResult>
{
    private readonly IBaseRepository<ItemMasterSummaryEntity> _repository = repository;

    public async Task<BaseCommandResult> HandleAsync(CreateItemMasterSummaryCommandModel message, CancellationToken cancellationToken = default)
    {
        BaseCommandResult result = new();

        try
        {
            var entity = message.ToEntity<ItemMasterSummaryEntity>();
            await _repository.InsertAsync(entity, message.CreatedBy);

            result.Success = true;
            result.Status = (int)HttpStatusCode.Created;
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