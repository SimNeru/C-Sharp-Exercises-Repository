using Microsoft.AspNetCore.Mvc;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        // private field configuration
        private readonly IConfiguration _configuration;

        //constructor
        public HomeController(IConfiguration configuration) 
        { 
            _configuration = configuration;
        }

        [Route("/")]
        public IActionResult Index()
        {
            // ViewBag.MyKey = _configuration["MyKey"];
            // ViewBag.MyAPIKey = _configuration.GetValue("MyAPIKey", "default key");

            // IConfigurationSection weatherApiSection = _configuration.GetSection("weatherapi"); // Configurazione per la sezione di un configurazione hierarchical 

            // ViewBag.ClientID = _configuration["weatherapi:ClientID"];
            // ViewBag.ClientID = _configuration.GetSection("weatherapi")["ClientID"]; // hierarchical configuration

            // ViewBag.ClientSecret = _configuration.GetValue("weatherapi:ClientSecret", "default secret");
            // ViewBag.ClientSecret = _configuration.GetSection("weatherapi")["ClientSecret"]; // hierarchical configuration

            // Bind: Loads configuration values into a new Options object
            // WeatherApiOptions options = _configuration.GetSection("weatherapi").Get<WeatherApiOptions>();

            // load sull'oggetto di tipo WeatherApiOptions delle keys
            WeatherApiOptions options = new WeatherApiOptions();

            // Bind: Loads configuration values into existing Options object
            _configuration.GetSection("weatherapi").Bind(options);

            ViewBag.ClientID = options.ClientID;

            ViewBag.ClientSecret = options.ClientSecret;

            return View();
        }
    }
}
