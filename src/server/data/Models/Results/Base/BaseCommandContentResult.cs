namespace Bistre.Data.Models.Results.Base;

public class BaseCommandContentResult<TResultContent>
{
    public bool Success { get; set; }

    public int Status { get; set; }

    public string Message { get; set; } = string.Empty;

    public TResultContent? Data { get; set; }
}