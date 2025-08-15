using Bistre.Data.Entities.Base;
using System.Reflection;

namespace Bistre.Data.Models.Base;

public class BaseModel
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
    /// Assists with conversion from the <see cref="BaseModel"/> to a <see cref="BaseEntity"/> to streamline persistence.
    /// </summary>
    /// <typeparam name="TEntity">The type parameter to assert against an Entity type.</typeparam>
    /// <returns>Returns a hydrated Entity instance.</returns>
    internal TEntity ToEntity<TEntity>() where TEntity : BaseEntity
    {
        var modelInstance = this;
        var entityInstance = Activator.CreateInstance<TEntity>();

        var sourceProps = modelInstance.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var targetProps = entityInstance.GetType()
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
                var value = sp.GetValue(modelInstance);
                tp.SetValue(entityInstance, value);
            }
        }

        return entityInstance;
    }
}
