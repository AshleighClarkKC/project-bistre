using Bistre.Data.Contracts.Base;
using Bistre.Data.Extensions;
using Bistre.Data.Models;
using Bistre.Data.Models.Results.Base;
using Bistre.Data.Repositories;
using Bistre.Data.Entities;
using LiteBus.Queries.Abstractions;
using System.Net;
using Bistre.Data.Models.Queries.Lookup;

namespace Bistre.Data.Handlers.Queries;

public class ListLookupQueryHandler(IBaseRepository<LookupEntity> repository) : IQueryHandler<ListLookupQueryModel, BaseQueryResult<IReadOnlyList<LookupModel>>>
{
    private readonly IBaseRepository<LookupEntity> _repository = repository;

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
                    var model = item.ToModel<LookupModel>();
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

