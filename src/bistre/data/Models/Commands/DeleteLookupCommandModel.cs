using Bistre.Data.Models.Results.Base;
using LiteBus.Commands.Abstractions;

namespace Bistre.Data.Models.Commands;

public class DeleteLookupCommandModel : ICommand<BaseCommandResult>
{
    public int Id { get; set; }
}