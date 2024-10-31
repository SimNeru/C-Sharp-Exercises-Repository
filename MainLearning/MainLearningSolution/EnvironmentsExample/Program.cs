namespace EnvironmentsExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            // sulla web page stamperà nel dettaglio l'eccezione di un errore lanciato
            // if (app.Environment.IsDevelopment())
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            };

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
