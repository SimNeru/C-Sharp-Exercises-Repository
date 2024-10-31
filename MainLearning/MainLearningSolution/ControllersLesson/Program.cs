namespace ControllersLesson
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // aggiunta automatica di tutti i controllers presenti come services
            builder.Services.AddControllers();

            var app = builder.Build();

            // default web root path is www.root
            // creiamo una folder che contenga i file statici
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                // invece di mappare ciascun controller a mano
                // endpoints.Map("url1", ...);

                // asp.net core consente un mapping automatico
                // selezionerà tutti gli 'action' methods
                endpoints.MapControllers();
            });

            // addirittura useRouting e useEndpoints opzionali da usare su MapControllers per la logica interna

            app.Run();
        }
    }
}
