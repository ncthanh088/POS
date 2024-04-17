using Humanizer;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using POS.Application.Exceptions;
using POS.Domain.Exceptions.Abstractions;

namespace POS.Infrastructure.Exceptions
{
    internal sealed class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                await HandleExceptionAsync(exception, context);
            }
        }

        private static async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            var errorCode = exception.GetType().Name.Underscore().Replace("_exception", string.Empty);
            var error = new Error("error", "There was a error.");

            switch (exception)
            {
                case InvalidCredentialsException:
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    error = new Error(errorCode, exception.Message);
                    break;
                case GlobalException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    error = new Error(errorCode, exception.Message);
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            var json = JsonSerializer.Serialize(error);
            await context.Response.WriteAsync(json);
        }

        private record Error(string Code, string Reason);
    }
}
