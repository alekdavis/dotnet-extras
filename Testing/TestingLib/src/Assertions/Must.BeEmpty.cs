using System.Collections;
using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the string or collection is empty.
    /// </summary>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must BeEmpty()
    {
        Assert.NotNull(_actual);

        if (_actual is string actualString)
        {
            Assert.Empty(actualString);
            return this;
        }

        if (_actual is IEnumerable actualEnumerable)
        {
            Assert.Empty(actualEnumerable);
            return this;
        }

        throw new AssertionDataTypeNotImplementedException(_actual);
    }
}
