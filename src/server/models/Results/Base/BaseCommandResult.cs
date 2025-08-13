namespace Bistre.Models.Results.Base;

public class BaseCommandResult
{
    public bool Success { get; set; }

    public int Status { get; set; }

    public string Message { get; set; } = string.Empty;

}
