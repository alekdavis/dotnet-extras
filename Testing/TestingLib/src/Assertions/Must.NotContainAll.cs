using DotNetExtras.Common;
using DotNetExtras.Common.Specialized;
using DotNetExtras.Common.Json;
using Xunit;
using Xunit.Sdk;

namespace DotNetExtras.Testing.Assertions;

public partial class Must
{
    /// <summary>
    /// Asserts that all expected values do not exist in a collection.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements in the collections.
    /// </typeparam>
    /// <param name="expected">
    /// The collection of items expected not to be in the actual collection or string.
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
    /// (a, b, c).NotContainAll(a, b): false; 
    /// (a, b, c).NotContainAll(c, d): true; 
    /// (a, b, c).NotContainAll(d, e): true;
    /// </remarks>
    public Must NotContainAll<T>
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
            return NotContainAll(expected.Cast<string>());
        }

        Assert.NotNull(_actual);

        if (_actual is IEnumerable<T> actualList)
        {
            foreach (T expectedItem in expected)
            {
                try
                {
                    Assert.DoesNotContain(actualList, item => expectedItem.IsEquivalentTo(item, partial));
                    return this;
                }
                catch (DoesNotContainException)
                {
                }
            }

            Assert.Fail($"Expected the '{_name}' collection to not contain all of [{(typeof(T).IsSimple() ? expected.ToCsv() : expected.ToJson())}], but got [{(typeof(T).IsSimple() ? actualList.ToCsv() : actualList.ToJson())}].");
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }

    /// <summary>
    /// Asserts that all expected string values doe not exist in a collection or string.
    /// </summary>
    /// <param name="expected">
    /// Collection of expected string values.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must NotContainAll
    (
        IEnumerable<string>? expected,
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
            Assert.False(expected.All(e => actualString.Contains(e, ignoreCase 
                ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)),
                    $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' string to not contain all of [{expected.ToCsv()}], but got [\"{actualString}\"].");
        }
        else if (_actual is IEnumerable<string> actualList)
        {
            Assert.False(expected.All(e => actualList.Contains(e, ignoreCase 
                ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal)),
                $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' collection to not contain all of [{expected.ToCsv()}], but got [{actualList.ToCsv()}].");
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }
}
