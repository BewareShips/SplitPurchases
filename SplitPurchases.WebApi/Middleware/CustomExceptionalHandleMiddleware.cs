using Azure;
using FluentValidation;
using SplitPurchases.Application.Common.Exceptions;
using System;
using System.Net;
using System.Text.Json;

namespace SplitPurchases.WebApi.Middleware
{
    public class CustomExceptionalHandleMiddleware
    {
        private readonly RequestDelegate _next;
      

        public CustomExceptionalHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception exception)
            {
                await HandlerExceptionAsync(context, exception);
            }
        }
        private Task HandlerExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            } 
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            if(result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }
            return context.Response.WriteAsync(result);
        }
    }
}
