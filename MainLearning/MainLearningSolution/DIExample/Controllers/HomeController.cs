using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;
using Autofac;

namespace DIExample.Controllers
{

    public class HomeController : Controller
    {
        // bad practice
        // private readonly CitiesService? _citiesService;

        /* NOTA: commentabile in seguito al richiamo a riga 30 di [FromService] */

        // Dependency Injection
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        // private readonly IServiceScopeFactory _serviceScopeFactory; // sostituito a seguito dell'implementazione di AutoFac
        private readonly ILifetimeScope _serviceScopeFactory;

        public HomeController(
            ICitiesService citiesService1,
            ICitiesService citiesService2,
            ICitiesService citiesService3,
            // IServiceScopeFactory serviceScopeFactory
            ILifetimeScope lifetimeScope
            )
        {
            // bad practive 
            // _citiesService = new CitiesService();

            // con implementazione dependency injection
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            // _serviceScopeFactory = serviceScopeFactory; // rimosso in seguito Autofac
            _serviceScopeFactory = lifetimeScope;
        }

        [Route("/")]
        public IActionResult Index(/*[FromServices] ICitiesService _citiesService*/)
        // FROM SERVICE asciuga dal codice precedente, eseguendo dietro le quinte
        // la reference type e il costruttore con parametro alla dependency
        {
            IEnumerable<string> citiesList = _citiesService1.GetCitiesMethod();

            ViewBag.InstanceId_CitiesService_1 = _citiesService1.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_2 = _citiesService2.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_3 = _citiesService3.ServiceInstanceId;

            using (ILifetimeScope scope = _serviceScopeFactory.BeginLifetimeScope())
            {
                ICitiesService citiesService =
                scope.Resolve<ICitiesService>();

                ViewBag.InstanceId_CitiesService_InScope = citiesService.ServiceInstanceId;
            }

            /* Sintassi con IOC default, No AutoFac
            // invocazione dello scoped e dispose by using
            using (IServiceScope scope = _serviceScopeFactory.CreateScope()) 
            {
                // Inject CitieService
                ICitiesService citiesService = 
                scope.ServiceProvider.GetRequiredService<ICitiesService>();

                // DB WORK
                ViewBag.InstanceId_CitiesService_InScope = citiesService.ServiceInstanceId;

            } // end of scope; it calls CitiesService.Dispose()
            */

                return View(citiesList);
        }
    }
}
