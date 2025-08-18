using Bistre.Data.Entities.Base;

namespace Bistre.Data.Entities;

public class ItemMasterSummaryEntity : BaseEntity
{
    public string ItemCode { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Manufacturer { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Variant { get; set; } = string.Empty;

    public string Size { get; set; } = string.Empty;

    public int? Diameter { get; set; }

    public int? Length { get; set; }

    public int? Width { get; set; }

    public int? Height { get; set; }
}

