using DotNetExtras.Common;
using System.Runtime.CompilerServices;

namespace DotNetExtras.Testing.Assertions;

/// <summary>
/// Implements assertion methods for unit tests.
/// </summary>
/// <remarks>
/// This class implements wrapper methods for the existing <see href="https://xunit.net/">xUnit</see> assertions
/// and provides additional methods not available in the xUnit assertion library.
/// </remarks>
public partial class Must
{
    /// <summary>
    /// The name of the value being asserted.
    /// </summary>
    private readonly string _name;
    /// <summary>
    /// The value being asserted.
    /// </summary>
    private readonly object? _actual;

    /// <summary>
    /// Initializes a new instance of the <see cref="Must"/> class.
    /// </summary>
    /// <param name="value">
    /// Value being assessed.
    /// </param>
    /// <param name="name">
    /// Name of the value being assessed.
    /// </param>
    /// <param name="caller">
    /// Caller member name.
    /// </param>
    /// <remarks>
    /// Intended for internal use only.
    /// </remarks>
    internal Must
    (
        object? value,
        string name,
        [CallerMemberName] string caller = ""
    )
    {
        if (caller != nameof(AssertionExtensions.Must))
        {
            throw new InvalidOperationException($"The '{nameof(Must)}' constructor cannot be called explicitly. Use the '{NameOf.Full(nameof(AssertionExtensions.Must))}' extension method instead.");
        }

        _name = name;
        _actual = value;
    }
}
