using Bistre.Data.Contexts;
using Bistre.Data.Contracts.Base;
using Bistre.Data.Repositories.Base;
using Bistre.Data.Entities;

namespace Bistre.Data.Repositories;

public class LookupRepository(DefaultContext context) : BaseRepository<LookupEntity>(context), IBaseRepository<LookupEntity>
{
    public sealed async override Task InsertAsync(LookupEntity model, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        await base.InsertAsync(model, requesterId, onFailureAsync);
    }

    public sealed async override Task<LookupEntity?> GetByIdAsync<TId>(TId id, Func<Exception, Task>? onFailureAsync = null)
    {
        return await base.GetByIdAsync(id, onFailureAsync);
    }

    public sealed async override Task<IQueryable<LookupEntity>?> ListAsync(int limit, Func<Exception, Task>? onFailureAsync = null)
    {
        return await base.ListAsync(limit, onFailureAsync);
    }

    public sealed async override Task UpdateAsync(LookupEntity model, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        await base.UpdateAsync(model, requesterId, onFailureAsync);
    }

    public sealed async override Task DeleteAsync<TId>(TId id, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        await base.DeleteAsync(id, requesterId, onFailureAsync);
    }
}

