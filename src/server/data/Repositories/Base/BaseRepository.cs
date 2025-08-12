using Bistre.Data.Contracts.Base;
using Bistre.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Bistre.Data.Repositories.Base;

public class BaseRepository<TEntity>(DbContext context) : IBaseRepository<TEntity>
where TEntity : BaseEntity
{
    private readonly DbContext _context = context;

    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    /// <summary>
    /// Insertion of a Single Entity.
    /// </summary>
    /// <param name="model">The item to be persisted.</param>
    /// <param name="requesterId">The unique ID of the user, requesting this action.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    public virtual async Task InsertAsync(TEntity model, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        await using var _transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            model.CreatedDate = DateTime.Now;
            if (requesterId != null)
            {
                model.CreatedBy = requesterId.Value;
            }

            await _dbSet.AddAsync(model);

            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }
            await _transaction.RollbackAsync();
        }
    }

    /// <summary>
    /// Insertion of a Collection of Entities.
    /// </summary>
    /// <param name="models">A collection of the items to be persisted.</param>
    /// <param name="requesterId">The unique ID of the user, requesting this action.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    public virtual async Task InsertRange(IEnumerable<TEntity> models, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        await using var _transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            foreach (var model in models)
            {
                model.CreatedDate = DateTime.Now;
                if (requesterId != null)
                {
                    model.CreatedBy = requesterId.Value;
                }
            }

            await _dbSet.AddRangeAsync(models);

            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }
            await _transaction.RollbackAsync();
        }
    }

    /// <summary>
    /// Retrieves a Single Item.
    /// </summary>
    /// <typeparam name="TId">The data type of the ID that the item is represented by, in the database.</typeparam>
    /// <param name="id">The identifier value of the item in the database.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    public virtual async Task<TEntity?> GetByIdAsync<TId>(TId id, Func<Exception, Task>? onFailureAsync = null) where TId : struct
    {
        TEntity? value = null;

        try
        {
            value = await _dbSet.FindAsync(id);
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }

        }

        return value;
    }

    /// <summary>
    /// Retrieves a List of Items.
    /// </summary>
    /// <param name="limit">A numeric value to control how many values are to be returned.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    public virtual async Task<IQueryable<TEntity>?> ListAsync(int limit, Func<Exception, Task>? onFailureAsync = null)
    {
        try
        {
            return (
                await _context.Set<TEntity>()
                .ToListAsync()
                )
            .AsQueryable()
            .Take(limit);
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }
            return null;
        }
    }

    /// <summary>
    /// Updates a single entry.
    /// </summary>
    /// <param name="model">The mutator object.</param>
    /// <param name="requesterId">The unique ID of the user, requesting this action.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    public virtual async Task UpdateAsync(TEntity model, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        await using var _transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            model.ModifiedDate = DateTime.Now;
            if (requesterId != null)
            {
                model.ModifiedBy = requesterId;
            }

            _dbSet.Update(model);

            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }
            await _transaction.RollbackAsync();
        }

    }

    /// <summary>
    /// Updates a range of entries.
    /// </summary>
    /// <param name="models">A collection of mutator objects.</param>
    /// <param name="requesterId">The unique ID of the user, requesting this action.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> models, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null)
    {
        await using var _transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            foreach (var model in models)
            {
                model.ModifiedDate = DateTime.Now;
                if (requesterId != null)
                {
                    model.ModifiedBy = requesterId;
                }
            }

            _dbSet.UpdateRange(models);

            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }
            await _transaction.RollbackAsync();
        }
    }

    /// <summary>
    /// Marks a single item as deleted, to prevent user access and/or mutation.
    /// </summary>
    /// <typeparam name="TId">The data type of the ID that the item is represented by, in the database.</typeparam>
    /// <param name="id"></param>
    /// <param name="requesterId">The unique ID of the user, requesting this action.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    public virtual async Task DeleteAsync<TId>(TId id, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null) where TId : struct
    {
        await using var _transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var item = await _dbSet.FindAsync(id);

            if (item != null)
            {
                item.IsActive = false;
                item.IsDeleted = true;
                item.DeletedDate = DateTime.Now;
                if (requesterId != null)
                {
                    item.DeletedBy = requesterId;
                }

                _dbSet.Update(item);

                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }
            await _transaction.RollbackAsync();
        }
    }

    /// <summary>
    /// Marks a collection of items as deleted, to prevent user access and/or mutation.
    /// </summary>
    /// <typeparam name="TId">The data type of the ID that the item is represented by, in the database.</typeparam>
    /// <param name="id">The identifier value of the item in the database.</param>
    /// <param name="requesterId">The unique ID of the user, requesting this action.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    public virtual async Task DeleteRangeAsync<TId>(IEnumerable<TId> ids, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null) where TId : struct
    {
        await using var _transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            foreach (var id in ids)
            {
                var item = await _dbSet.FindAsync(id);

                if (item != null)
                {
                    item.IsActive = false;
                    item.IsDeleted = true;
                    item.DeletedDate = DateTime.Now;
                    if (requesterId != null)
                    {
                        item.DeletedBy = requesterId;
                    }

                    _dbSet.Update(item);
                }
            }

            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            if (onFailureAsync != null)
            {
                await onFailureAsync(ex);
            }
            await _transaction.RollbackAsync();
        }
    }
}