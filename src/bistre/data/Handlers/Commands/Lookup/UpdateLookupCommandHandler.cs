using Bistre.Data.Entities;
using Bistre.Data.Models.Results.Base;
using LiteBus.Commands.Abstractions;
using System.Net;
using Bistre.Data.Contracts.Base;
using Bistre.Data.Models.Commands.Lookup;

namespace Bistre.Data.Handlers.Commands.Lookup;

public class UpdateLookupCommandHandler(IBaseRepository<LookupEntity> repository) : ICommandHandler<UpdateLookupCommandModel, BaseCommandResult>
{
    private readonly IBaseRepository<LookupEntity> _repository = repository;

    public async Task<BaseCommandResult> HandleAsync(UpdateLookupCommandModel message, CancellationToken cancellationToken = default)
    {
        BaseCommandResult result = new ();

        try
        {
            var entity = message.ToEntity<LookupEntity>();
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