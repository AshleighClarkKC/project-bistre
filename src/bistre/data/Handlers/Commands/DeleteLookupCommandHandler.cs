using Bistre.Data.Repositories;
using Bistre.Data.Models.Results.Base;
using LiteBus.Commands.Abstractions;
using System.Net;
using Bistre.Data.Contracts.Base;
using Bistre.Data.Entities;
using Bistre.Data.Models.Commands.Lookup;

namespace Bistre.Data.Handlers.Commands;

public class DeleteLookupCommandHandler(IBaseRepository<LookupEntity> repository) : ICommandHandler<DeleteLookupCommandModel, BaseCommandResult>
{
    private readonly IBaseRepository<LookupEntity> _repository = repository;

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