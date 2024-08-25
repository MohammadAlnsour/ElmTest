using ElmTest.Shared.AppExceptions;

namespace ElmTest.API.Middlewares
{
    public class ErrorLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger;

        public ErrorLogMiddleware(RequestDelegate next, Serilog.ILogger logger)
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
            catch (Exception ex)
            {
                ex.HandleException(_logger);
                throw;
            }
        }
    }
    public static class ErrorLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorLogMiddleware>();
        }
    }
}
