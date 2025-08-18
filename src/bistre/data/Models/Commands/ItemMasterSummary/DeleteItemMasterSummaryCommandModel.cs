using Bistre.Data.Models.Results.Base;
using LiteBus.Commands.Abstractions;

namespace Bistre.Data.Models.Commands.ItemMasterSummary;

public class DeleteItemMasterSummaryCommandModel : ICommand<BaseCommandResult>
{
    public int Id { get; set; }
}