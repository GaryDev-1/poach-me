using WildlifePoaching.API.Models.Domain.Common;
using WildlifePoaching.API.Models.Exceptions;

namespace WildlifePoaching.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new ApiErrorResponse
            {
                Status = GetStatusCode(exception),
                Message = GetMessage(exception),
                DeveloperMessage = _env.IsDevelopment() ? exception.StackTrace : null
            };

            if (exception is ValidationException validationException)
            {
                response.Errors = validationException.Errors;
            }

            context.Response.StatusCode = response.Status;
            await context.Response.WriteAsJsonAsync(response);
        }
        private int GetStatusCode(Exception exception) => exception switch
        {
            ValidationException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };

        private string GetMessage(Exception exception) => exception switch
        {
            ValidationException => "Validation Error",
            NotFoundException notFoundEx => notFoundEx.Message,
            UnauthorizedAccessException unauthorizedEx => unauthorizedEx.Message,
            _ => _env.IsDevelopment() ? exception.Message : "An unexpected error occurred"
        };

    }
}
