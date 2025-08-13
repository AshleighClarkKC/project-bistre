using Bistre.Data.Repositories;
using Bistre.Models.Commands;
using Bistre.Models.Results.Base;
using LiteBus.Commands.Abstractions;
using System.Net;

namespace Bistre.Data.Handlers.Commands;

public class DeleteLookupCommandHandler(LookupRepository repository) : ICommandHandler<DeleteLookupCommandModel, BaseCommandResult>
{
    private readonly LookupRepository _repository = repository;

    public async Task<BaseCommandResult> HandleAsync(DeleteLookupCommandModel message, CancellationToken cancellationToken = default)
    {
        BaseCommandResult result = new ();

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