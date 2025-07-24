namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the string or collection is null or empty.
    /// </summary>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must BeNullOrEmpty()
    {
        return _actual == null ? this : BeEmpty();
    }
}
