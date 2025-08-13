using Bistre.Models.Base;
using Bistre.Models.Results.Base;
using LiteBus.Commands.Abstractions;

namespace Bistre.Models.Commands;

public class UpdateLookupCommandModel : BaseModel, ICommand<BaseCommandResult>
{
    public int? LookupTypeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}