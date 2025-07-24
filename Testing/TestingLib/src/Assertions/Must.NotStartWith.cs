using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value does not start with the unexpected value.
    /// </summary>
    /// <param name="expected">
    /// Value expected not to be at the beginning of the string.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must NotStartWith
    (
        string expected,
        bool ignoreCase = true
    )
    {
        Assert.IsType<string>(_actual, false);

        Assert.False(_actual?.ToString()?.StartsWith(expected, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal),
            $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' string to not start with [\"{expected}\"], but got [\"{_actual}\"].");

        return this;
    }
}
