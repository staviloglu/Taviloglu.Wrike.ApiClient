using System;

namespace Taviloglu.Wrike.ApiClient.Exceptions
{
    /// <summary>
    /// The exception that is thrown when error property of response from Wrike is not null or empty
    /// </summary>
    public class WrikeApiException : Exception
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="WrikeApiException"></see> class with the
        ///  error and error description properties of Wrike API Response that causes this exception
        /// </summary>
        /// <param name="error">error property of Wrike API Response</param>
        /// /// <param name="errorDescription">errorDescription property of Wrike API Response</param>
        public WrikeApiException(string error, string errorDescription) : base($"{error}: {errorDescription}") { }
    }
}
