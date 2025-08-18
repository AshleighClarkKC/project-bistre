using Latte.Models.Base;

namespace Latte.Models.Lookups;

public class LookupModel : BaseModel
{
    public int? LookupTypeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}