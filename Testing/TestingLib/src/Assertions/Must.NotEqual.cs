using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value is equal to the expected value.
    /// </summary>
    /// <param name="expected">
    /// Value expected not to equal the actual value.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must NotEqual
    (
        string? expected,
        bool ignoreCase = true
    )
    {
        if (_actual != null)
        {
            Assert.IsType<string?>(_actual, false);
        }

        Assert.NotEqual(expected?.ToString(), _actual?.ToString(),
            ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);

        return this;
    }

    /// <summary>
    /// Asserts that the value is equal to the expected value.
    /// </summary>
    /// <param name="expected">
    /// Value expected not to equal the actual value.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must NotEqual
    (
        IEnumerable<string>? expected,
        bool ignoreCase = true
    )
    {
        if (_actual != null)
        {
            Assert.IsType<IEnumerable<string>?>(_actual, false);
        }

        StringComparer comparer = ignoreCase ?
            StringComparer.OrdinalIgnoreCase
            : StringComparer.Ordinal;

        Assert.NotEqual(expected, _actual as IEnumerable<string?>, comparer);

        return this;
    }

    /// <summary>
    /// Asserts that the value is equal to the expected value.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the expected value.
    /// </typeparam>
    /// <param name="expected">
    /// Value expected not to equal the actual value.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must NotEqual<T>
    (
        T expected
    )
    {
        if ((_actual != null && expected == null) || (_actual == null && expected != null))
        {
            return this;
        }

        if (_actual != null)
        {
            Assert.IsType<T>(_actual, false);
            Assert.NotEqual<T>(expected, (T)_actual);
        }

        return this;
    }
}
