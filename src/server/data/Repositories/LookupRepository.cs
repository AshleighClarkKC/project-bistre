using Bistre.Data.Contexts;
using Bistre.Data.Contracts.Base;
using Bistre.Data.Repositories.Base;
using Bistre.Entities;

namespace Bistre.Data.Repositories;

public class LookupRepository(DefaultContext context) : BaseRepository<LookupEntity>(context), IBaseRepository<LookupEntity>
{
    public sealed override Task InsertAsync(LookupEntity model, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.InsertAsync(model, requesterId, onFailureAsync);
    }

    public sealed override Task<LookupEntity?> GetByIdAsync<TId>(TId id, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.GetByIdAsync(id, onFailureAsync);
    }

    public sealed override Task<IQueryable<LookupEntity>?> ListAsync(int limit, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.ListAsync(limit, onFailureAsync);
    }

    public sealed override Task UpdateAsync(LookupEntity model, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.UpdateAsync(model, requesterId, onFailureAsync);
    }

    public sealed override Task DeleteAsync<TId>(TId id, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.DeleteAsync(id, requesterId, onFailureAsync);
    }
}

