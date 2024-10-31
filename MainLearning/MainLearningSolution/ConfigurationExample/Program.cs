namespace ConfigurationExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();

            // enable endpoints
            /* Commentato a seguito dell'esercitazione dell'Hierarchical Configuration
            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/config", async context =>
                {
                    await context.Response.WriteAsync
                    (app.Configuration["MyKey"] + "\n"); // restituirà valore contenuto a quello specifico indice chiave impostato
                    
                    await context.Response.WriteAsync
                    (app.Configuration.GetValue<string>("MyKey") + "\n");

                    await context.Response.WriteAsync
                    (app.Configuration.GetValue<int>("x", 10) + "\n"); // se non presente restituito il valore default
                });
            });
            */

            app.MapControllers();

            app.Run();
        }
    }
}
