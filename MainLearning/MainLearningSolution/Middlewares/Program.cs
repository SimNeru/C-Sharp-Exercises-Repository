using Middlewares.CustomMiddleware;

namespace Middlewares
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region PIPELINE
            var builder = WebApplication.CreateBuilder(args);

            // aggiungo come service il middleWare custom
            builder.Services.AddTransient<MyCustomMiddleware>();

            var app = builder.Build();

            // app.Run() non consente al conseguimento dell'esecuzione del Middleware successivo

            //middleware 1
            app.Use( async (HttpContext context, RequestDelegate next) => {
                await context.Response.WriteAsync("Hello ");
                // next indica come parametro context che viene ricevuto dal successivo
                await next(context);
            });

            //middleware 2

            //CUSTOM MIDDLEWARE *
            //app.UseMiddleware<MyCustomMiddleware>();

            //CUSTOM MIDDLEWARE DELEGATE * 
            //app.UseMyCustomMiddleware();

            //CUSTOM CONVENTIONAL MIDDLEWARE *
            app.UseHelloCustomMiddleware();

            //middleware 3
            app.Use( async (HttpContext context, RequestDelegate next) => {
                await context.Response.WriteAsync("\nWorld!");
                await next(context);
            });

            //middleware 4, terminate middleware 
            app.Run( async (HttpContext context) => {
                await context.Response.WriteAsync("\n:D");
            });
            #endregion

            app.Run();
        }
    }
}
