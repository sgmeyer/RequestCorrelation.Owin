using Microsoft.Owin;

namespace RequestCorrelation.Owin
{
    public static class OwinContextExtension
    {
        /// <summary>
        /// The Environment key used to store the host generated request id (correlation id).
        /// </summary>
        private const string OwinRequestIdKey = "owin.RequestId";

        /// <summary>
        /// Sets the correlation id on IOwinRequest and IOwinResponse.  If the Owin.RequestId already exists a new one will not be generated.
        /// Only if the Owin.RequestId is null, empty, whitespace, or non-existent will it be overriden.
        /// </summary>
        /// <param name="context">The <see cref="IOwinContext"/>.</param>
        /// <param name="createCorrelationId">The Func to build a correlation ID.</param>
        /// <param name="requestIdName">The name of the Http Header to place the request correlation id.</param>
        public static void SetCorrelationId(this IOwinContext context, CorrelationIdProperties properties)
        {
            var correlationId = properties.GenerateId();
            var requestIdName = properties.CorrelationIdHeaderName;
            var environment = context.Environment;

            // Update IOwinContext.Environment if it doesn't have a value.
            var hasCorrelationId = environment.ContainsKey(OwinRequestIdKey) && !string.IsNullOrWhiteSpace(environment[OwinRequestIdKey].ToString());
            if (hasCorrelationId) { correlationId = environment[OwinRequestIdKey].ToString(); }
            else { environment[OwinRequestIdKey] = correlationId; }

            // Apply correlation ID to Request and Response.
            var headerValue = new[] { correlationId };
            if (context.Request.Headers.ContainsKey(correlationId)){ context.Request.Headers[requestIdName] = correlationId; }
            else { context.Request.Headers.Add(requestIdName, headerValue); }
            context.Response.Headers.Add(requestIdName, headerValue);
        }

        /// <summary>
        /// Retrieves the correlation ID from the IOwinContext.Evironment dictionary.
        /// </summary>
        /// <param name="context">The <see cref="IOwinContext"./></param>
        /// <returns></returns>
        public static string GetCorrelationId(this IOwinContext context)
        {
            var environment = context.Environment;
            var hasCorrelationId = environment.ContainsKey(OwinRequestIdKey) && !string.IsNullOrWhiteSpace(environment[OwinRequestIdKey].ToString());
            var correlationId = "";
            if (hasCorrelationId) { correlationId = environment[OwinRequestIdKey].ToString(); }

            return correlationId;
        }
    }
}
