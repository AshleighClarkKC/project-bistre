using Bistre.Data.Models.Base;

namespace Bistre.Data.Models;

public class LookupModel : BaseModel
{
    public int? LookupTypeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}