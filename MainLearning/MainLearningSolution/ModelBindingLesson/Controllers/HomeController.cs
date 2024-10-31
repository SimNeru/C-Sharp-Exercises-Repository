using Microsoft.AspNetCore.Mvc;

namespace ModelBindingLesson.Controllers
{
    public class HomeController : Controller
    {

        // http://localhost:5062/book/?bookid=50&isloggedin=true

        [Route("book/{bookid?}/{isloggedin?}")]
        public IActionResult Index([FromQuery] int? bookid, [FromRoute] bool? isloggedin, Book book)
        // passato come parametro verrà richiesto in automatico nell'url come key e potrà quindi essere richiesto diversamente nei check da effettuare
        // l'oggetto Book verrà inizializzato in automatico
        {
            if (bookid.HasValue == false)
            {
                return BadRequest("Book id not provided");
            }

            if (bookid == null)
            {
                return BadRequest("Book id can't be null or empty");
            }

            if (bookid <= 0)
            {
                return StatusCode(400);
            }

            if (bookid > 1000)
            {
                return NotFound("Book id can't be greater than 1000");
            }

            if (isloggedin == false)
            {
                return Unauthorized("User must be authenticated");
            }

            return RedirectToAction("Books", "Store", new { id = bookid });
        }
    }
}
