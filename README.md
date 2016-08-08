# RequestCorrelation.Owin

The OWIN middleware adds a correlation ID to the Requst and Response.  This allows support teams to correlate related HTTP Requests and Responses.  Also, the middleware exposes the correlation ID so it can be used to correlate other logging and event data.

## How it works

When requests are processed by the middleware the IOwinContext.Environment dictionary is analyzed for the key "Owin.RequestId".  If that key exists, is not null, empty, or whitespace the value will be used as the correlation ID.  Otherwise a new correlation ID will be generated, stored in IOwinContext.Environment and on the Response and Request.

## Installing the middleware

comming soon.

## Configuring the middleware

By default the middleware uses the `X-Request-ID` HTTP header to store the Response and Request correlation ID.  Also, if the IOWinContext.Environment `Owin.RequestId` is not set it will be generated and stored with a new GUID.

Both the HTTP header and algorithm for generating the correlation ID can be overriden.
