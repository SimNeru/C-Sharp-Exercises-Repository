
using System.Runtime.CompilerServices;

namespace Middlewares.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("\nMy Custom Middleware - Start ");
            await next(context);
            await context.Response.WriteAsync("\nMy Custom Middleware - End ");
        }
    }

    // Custom Middleware Extension
    public static class CustomMiddlewareExtension
    {
        // injection del metodo nell'oggetto 'app'
        // i modo che poi il metodo DoSomething possa essere richiamato
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app) 
        { 
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
