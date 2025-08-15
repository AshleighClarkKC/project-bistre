using Bistre.Data.Models.Base;
using Bistre.Data.Models.Results.Base;
using LiteBus.Commands.Abstractions;

namespace Bistre.Data.Models.Commands;

public class UpdateLookupCommandModel : BaseModel, ICommand<BaseCommandResult>
{
    public int? LookupTypeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}