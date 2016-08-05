using Owin;

namespace RequestCorrelation.Owin
{
    public static class OwinMiddlewareExtensions
    {
        /// <summary>
        /// Use request correlation middleware.  Adds a Request ID to the Request and Response.
        /// </summary>
        /// <param name="app">The app.</param>
        /// <param name="properties">The properties for the request correlation.</param>
        /// <returns>The <see cref="IAppBuilder"/>.</returns>
        public static IAppBuilder UseRequestIds(this IAppBuilder app, RequestIdProperties properties = null)
        {
            if (properties == null) { properties = new RequestIdProperties(); }
            app.Use<RequestIdMiddleware>(properties);
            return app;
        }
    }
}
