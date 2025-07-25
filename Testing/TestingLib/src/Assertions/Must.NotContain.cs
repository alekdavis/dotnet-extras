using DotNetExtras.Common;
using DotNetExtras.Common.Extensions;
using System.Collections;
using Xunit;

namespace DotNetExtras.Testing.Assertions;

public partial class Must
{
    /// <summary>
    /// Asserts that the expected value does not exist in a collection.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the expected value.
    /// </typeparam>
    /// <param name="expected">
    /// Value that is expected to not be contained within the actual value.
    /// </param>
    /// <param name="partial">
    /// For complex types, 
    /// indicates whether the missing or null properties in the expected value 
    /// must be ignored in the actual value.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must NotContain<T>
    (
        T? expected,
        bool partial = false
    )
    {
        if (expected == null)
        {
            return this;
        }

        if (expected is IEnumerable and not string)
        {
            throw new WrongAssertionForDataTypeException(
                expected, [nameof(Must.NotContainAll), nameof(Must.NotContainAny)]);
        }

        Assert.NotNull(_actual);

        if (_actual is string actualString)
        {
            return expected is string expectedString
                ? NotContain(expectedString, false)
                : throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }
        else if (_actual is IEnumerable<T> actualList)
        {
            if (expected.GetType().IsAssignableFrom(typeof(T)))
            {
                Assert.DoesNotContain(actualList, item => expected.IsEquivalentTo(item, partial));
            }
            else
            {
                throw new IncompatibleAssertionDataTypesException(expected, _actual);
            }
        }
        else
        {
            throw new AssertionDataTypeNotImplementedException(_actual);
        }

        return this;
    }

    /// <summary>
    /// Asserts that the expected string value does not exist in the actual string or collection of strings.
    /// </summary>
    /// <param name="expected">
    /// String value that is expected to not be contained within the actual value.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must NotContain
    (
        string? expected,
        bool ignoreCase = false
    )
    {
        if (string.IsNullOrEmpty(expected))
        {
            return this;
        }
        
        Assert.NotNull(_actual);

        if (_actual is string actualString)
        {
            Assert.DoesNotContain(expected, actualString, ignoreCase 
                ? StringComparison.OrdinalIgnoreCase 
                : StringComparison.Ordinal);
        }
        else if (_actual is IEnumerable<string> actualList)
        {
            Assert.DoesNotContain(expected, actualList, ignoreCase 
                ? StringComparer.OrdinalIgnoreCase 
                : StringComparer.Ordinal);
        }
        else
        {
            throw new IncompatibleAssertionDataTypesException(expected, _actual);
        }

        return this;
    }
}
