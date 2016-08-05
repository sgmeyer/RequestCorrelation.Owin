using Microsoft.Owin;

namespace RequestCorrelation.Owin
{
    public static class OwinContextExtension
    {
        /// <summary>
        /// The default header name used for storing the X-Request-ID on the IOwinRequest and IOwinResponse.
        /// </summary>
        private const string DefaultCorrelationHeaderName = "X-Request-ID";

        /// <summary>
        /// Retrieves the correlation ID from the IOwinRequest.
        /// </summary>
        /// <param name="request">The <see cref="IOwinRequest"/>.</param>
        /// <param name="requestIdName">The name of the Http Header to place the request correlation id.</param>
        /// <returns>The correlation ID.</returns>
        public static string GetRequestCorrelationId(this IOwinRequest request, string requestIdName = DefaultCorrelationHeaderName)
        {
            return request.Headers[requestIdName] ?? request.Query[requestIdName];
        }

        /// <summary>
        /// Retrieves the correlation ID from the IOwinResponse.
        /// </summary>
        /// <param name="response">The <see cref="IOwinResponse"/>.</param>
        /// <param name="requestIdName">The name of the Http Header to place the correlation id.</param>
        /// <returns>The correlation ID.</returns>
        public static string GetResponseCorrelationId(this IOwinResponse response, string requestIdName = DefaultCorrelationHeaderName)
        {
            return response.Headers[requestIdName];
        }

        /// <summary>
        /// Sets the correlation id on IOwinRequest and IOwinResponse.
        /// </summary>
        /// <param name="context">The <see cref="IOwinContext"/>.</param>
        /// <param name="requestIdName">The name of the Http Header to place the request correlation id.</param>
        /// <param name="correlationId">The identifier used to correlate requests and responses.</param>
        public static void SetCorrelationId(this IOwinContext context, string correlationId, string requestIdName = DefaultCorrelationHeaderName)
        {
            var headerValue = new[] { correlationId };
            if (context.Request.Headers.ContainsKey(correlationId)){ context.Request.Headers[requestIdName] = correlationId; }
            else { context.Request.Headers.Add(requestIdName, headerValue); }
            context.Response.Headers.Add(requestIdName, headerValue);
        }
    }
}
