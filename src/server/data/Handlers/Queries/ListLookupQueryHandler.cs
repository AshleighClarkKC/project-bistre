using Bistre.Data.Repositories;
using Bistre.Entities;
using Bistre.Models;
using Bistre.Models.Extensions;
using Bistre.Models.Queries;
using Bistre.Models.Results.Base;
using LiteBus.Queries.Abstractions;
using System.Net;

namespace Bistre.Data.Handlers.Queries;

public class ListLookupQueryHandler(LookupRepository repository) : IQueryHandler<ListLookupQueryModel, BaseQueryResult<IReadOnlyList<LookupModel>>>
{
    private readonly LookupRepository _repository = repository;

    public async Task<BaseQueryResult<IReadOnlyList<LookupModel>>> HandleAsync(ListLookupQueryModel message, CancellationToken cancellationToken = default)
    {
        BaseQueryResult<IReadOnlyList<LookupModel>> result = new();

        try
        {
            var data = await _repository.ListAsync(message.Limit);

            result.Success = data != null;
            result.Status = data != null ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound;

            List<LookupModel> lookups = [];

            if (data != null) 
            {
                foreach (var item in data)
                {
                    var model = item.ToModel<LookupEntity, LookupModel>();
                    lookups.Add(model);
                }
            }

            result.Data = lookups;
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

