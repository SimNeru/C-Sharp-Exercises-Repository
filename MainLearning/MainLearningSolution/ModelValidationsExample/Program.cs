using ModelValidationsExample.CustomModelBinders;

namespace ModelValidationsExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // lamda aggiungibile per implementare il 'BINDER PROVIDER', non possibile però implementare array di valori (List di tags)
            // inoltre sembrerebbe sempre creare conflittualità con il 'CustomBlinder' nella generazione del full name...
            builder.Services.AddControllers( options => { /*
                options.ModelBinderProviders.Insert(0, new PersonBinderProvider()); */
            });

            // data che arriverà dai controller potrà essere tradotto in model anche dal body in formato xml (app + legacy) in runtime
            builder.Services.AddControllers().AddXmlSerializerFormatters();
            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
