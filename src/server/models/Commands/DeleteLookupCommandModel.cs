using Bistre.Models.Results.Base;
using LiteBus.Commands.Abstractions;

namespace Bistre.Models.Commands;

public class DeleteLookupCommandModel : ICommand<BaseCommandResult>
{
    public int Id { get; set; }
}