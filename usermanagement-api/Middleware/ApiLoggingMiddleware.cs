namespace usermanagement_api.Middleware;
public class ApiLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ApiLoggingMiddleware> _logger;

    public ApiLoggingMiddleware(RequestDelegate next, ILogger<ApiLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Log the incoming request
        _logger.LogInformation("Incoming request: {Method} {Url}", context.Request.Method, context.Request.Path);

        // Log the request headers
        _logger.LogInformation("Request headers: {Headers}", context.Request.Headers);

        // Log the request body (if any)
        //string requestBody = await ReadRequestBody(context.Request);
        //if (!string.IsNullOrEmpty(requestBody))
        //{
        //    _logger.LogInformation("Request body: {RequestBody}", requestBody);
        //}

        //context.Request.Body.Position = 0;

        // Continue processing the request
        await _next(context);

        // Log the response status
        _logger.LogInformation("Response status: {StatusCode}", context.Response.StatusCode);
    }

    private async Task<string> ReadRequestBody(HttpRequest request)
    {
        if (request.Body.CanSeek)
        {
            request.Body.Seek(0, SeekOrigin.Begin);
        }

        using (var reader = new StreamReader(request.Body))
        {
            return await reader.ReadToEndAsync();
        }
    }
}
