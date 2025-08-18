using Bistre.Data.Contexts;
using Bistre.Data.Contracts.Base;
using Bistre.Data.Entities;
using Bistre.Data.Repositories.Base;

namespace Bistre.Data.Repositories;

public class ItemMasterRepository(DefaultContext context) : BaseRepository<ItemMasterSummaryEntity>(context), IBaseRepository<ItemMasterSummaryEntity> 
{
    public sealed async override Task InsertAsync(ItemMasterSummaryEntity model, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        await base.InsertAsync(model, requesterId, onFailureAsync);
    }

    public sealed async override Task<ItemMasterSummaryEntity?> GetByIdAsync<TId>(TId id, Func<Exception, Task>? onFailureAsync = null)
    {
        return await base.GetByIdAsync(id, onFailureAsync);
    }

    public sealed async override Task<IQueryable<ItemMasterSummaryEntity>?> ListAsync(int limit, Func<Exception, Task>? onFailureAsync = null)
    {
        return await base.ListAsync(limit, onFailureAsync);
    }

    public sealed async override Task UpdateAsync(ItemMasterSummaryEntity model, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        await base.UpdateAsync(model, requesterId, onFailureAsync);
    }

    public sealed async override Task DeleteAsync<TId>(TId id, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        await base.DeleteAsync(id, requesterId, onFailureAsync);
    }
}