using Microsoft.AspNetCore.Mvc;

namespace EnvironmentsExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        // constructor per aiutare tramite dependency injection definizione environment
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.CurrentEnvironment = 
            _webHostEnvironment.EnvironmentName;
            return View();
        }
        
        // test di un errore di due action con medesima route
        [Route("some-route")]
        public IActionResult Other()
        {
            return View();
        }
    }
}
