﻿using System.Collections;
using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the string or collection is not empty.
    /// </summary>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must NotBeEmpty()
    {
        Assert.NotNull(_actual);

        if (_actual is string actualString)
        {
            Assert.NotEmpty(actualString);
            return this;
        }

        if (_actual is IEnumerable actualEnumerable)
        {
            Assert.NotEmpty(actualEnumerable);
            return this;
        }

        throw new AssertionDataTypeNotImplementedException(_actual);
    }
}
