namespace DotNetExtras.Web.Client;

/// <summary>
/// Encapsulates error information specific to REST API calls including strongly typed data returned.
/// </summary>
/// <typeparam name="T">
/// Data type of the error object returned by the endpoint.
/// </typeparam>
public class GenericRestErrorDetails<T>: RestErrorDetails
{
    #region Public properties
    /// <summary>
    /// Returns error object received from the endpoint.
    /// </summary>
    /// <returns>
    /// Error object received from the endpoint, or null if no data was returned.
    /// </returns>  
    public T? ContentData { get; set; }
    #endregion
}
