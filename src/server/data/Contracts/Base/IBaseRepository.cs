namespace Bistre.Data.Contracts.Base;

public interface IBaseRepository<TEntity>
{
    // Create

    /// <summary>
    /// Insertion of a Single Entity.
    /// </summary>
    /// <param name="model">The item to be persisted.</param>
    /// <param name="requesterId">The unique ID of the user, requesting this action.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    Task InsertAsync(TEntity model, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null);

    /// <summary>
    /// Insertion of a Collection of Entities.
    /// </summary>
    /// <param name="models">A collection of the items to be persisted.</param>
    /// <param name="requesterId">The unique ID of the user, requesting this action.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    Task InsertRangeAsync(IEnumerable<TEntity> models, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null);

    // Read

    /// <summary>
    /// Retrieves a Single Item.
    /// </summary>
    /// <typeparam name="TId">The data type of the ID that the item is represented by, in the database.</typeparam>
    /// <param name="id">The identifier value of the item in the database.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    Task<TEntity?> GetByIdAsync<TId>(TId id, Func<Exception, Task>? onFailureAsync = null) where TId : struct;

    /// <summary>
    /// Retrieves a List of Items.
    /// </summary>
    /// <param name="limit">A numeric value to control how many values are to be returned.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    Task<IQueryable<TEntity>?> ListAsync(int limit, Func<Exception, Task>? onFailureAsync = null);

    // Update

    /// <summary>
    /// Updates a single entry.
    /// </summary>
    /// <param name="model">The mutator object.</param>
    /// <param name="requesterId">The unique ID of the user, requesting this action.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    Task UpdateAsync(TEntity model, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null);

    /// <summary>
    /// Updates a range of entries.
    /// </summary>
    /// <param name="models">A collection of mutator objects.</param>
    /// <param name="requesterId">The unique ID of the user, requesting this action.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    Task UpdateRangeAsync(IEnumerable<TEntity> models, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null);

    // Delete

    /// <summary>
    /// Marks a single item as deleted, to prevent user access and/or mutation.
    /// </summary>
    /// <typeparam name="TId">The data type of the ID that the item is represented by, in the database.</typeparam>
    /// <param name="id"></param>
    /// <param name="requesterId">The unique ID of the user, requesting this action.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    Task DeleteAsync<TId>(TId id, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null) where TId : struct;

    /// <summary>
    /// Marks a collection of items as deleted, to prevent user access and/or mutation.
    /// </summary>
    /// <typeparam name="TId">The data type of the ID that the item is represented by, in the database.</typeparam>
    /// <param name="id">The identifier value of the item in the database.</param>
    /// <param name="requesterId">The unique ID of the user, requesting this action.</param>
    /// <param name="onFailureAsync">A de-coupled action, to be performed when the persistence has failed.</param>
    Task DeleteRangeAsync<TId>(IEnumerable<TId> ids, Guid? requesterId = null, Func<Exception, Task>? onFailureAsync = null) where TId : struct;
}

