namespace usermanagement_api.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException ex)
            {
                _logger.LogError(ex, $"Custom Exception occurred with ErrorCode: {ex.ErrorCode}");

                context.Response.StatusCode = 500; // Internal Server Error
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    status = "error",
                    message = ex.Message,
                    errorCode = ex.ErrorCode.ToString()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");

                context.Response.StatusCode = 500; // General Internal Server Error
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new
                {
                    status = "error",
                    message = ex,
                    errorCode = "Unknown" // Default error code for general exceptions
                });
            }
        }
    }
}
