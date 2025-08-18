using Bistre.Data.Entities;
using Bistre.Data.Models.Results.Base;
using LiteBus.Commands.Abstractions;
using System.Net;
using Bistre.Data.Contracts.Base;
using Bistre.Data.Models.Commands.Lookup;

namespace Bistre.Data.Handlers.Commands.Lookup;

public class CreateLookupCommandHandler(IBaseRepository<LookupEntity> repository) : ICommandHandler<CreateLookupCommandModel, BaseCommandResult>
{
    private readonly IBaseRepository<LookupEntity> _repository = repository;

    public async Task<BaseCommandResult> HandleAsync(CreateLookupCommandModel message, CancellationToken cancellationToken = default)
    {
        BaseCommandResult result = new ();

        try
        {
            var entity = message.ToEntity<LookupEntity>();
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

