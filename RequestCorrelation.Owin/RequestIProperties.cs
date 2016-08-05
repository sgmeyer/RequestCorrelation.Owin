using System;

namespace RequestCorrelation.Owin
{
    /// <summary>
    /// The properties for configuring how to correlate requests and responses.
    /// </summary>
    public class RequestIdProperties
    {
        /// <summary>
        /// The name of the request's header or query string parameter to use for a request correlation ID.
        /// </summary>
        public string RequestIdName { get; set; } = "X-Request-ID";

        /// <summary>
        /// The method for generating a correlation ID, the default behavior is generate a GUID.
        /// </summary>
        public Func<string> GenerateId { get; set; } = () => Guid.NewGuid().ToString();
    }
}
