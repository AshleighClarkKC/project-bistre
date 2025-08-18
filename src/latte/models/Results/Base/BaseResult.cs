namespace Latte.Models.Results.Base;

/// <summary>
/// Base result object for POST, PUT, DELETE operations.
/// </summary>
public class BaseResult
{
    public bool Success { get; set; }

    public int Status { get; set; }

    public string Message { get; set; } = string.Empty;
}