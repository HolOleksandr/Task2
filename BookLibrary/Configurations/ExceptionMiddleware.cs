using Business.Exceptions;
using Data.Entities;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BookLibrary.Configurations
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (LibraryException ex)
            {
                _logger.LogError($"Something went wrong:", ex);
                await HandleLibraryExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong:", ex);
                await HandleExceptionAsync(httpContext);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new Error()
            {
                StatusCode = context.Response.StatusCode,
                Message = ("Internal Server Error")
            }.ToString());
        }

        private static async Task HandleLibraryExceptionAsync(HttpContext context, LibraryException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(new Error()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }
    }
}
