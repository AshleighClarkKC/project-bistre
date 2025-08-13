using Bistre.Data.Repositories;
using Bistre.Entities;
using Bistre.Data.Models;
using Bistre.Data.Extensions;
using Bistre.Data.Models.Queries;
using Bistre.Data.Models.Results.Base;
using LiteBus.Queries.Abstractions;
using System.Net;
using Bistre.Data.Contracts.Base;

namespace Bistre.Data.Handlers.Queries;

public class GetLookupQueryHandler(IBaseRepository<LookupEntity> repository) : IQueryHandler<GetLookupQueryModel, BaseQueryResult<LookupModel>>
{
    private readonly IBaseRepository<LookupEntity> _repository = repository;

    public async Task<BaseQueryResult<LookupModel>> HandleAsync(GetLookupQueryModel message, CancellationToken cancellationToken = default)
    {
        BaseQueryResult<LookupModel> result = new ();

        try
        {
            var data = await _repository.GetByIdAsync(message.Id);

            result.Success = data != null;
            result.Status = data != null ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound;

            result.Data = data?.ToModel<LookupEntity, LookupModel>() ?? null;
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

