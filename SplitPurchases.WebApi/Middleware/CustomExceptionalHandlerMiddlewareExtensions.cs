namespace SplitPurchases.WebApi.Middleware
{
    public static class CustomExceptionalHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder) {
            return builder.UseMiddleware<CustomExceptionalHandleMiddleware>();
        }
    }
}   
