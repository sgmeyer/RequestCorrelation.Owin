# RequestCorrelation.Owin

The OWIN middleware adds a correlation ID to the Requst and Response.  This allows support teams to correlate HTTP Requests and Response.  Also, the middleware exposes the correlation ID so it can be used to correlate other logging and event data.

## How it works

When inbound requests hit the server the OWIN middleware will process the request.  Upon entry the request will be analyzed for a correlation id.  By default the middleware looks for the `X-Request-ID` HTTP header.  If the header does not exist it will look at the request's get params for `X-Request-ID`.  If the correlation ID doesn't exist or is missing a value a new ID will be generated.  Once the ID is generated it will be set on the request and response.

## Installing the middleware

comming soon.

## Configuring the middleware

comming soon.
