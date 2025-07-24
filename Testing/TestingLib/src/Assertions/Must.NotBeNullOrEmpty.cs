namespace DotNetExtras.Testing.Assertions;
public partial class Must
{
    /// <summary>
    /// Asserts that the string or collection is not null and not empty.
    /// </summary>
    /// <returns>
    /// The current <see cref="Must"/> instance.
    /// </returns>
    public Must NotBeNullOrEmpty()
    {
        return NotBeEmpty();
    }
}
