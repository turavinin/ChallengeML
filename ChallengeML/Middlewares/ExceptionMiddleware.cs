using ChallengeML.Domain.Entities.Exceptions;
using System.Net;
using System.Text.Json;

namespace ChallengeML.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "Unhandled exception caught by middleware.");

            context.Response.ContentType = "application/json";

            if (exception is FunctionalException functionalEx)
            {
                context.Response.StatusCode = (int)functionalEx.StatusCode;
                var response = new
                {
                    functionalEx.Message,
                    functionalEx.ErrorCode,
                    StatusCode = (int)functionalEx.StatusCode
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = new
                {
                    Message = "An unexpected error occurred.",
                    context.Response.StatusCode
                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
