﻿using System.Reflection;

namespace DotNetExtras.Common;
/// <summary>
/// Use the static <see cref="AssemblyInfo"/> methods and properties to
/// access the primary application assembly and its most commonly used attributes
/// (the primary assembly normally corresponds to the main application assembly).
/// </summary>
/// <remarks>
/// <para>
/// Adapted from 
/// <see href="https://www.c-sharpcorner.com/UploadFile/ravesoft/access-assemblyinfo-file-and-get-product-informations"/>.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// string company   = AssemblyInfo.Company;
/// string copyright = AssemblyInfo.Copyright;
/// string product   = AssemblyInfo.Product;
/// string version   = AssemblyInfo.Version;
/// string title     = AssemblyInfo.Title;
/// </code>
/// </example>
public static class AssemblyInfo
{
    #region Public properties
    /// <summary>
    /// Returns the company name.
    /// </summary>
    public static string? Company
    {
        get
        {
            AssemblyCompanyAttribute? company = GetCustomAttribute<AssemblyCompanyAttribute>();
            return company?.Company;
        }
    }

    /// <summary>
    /// Returns the copyright message.
    /// </summary>
    public static string? Copyright
    {
        get
        {
            AssemblyCopyrightAttribute? copyright = GetCustomAttribute<AssemblyCopyrightAttribute>();
            return copyright?.Copyright;
        }
    }

    /// <summary>
    /// Returns the assembly description.
    /// </summary>
    public static string? Description
    {
        get
        {
            AssemblyDescriptionAttribute? description = GetCustomAttribute<AssemblyDescriptionAttribute>();
            return description?.Description;
        }
    }

    /// <summary>
    /// Returns the product name.
    /// </summary>
    public static string? Product
    {
        get
        {
            AssemblyProductAttribute? product = GetCustomAttribute<AssemblyProductAttribute>();
            return product?.Product;
        }
    }

    /// <summary>
    /// Returns the assembly title.
    /// </summary>
    public static string? Title
    {
        get
        {
            AssemblyTitleAttribute? title = GetCustomAttribute<AssemblyTitleAttribute>();
            return title?.Title;
        }
    }

    /// <summary>
    /// Returns the version of the assembly file.
    /// </summary>
    /// <remarks>
    /// For additional information about assembly and file versions, see
    /// <see href="https://stackoverflow.com/questions/64602/what-are-differences-between-assemblyversion-assemblyfileversion-and-assemblyin#answer-65062"/>.
    /// </remarks>
    public static string? Version
    {
        get
        {
            AssemblyFileVersionAttribute? version = GetCustomAttribute<AssemblyFileVersionAttribute>();
            return version?.Version;
        }
    }
    #endregion

    #region Public methods    
    /// <summary>
    /// Returns the main application assembly
    /// or the assembly implementing the specified type.
    /// </summary>
    /// <param name="type">
    /// Optional type of the class implemented in the assembly.
    /// </param>
    /// <returns>
    /// Current assembly or the assembly implementing the specified type.
    /// </returns>
    /// <remarks>
    /// If type is not specified, 
    /// assemblies are probed in the following order:
    /// 1. `Assembly.GetEntryAssembly()` 
    /// 2. `Assembly.GetCallingAssembly()`
    /// 3. `Assembly.GetExecutingAssembly()`,
    /// 4. `Assembly.GetAssembly(typeof(AssemblyInfo))`
    /// </remarks>
    public static Assembly? GetAssembly
    (
        Type? type = null
    )
    {
        return type == null
            ? ((Assembly.GetEntryAssembly()
                ?? Assembly.GetCallingAssembly())
                ?? Assembly.GetExecutingAssembly())
                ?? Assembly.GetAssembly(typeof(AssemblyInfo))
            : Assembly.GetAssembly(type);
    }
    #endregion

    #region Private methods
    /// <summary>
    /// Returns the custom assembly attribute.
    /// </summary>
    /// <typeparam name="T">
    /// Attribute data type.
    /// </typeparam>
    /// <returns>
    /// Attribute for the matching type.
    /// </returns>
    private static T? GetCustomAttribute<T>()
    where T : Attribute
    {
        Assembly? assembly = GetAssembly();

        if (assembly == null)
        {
            return null;
        }

        object[] attributes = assembly.GetCustomAttributes(typeof(T), false);

        return (attributes == null) || (attributes.Length == 0)
            ? null 
            : (T)attributes[0];
    }
    #endregion
}

