using DotNetExtras.Common;
using DotNetExtras.Common.Extensions;
using DotNetExtras.Common.Extensions.Specialized;
using DotNetExtras.Common.Json;
using Xunit;
using Xunit.Sdk;

namespace DotNetExtras.Testing.Assertions;

public partial class Must
{
    /// <summary>
    /// Asserts that at least one expected value exists in a collection. 
    /// </summary>
    /// <typeparam name="T">
    /// Type of the elements in the collections.
    /// </typeparam>
    /// <param name="expected">
    /// Collection of expected items.
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
    /// (a, b, c).ContainAny(a, b): true; 
    /// (a, b, c).ContainAny(c, d): true; 
    /// (a, b, c).ContainAny(d, e): false.
    /// </remarks>
    public Must ContainAny<T>
    (
        IEnumerable<T>? expected,
        bool partial = false
    )
    {
        if (expected == null || !expected.Any())
        {
            return this;
        }

        if (typeof(T) == typeof(string))
        {
            return ContainAny(expected.Cast<string>(), false);
        }
        
        Assert.NotNull(_actual);

        if (_actual is IEnumerable<T> actualList)
        {
            foreach (T expectedItem in expected)
            {
                try
                {
                    Assert.Contains(actualList, item => expectedItem.IsEquivalentTo(item, partial));
                    return this;
                }
                catch (ContainsException)
                {
                }
            }

            Assert.Fail($"Expected the '{_name}' collection to contain any of [{(typeof(T).IsSimple() ? expected.ToCsv() : expected.ToJson())}], but got [{(typeof(T).IsSimple() ? actualList.ToCsv() : actualList.ToJson())}].");
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }

    /// <summary>
    /// Asserts that at least one expected string value exists in a collection or string.
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
    public Must ContainAny
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
            Assert.True(expected.Any(e => actualString.Contains(e, ignoreCase 
                ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)),
                    $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' string to contain any of [{expected.ToCsv()}], but got [\"{actualString}\"].");
        }
        else if (_actual is IEnumerable<string> actualList)
        {
            Assert.True(expected.Any(e => actualList.Contains(e, ignoreCase 
                ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal)),
                $"Expected the {(ignoreCase ? "case-insensitive" : "case-sensitive")} '{_name}' collection to contain any of [{expected.ToCsv()}], but got [{actualList.ToCsv()}].");
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }
}
