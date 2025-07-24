using Xunit;

namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the value is true.
    /// </summary>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must BeTrue
    (
    )
    {
        Assert.NotNull(_actual);
        Assert.IsType<bool>(_actual, false);
        Assert.True((bool)_actual);

        return this;
    }
}
