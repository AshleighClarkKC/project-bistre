using Bistre.Data.Repositories;
using Bistre.Entities;
using Bistre.Models;
using Bistre.Models.Extensions;
using Bistre.Models.Queries;
using Bistre.Models.Results.Base;
using LiteBus.Queries.Abstractions;
using System.Net;

namespace Bistre.Data.Handlers.Queries;

public class GetLookupQueryHandler(LookupRepository repository) : IQueryHandler<GetLookupQueryModel, BaseQueryResult<LookupModel>>
{
    private readonly LookupRepository _repository = repository;

    public async Task<BaseQueryResult<LookupModel>> HandleAsync(GetLookupQueryModel message, CancellationToken cancellationToken = default)
    {
        BaseQueryResult<LookupModel> result = new ();

        try
        {
            var data = await _repository.GetByIdAsync(message.Id);

            result.Success = data != null;
            result.Status = data != null ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound;

            result.Data = data?.ToModel<LookupEntity, LookupModel>();
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

