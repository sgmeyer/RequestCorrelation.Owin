using System;

namespace RequestCorrelation.Owin
{
    /// <summary>
    /// The properties for configuring how to correlate requests and responses.
    /// </summary>
    public class CorrelationIdProperties
    {
        /// <summary>
        /// The name of the response header, request header, and query string parameter where the correlation ID is stored.
        /// </summary>
        public string CorrelationIdHeaderName { get; set; } = "X-Request-ID";

        /// <summary>
        /// The method for generating a correlation ID, the default behavior is generate a GUID.
        /// </summary>
        public Func<string> GenerateId { get; set; } = () => Guid.NewGuid().ToString();
    }
}
