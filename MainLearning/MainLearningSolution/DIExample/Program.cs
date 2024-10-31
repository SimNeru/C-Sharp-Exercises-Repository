using Autofac;
using Autofac.Extensions.DependencyInjection;
using ServiceContracts;
using Services;

namespace DIExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // implementazione tramite Autofac del nuovo IoC container
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Services.AddControllersWithViews();

            // definizione dell'IoC container 
            // primo argomento: tipo interfaccia, ogni qualvolta qualcuno chiamerà creerà un oggetto del secondo tipo
            // secondo argomento: oggetto concreto restituito
            /*
            builder.Services.Add(new ServiceDescriptor(
                typeof(ICitiesService),
                typeof(CitiesService),
                // arco di durata del servizio
                ServiceLifetime.Scoped
            ));
            */

            /* Invece della sintassi più lunga usata precedentemente, si può usare quelle successive */
            // builder.Services.AddTransient<ICitiesService, CitiesService>(); // * * * * * * * * * *
            // builder.Services.AddScoped<ICitiesService, CitiesService>(); // * * * * * * * * * *
            // builder.Services.AddSingleton<ICitiesService, CitiesService>(); // * * * * * * * * * *

            // Injection del servizio tramite Autofac ioc
            builder.Host.ConfigureContainer<ContainerBuilder>(
                containerBuilder =>
                {
                    // containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency();
                    // = AddTransient

                    containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope();
                    // = AddScoped

                    // containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().SingleInstance();
                    // = AddSingleton
                }
                );

            /* 
             * Tipi di service lifetime (momento creazione/distruzione oggetto):
             * 
             * TRANSIENT: Per ogni Injection, gli oggetti così creati verranno distrutti solo alla fine dello 'scope' (una browser request in genere)
             * ideale per servizi con vita breve, per uso unico a controller (esempio: )
             * 
             * SCOPED: Per scope (browser request), creati una volta per scope e distrutti alla fine di esso  
             * ideale per stabilire connessioni al db per effettuare anche singole request che al termine dell'operazione chiudono la connessione
             * 
             * SINGLETON: For entire application lifetime creato una sola prima volta e distrutti solo allo shutdown dell'applicazione.
             * Ideale per conservazione di data temporaneamente come servizi di cache, comuni per tutti gli utenti
             */

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
