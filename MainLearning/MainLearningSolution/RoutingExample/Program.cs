namespace RoutingExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
;
            app.Use(async (context, next) => 
            {
                Microsoft.AspNetCore.Http.Endpoint? endpoint =
                context.GetEndpoint();

                if (endpoint != null) 
                { 
                await context.Response.WriteAsync($"Endpoint: {endpoint.DisplayName}\n");
                }
                await next(context);
            });

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                Microsoft.AspNetCore.Http.Endpoint? endpoint =
                context.GetEndpoint();

                if (endpoint != null)
                {
                    await context.Response.WriteAsync($"Endpoint: {endpoint.DisplayName}\n");
                }

                await next(context);
            });

            // creating end points
            app.UseEndpoints( endpoints => 
            {
                /* Di default Map esegue per "get" o "post" o qualunque altro metodo http
                 */

                //endpoints.MapGet();
                //endpoints.MapPost();

                // add your end points 
                endpoints.Map("files/{filename}.{extension}", async (context) => 
                {
                    // Converte filename ed extension in stringa che poi posso passare al testo scritto
                    string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
                    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

                    await context.Response.WriteAsync($"In files - {fileName} - {extension}");
                });

                //restituirà matt come default ma altrimenti potrebbe accettare anche un altro valore se passato come endpoint
                endpoints.Map("produv/profile/{EmployeeName=matt}", async (context) => 
                {
                    string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
                    await context.Response.WriteAsync($"In employees - {employeeName}");
                });
                
                endpoints.Map("products/details/{id=1}", async (context) => 
                {
                    int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
                    await context.Response.WriteAsync($"In products - {id}");
                });
            });

            // default response
            app.Run(async context =>
            {
                await context.Response.WriteAsync($"Request received at {context.Request.Path}");
            });

            app.Run();
        }
    }
}
