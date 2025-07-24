using System.Runtime.CompilerServices;

namespace DotNetExtras.Testing.Assertions;
/// <summary>
/// Provides extension methods for assertions.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Creates a new <see cref="Must"/> instance for the specified value.
    /// </summary>
    /// <param name="value">
    /// The value to be asserted.
    /// </param>
    /// <param name="name">
    /// The name of the value parameter. This is automatically captured by the compiler.
    /// </param>
    /// <returns>A new <see cref="Must"/> instance.</returns>
    public static Must Must
    (
        this object? value,
        [CallerArgumentExpression(nameof(value))] string? name = null
    )
    {
        return new(value, name!);
    }
}
