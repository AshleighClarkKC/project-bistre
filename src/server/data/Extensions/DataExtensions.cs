using Bistre.Entities.Base;
using Bistre.Data.Models.Base;
using System.Reflection;

namespace Bistre.Data.Extensions;

public static class DataExtensions
{
    /// <summary>
    /// Assists with conversion from the <see cref="BaseModel"/> to a <see cref="BaseEntity"/> to streamline persistence.
    /// </summary>
    /// <typeparam name="TEntity">The type parameter to assert against an Entity type.</typeparam>
    /// <param name="model">The instance of data, to be converted to an Entity.</param>
    /// <returns>Returns a hydrated Entity instance.</returns>
    public static TEntity ToEntity<TModel, TEntity>(this TModel model)
    where TModel : BaseModel
    where TEntity : BaseEntity
    {
        TEntity instance = Activator.CreateInstance<TEntity>();

        var sourceProps = typeof(TModel)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var targetProps = typeof(TEntity)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .ToDictionary(d => d.Name);

        foreach (var sp in sourceProps)
        {
            if (!targetProps.TryGetValue(sp.Name, out var tp)) 
            { continue; }

            if (!tp.CanWrite || !sp.CanRead) 
            { continue; }

            if (tp.PropertyType.IsAssignableFrom(sp.PropertyType))
            {
                var value = sp.GetValue(model);
                tp.SetValue(instance, value);
            }
        }

        return instance;
    }

    /// <summary>
    /// Assists with conversion from types derived from a <see cref="BaseEntity"/> to a model derived from <see cref="BaseModel"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type parameter to assert against an Entity type.</typeparam>
    /// <param name="entity">The Entity instance to convert to a model.</param>
    /// <returns>Returns a hydrated model instance.</returns>
    public static TModel ToModel<TEntity, TModel>(this TEntity entity) 
    where TEntity : BaseEntity
    where TModel : BaseModel
    {
        TModel instance = Activator.CreateInstance<TModel>();

        var sourceProps = typeof(TModel)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var targetProps = typeof(TEntity)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .ToDictionary(d => d.Name);

        foreach (var sp in sourceProps)
        {
            if (!targetProps.TryGetValue(sp.Name, out var tp))
            { continue; }

            if (!tp.CanWrite || !sp.CanRead)
            { continue; }

            if (tp.PropertyType.IsAssignableFrom(sp.PropertyType))
            {
                var value = sp.GetValue(entity);
                tp.SetValue(instance, value);
            }
        }

        return instance;
    }
}