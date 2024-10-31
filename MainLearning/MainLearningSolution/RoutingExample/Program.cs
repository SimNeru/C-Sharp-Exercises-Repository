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
            app.UseEndpoints(endpoints =>
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
                endpoints.Map("office/profile/{EmployeeName?}", async (context) =>
                {
                    if (context.Request.RouteValues.ContainsKey("employeename"))
                    {
                        string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
                        await context.Response.WriteAsync($"In employees - {employeeName}");
                    }
                    else
                    {
                        await context.Response.WriteAsync($"In employees - employee name not provided");
                    }
                });

                // optional parameter
                endpoints.Map("products/details/{id?}", async (context) =>
                {
                    if (context.Request.RouteValues.ContainsKey("id"))
                    {
                        int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
                        await context.Response.WriteAsync($"In products - {id}");
                    }
                    else
                    {
                        await context.Response.WriteAsync($"Product details - id not supplied");
                    }
                });

                // Eg: daily-digest-report/{reportdate} CONSTRAINT ROUTE
                endpoints.Map("daily-digest-report/{reportdate:datetime}", async context =>
                {
                    // formato default accettato anno-mese-giorno o mese-giorno-anno
                    if (context.Request.RouteValues.ContainsKey("reportdate"))
                    {
                        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
                        await context.Response.WriteAsync($"Daily report - {reportDate.ToShortDateString()}");
                    }
                    else
                    {
                        await context.Response.WriteAsync($"Daily report - datetime not provided");
                    }
                });

                /* GUIDA CREAZIONE GUID 
                 * Tools -> Create GUID -> Registry format
                 */

                // Eg: cities/cityid CONSTRAINT ROUTE
                endpoints.Map("cities/{cityid:guid}", async context =>
                {
                    if (context.Request.RouteValues.ContainsKey("cityid"))
                    {
                        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
                        await context.Response.WriteAsync($"City info - {cityId.ToString()}");
                    }
                    else
                    {
                        await context.Response.WriteAsync($"City info - guid not provided");
                    }
                });

                // Eg: person/name (lenght 3,10) per indicare subito minima e massima
                // :alpha solo caratteri alfabetici
                // :range {id:int:range(1,1000)} per definire un range numerico
                endpoints.Map("person/{name:min(3):max(10):alpha?}", async context =>
                {
                    if (context.Request.RouteValues.ContainsKey("name"))
                    {
                        String? name = Convert.ToString(context.Request.RouteValues["name"]);
                        await context.Response.WriteAsync($"Person name - {name}");
                    }
                    else
                    {
                        await context.Response.WriteAsync($"Person name - no name provided");
                    }
                });

                // regex(expression)
                endpoints.Map("sales/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}", async context =>
                {

                    int year = Convert.ToInt32(context.Request.RouteValues["year"]);
                    string? month = Convert.ToString(context.Request.RouteValues["month"]);

                    await context.Response.WriteAsync($"sales report - {year}, Month - {month}");
                    
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
