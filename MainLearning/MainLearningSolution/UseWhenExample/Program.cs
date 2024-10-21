using Microsoft.AspNetCore.Builder;

namespace UseWhenExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.UseWhen(
                // il momento che la lambda risulterà true
                context => context.Request.Query.ContainsKey("username"),
                // eseguirà questo pezzo di codice
                app => {
                    app.Use(async (context, next) =>
                    {
                        await context.Response.WriteAsync("\nHello from Middleware Branch");
                        await next();
                    });
                });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("\nHello from Main Chain Branch");
                await next();
            });

            app.Run();
        }
    }
}
