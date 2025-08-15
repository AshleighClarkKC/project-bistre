using Bistre.Data.Models.Base;
using System.Reflection;

namespace Bistre.Data.Entities.Base;

public class BaseEntity
{
    public int Id { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;

    public Guid CreatedBy { get; set; } = Guid.Empty;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    /// <summary>
    /// Assists with conversion from types derived from a <see cref="BaseEntity"/> to a model derived from <see cref="BaseModel"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type parameter to assert against an Entity type.</typeparam>
    /// <returns>Returns a hydrated model instance.</returns>
    internal TModel ToModel<TModel>() where TModel : BaseModel
    {
        var entityInstance = this;
        var modelInstance = Activator.CreateInstance<TModel>();

        var sourceProps = entityInstance.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var targetProps = modelInstance.GetType()
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
                var value = sp.GetValue(entityInstance);
                tp.SetValue(modelInstance, value);
            }
        }

        return modelInstance;
    }
}