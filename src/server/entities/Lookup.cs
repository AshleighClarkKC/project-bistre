using Bistre.Entities.Base;

namespace Bistre.Data.Entities;

public class Lookup : BaseEntity
{
    public int? LookupTypeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}