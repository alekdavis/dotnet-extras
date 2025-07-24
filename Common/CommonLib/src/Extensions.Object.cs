using System.Collections;
using System.Reflection;

namespace DotNetExtras.Common;
public static partial class Extensions
{
    #region Public methods
    /// <summary>
    /// Determines whether the specified object 
    /// has no properties or fields holding non-null values or non-empty collections.
    /// </summary>
    /// <param name="source">
    /// The object to check.
    /// </param>
    /// <param name="publicOnly">
    /// If <c>true</c>, only public properties and fields will be checked.
    /// </param>
    /// <returns>
    /// <c>true</c> if the object is empty; otherwise, <c>false</c>.
    /// </returns>
    /// <example>
    /// <code>
    /// User? u1 = new();
    /// Assert.True(u1.IsEmpty());
    ///
    /// User? u2 = new()
    /// {
    ///     Id = "123"
    /// };
    /// Assert.False(u2.IsEmpty());
    /// </code>
    /// </example>
    public static bool IsEmpty
    (
        this object? source,
        bool publicOnly = false
    )
    {
        if (source == null)
        {
            return true;
        }

        Type type = source.GetType();

        // Check all public and internal properties
        foreach (PropertyInfo propertyInfo in type.GetProperties(
            BindingFlags.Instance |
            BindingFlags.Public |
            (publicOnly ? 0 : BindingFlags.NonPublic)))
        {
            if (propertyInfo.GetIndexParameters().Length == 0) // Ignore indexers
            {
                object? value = propertyInfo.GetValue(source);

                if (value != null)
                {
                    if (!IsEmptyValue(value))
                    {
                        return false;
                    }
                }
            }
        }

        // Check all public and internal fields
        foreach (FieldInfo field in type.GetFields(
            BindingFlags.Instance |
            BindingFlags.Public  |
            (publicOnly ? 0 : BindingFlags.Public)))
        {
            object? value = field.GetValue(source);

            if (value != null)
            {
                if (!IsEmptyValue(value))
                {
                    return false;
                }
            }
        }

        return true;
    }
    #endregion

    #region Private methods
    /// <summary>
    /// Determines whether the specified value is empty.
    /// A value is considered empty if it is null, an empty string, an empty collection, or an empty enumerable.
    /// </summary>
    /// <param name="value">
    /// The value to check.
    /// </param>
    /// <returns>
    /// <c>true</c> if the value is empty; otherwise, <c>false</c>.
    /// </returns>
    private static bool IsEmptyValue
    (
        object? value
    )
    {
        return value == null || (value is not string && (value is ICollection collection
            ? collection.Count == 0
            : value is IEnumerable enumerable
                ? !enumerable.Cast<object>().Any()
                : !value.GetType().IsValueType && value.IsEmpty()));
    }
    #endregion
}
