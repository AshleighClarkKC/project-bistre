using Bistre.Data.Models.Base;
using Bistre.Data.Models.Results.Base;
using LiteBus.Commands.Abstractions;

namespace Bistre.Data.Models.Commands.ItemMasterSummary;

public class CreateItemMasterSummaryCommandModel : BaseModel, ICommand<BaseCommandResult>
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