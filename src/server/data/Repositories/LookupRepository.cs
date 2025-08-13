using Bistre.Data.Contracts;
using Bistre.Data.Contracts.Base;
using Bistre.Data.Repositories.Base;
using Bistre.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bistre.Data.Repositories;

public class LookupRepository(DbContext context) : BaseRepository<LookupEntity>(context), IBaseRepository<LookupEntity>
{
    public sealed override Task InsertAsync(LookupEntity model, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.InsertAsync(model, requesterId, onFailureAsync);
    }

    public sealed override Task InsertRangeAsync(IEnumerable<LookupEntity> models, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.InsertRangeAsync(models, requesterId, onFailureAsync);
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

    public sealed override Task UpdateRangeAsync(IEnumerable<LookupEntity> models, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        return base.UpdateRangeAsync(models, requesterId, onFailureAsync);
    }

    public sealed override Task DeleteAsync<TId>(TId id, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null, CancellationToken? cancellationToken = null)
    {
        return base.DeleteAsync(id, requesterId, onFailureAsync, cancellationToken);
    }

    public sealed override Task DeleteRangeAsync<TId>(IEnumerable<TId> ids, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null, CancellationToken? cancellationToken = null)
    {
        return base.DeleteRangeAsync(ids, requesterId, onFailureAsync, cancellationToken);
    }
}

