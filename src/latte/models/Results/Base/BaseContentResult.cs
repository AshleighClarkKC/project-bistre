namespace Latte.Models.Results.Base;

/// <summary>
/// Base result object for GET operations.
/// </summary>
/// <typeparam name="TContent">The content type for data returns.</typeparam>
public class BaseContentResult<TContent>
{
    public bool Success { get; set; }

    public int Status { get; set; }

    public string Message { get; set; } = string.Empty;

    public TContent? Data { get; set; }
}