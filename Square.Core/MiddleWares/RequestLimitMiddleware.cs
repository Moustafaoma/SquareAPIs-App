using Microsoft.AspNetCore.Http;

public class RequestLimitMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Dictionary<string, int> _endpointRequests;
    private readonly int _maxRequests;

    public RequestLimitMiddleware(RequestDelegate next, int maxRequests = 150)
    {
        _next = next;
        _maxRequests = maxRequests;
        _endpointRequests = new Dictionary<string, int>();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var endpoint = context.Request.Path.ToString();

        int requestCount;
        lock (_endpointRequests)
        {
            if (!_endpointRequests.TryGetValue(endpoint, out requestCount))
            {
                _endpointRequests[endpoint] = 0;
                requestCount = 0;
            }
        }

        if (requestCount >= _maxRequests)
        {
            context.Response.StatusCode = 429; // Too Many Requests
            await context.Response.WriteAsync($"Rate limit exceeded for {endpoint}");
            return;
        }

        // Increment request count outside of lock for performance
        _endpointRequests[endpoint] = requestCount + 1;

        await _next(context);
    }
}
