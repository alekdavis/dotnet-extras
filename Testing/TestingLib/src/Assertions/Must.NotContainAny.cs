using DotNetExtras.Common;
using DotNetExtras.Common.Extensions;
using Xunit;

namespace DotNetExtras.Testing.Assertions;

public partial class Must
{
    /// <summary>
    /// Asserts that at least one expected value does not exist in a collection. 
    /// </summary>
    /// <typeparam name="T">
    /// Type of the elements in the collections.
    /// </typeparam>
    /// <param name="expected">
    /// Collection of items expected not to be in the actual collection or string.
    /// </param>
    /// <param name="partial">
    /// For complex types, 
    /// indicates whether the missing or null properties in the expected value 
    /// must be ignored in the actual value.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    /// <remarks>
    /// Expected: 
    /// (a, b, c).NotContainAny(a, b): false; 
    /// (a, b, c).NotContainAny(a, d): false; 
    /// (a, b, c).NotContainAny(d, e): true.
    /// </remarks>
    public Must NotContainAny<T>
    (
        IEnumerable<T>? expected,
        bool partial = false
    )
    {
        if (_actual == null || expected == null || !expected.Any())
        {
            return this;
        }

        if (typeof(T) == typeof(string))
        {
            return NotContainAny(expected.Cast<string>(), false);
        }

        if (_actual is IEnumerable<T> actualList)
        {
            if (!actualList.Any())
            {
                return this;
            }

            foreach (T expectedItem in expected)
            {
                Assert.DoesNotContain(actualList, item => expectedItem.IsEquivalentTo(item, partial));
            }
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }

    /// <summary>
    /// Asserts that at least one expected string does not exist in a collection of strings. 
    /// </summary>
    /// <param name="expected">
    /// Collection of expected string items.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must NotContainAny
    (
        IEnumerable<string> expected,
        bool ignoreCase = false
    )
    {
        if (expected == null || !expected.Any())
        {
            return this;
        }

        Assert.NotNull(_actual);
        
        if (_actual is string actualString)
        {
            Assert.False(expected.Any(e => actualString.Contains(e, ignoreCase 
                ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)),
                    $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' string to not contain any of [{expected.ToCsv()}], but got [\"{actualString}\"].");
        }
        else if (_actual is IEnumerable<string> actualList)
        {
            Assert.False(expected.Any(e => actualList.Contains(e, ignoreCase 
                ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal)),
                $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' collection to not contain any of [{expected.ToCsv()}], but got [{actualList.ToCsv()}].");
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }
}
