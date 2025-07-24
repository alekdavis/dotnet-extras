using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value is equal to the expected value.
    /// </summary>
    /// <param name="expected">
    /// Expected value.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must Equal
    (
        string? expected,
        bool ignoreCase = true
    )
    {
        Assert.IsType<string>(_actual, false);
        Assert.Equal(expected, _actual?.ToString(), ignoreCase);

        return this;
    }

    /// <summary>
    /// Asserts that the value is equal to the expected value.
    /// </summary>
    /// <param name="expected">
    /// Expected value.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must Equal
    (
        IEnumerable<string>? expected,
        bool ignoreCase = true
    )
    {
        if (expected == null && _actual == null)
        {
            return this;
        }

        Assert.IsType<IEnumerable<string>?>(_actual, false);

        Assert.NotNull(expected);
        Assert.NotNull(_actual);

        StringComparer comparer = ignoreCase ? 
            StringComparer.OrdinalIgnoreCase 
            : StringComparer.Ordinal;

        Assert.Equal(expected, (IEnumerable<string>)_actual, comparer);
        return this;
    }

    /// <summary>
    /// Asserts that the value is equal to the expected value.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the expected value.
    /// </typeparam>
    /// <param name="expected">
    /// Expected value.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must Equal<T>
    (
        T expected
    )
    {
        if (expected == null && _actual == null)
        {
            return this;
        }

        Assert.IsType<T>(_actual, false);
        Assert.Equal<T>(expected, (T)_actual);

        return this;
    }
}
