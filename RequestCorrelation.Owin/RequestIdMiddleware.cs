using System.Threading.Tasks;
using Microsoft.Owin;

namespace RequestCorrelation.Owin
{
    /// <summary>
    /// An OWIN middleware for adding a request correlation ID to the request and response.
    /// </summary>
    public class RequestIdMiddleware : OwinMiddleware
    {
        private readonly RequestIdProperties _properties;

        /// <summary>
        /// Initializes a new instance of <see cref="RequestIdMiddleware"/>.
        /// </summary>
        /// <param name="next">The next owin middleware to execute.</param>
        /// <param name="properties">The <see cref="RequestIdProperties"/> used to configure the middleware.</param>
        public RequestIdMiddleware(OwinMiddleware next, RequestIdProperties properties) : base(next)
        {
            _properties = properties;
        }

        /// <summary>
        /// Processes individual requests adding a correlation id.  Uses one if it is provided
        /// </summary>
        /// <param name="context">The <see cref="IOwinContext"/></param>
        /// <returns></returns>
        public override async Task Invoke(IOwinContext context)
        {
            var correlationId = context.Request.GetRequestCorrelationId(_properties.RequestIdName) ??
                                _properties.GenerateId();
            context.SetCorrelationId(correlationId, _properties.RequestIdName);
            await Next.Invoke(context);
        }
    }
}
