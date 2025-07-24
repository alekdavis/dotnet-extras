using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value is of the specified type.
    /// </summary>
    /// <typeparam name="T">
    /// The expected type of the value.
    /// </typeparam>
    /// <param name="strict">
    /// Indicates whether to perform a strict type check.
    /// </param>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must BeOfType<T>
    (
        bool strict = false
    )
    {
        Assert.IsType<T>(_actual, strict);

        return this;
    }
}
