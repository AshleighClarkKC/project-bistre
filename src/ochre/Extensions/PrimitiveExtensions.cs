namespace Ochre.Extensions;

/// <summary>
/// Extension Methods for Primitive Types.
/// </summary>
public static class PrimitiveExtensions
{
    public static bool IsNull(this object? obj)
        => obj == null;

    public static bool IsEmpty(this string str, bool includeWhiteSpace = false)
        => includeWhiteSpace
        ? string.IsNullOrWhiteSpace(str)
        : string.IsNullOrEmpty(str);
}