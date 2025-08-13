using Bistre.Data.Repositories;
using Bistre.Entities;
using Bistre.Models;
using Bistre.Models.Commands;
using Bistre.Models.Extensions;
using Bistre.Models.Results.Base;
using LiteBus.Commands.Abstractions;
using System.Net;

namespace Bistre.Data.Handlers.Commands;

public class CreateLookupCommandHandler(LookupRepository repository) : ICommandHandler<CreateLookupCommandModel, BaseCommandResult>
{
    private readonly LookupRepository _repository = repository;

    public async Task<BaseCommandResult> HandleAsync(CreateLookupCommandModel message, CancellationToken cancellationToken = default)
    {
        BaseCommandResult result = new ();

        try
        {
            var entity = message.ToEntity<CreateLookupCommandModel, LookupEntity>();
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

