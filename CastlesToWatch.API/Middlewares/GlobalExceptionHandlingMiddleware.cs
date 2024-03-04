using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CastlesToWatch.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> logger;
        private readonly RequestDelegate next;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger,RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch(Exception ex)
            {
                logger.LogError(ex,ex.Message);

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    
                    ErrorMessage = "There is a error my friend! We will try to fix this"

                };
                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
