using Bistre.Data.Repositories;
using Bistre.Entities;
using Bistre.Models.Commands;
using Bistre.Models.Extensions;
using Bistre.Models.Results.Base;
using LiteBus.Commands.Abstractions;
using System.Net;

namespace Bistre.Data.Handlers.Commands;

public class UpdateLookupCommandHandler(LookupRepository repository) : ICommandHandler<UpdateLookupCommandModel, BaseCommandResult>
{
    private readonly LookupRepository _repository = repository;

    public async Task<BaseCommandResult> HandleAsync(UpdateLookupCommandModel message, CancellationToken cancellationToken = default)
    {
        BaseCommandResult result = new ();

        try
        {
            var entity = message.ToEntity<UpdateLookupCommandModel, LookupEntity>();
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