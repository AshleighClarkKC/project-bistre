using Bistre.Entities.Base;
using Bistre.Models.Base;

namespace Bistre.Models.Extensions;

public static class DataExtensions
{
    /// <summary>
    /// Assists with conversion from the <see cref="BaseModel"/> to a <see cref="BaseEntity"/> to streamline persistence.
    /// </summary>
    /// <typeparam name="TEntity">The type parameter to assert against an Entity type.</typeparam>
    /// <param name="model">The instance of data, to be converted to an Entity.</param>
    /// <param name="mappingExpression">The conversion expression to facilitate the conversion.</param>
    /// <returns>Returns a hydrated Entity instance.</returns>
    public static TEntity MapToEntity<TEntity>(this BaseModel model, Func<BaseModel, TEntity> mappingExpression) 
    where TEntity : BaseEntity
        => mappingExpression(model);

    /// <summary>
    /// Assists with conversion from types derived from a <see cref="BaseEntity"/> to a model derived from <see cref="BaseModel"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type parameter to assert against an Entity type.</typeparam>
    /// <param name="entity">The Entity instance to convert to a model.</param>
    /// <param name="mappingExpression">The conversion expression to facilitate the conversion.</param>
    /// <returns>Returns a hydrated model instance.</returns>
    public static BaseModel MapToModel<TEntity>(this TEntity entity, Func<TEntity, BaseModel> mappingExpression) 
    where TEntity : BaseEntity
        => mappingExpression(entity);
}