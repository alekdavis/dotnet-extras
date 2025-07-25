﻿using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value ends with the expected value.
    /// </summary>
    /// <param name="expected">
    /// The expected starting value.
    /// </param>
    /// <param name="ignoreCase">
    /// Indicates whether to ignore case when comparing strings.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must EndWith
    (
        string expected,
        bool ignoreCase = true
    )
    {
        Assert.IsType<string>(_actual, false);
        Assert.EndsWith(expected, _actual?.ToString(), ignoreCase 
            ? StringComparison.OrdinalIgnoreCase 
            : StringComparison.Ordinal);

        return this;
    }
}
