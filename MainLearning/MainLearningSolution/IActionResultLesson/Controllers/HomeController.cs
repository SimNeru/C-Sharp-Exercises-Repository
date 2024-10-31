using Microsoft.AspNetCore.Mvc;

namespace IActionResultLesson.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        // Caso esempio in cui utilizzare l'Interfaccia padre a seconda del tipo di result che vogliamo definire
        // abbiamo ContentResult per il context di risposta e FileResult per il file che vogliamo restituire alla fine
        // IActionResult permette di gestire tutti i tipi di return delle casistiche che possiamo coprire

        // http://localhost:5062/book/?bookid=50&isloggedin=true

        [Route("book/{bookid?}/{isloggedin?}")]
        public IActionResult Index(int? bookid, bool? isloggedin) // passato come parametro verrà richiesto in automatico nell'url come key e potrà quindi essere richiesto diversamente nei check da effettuare
        {
            // book id should be applied
            if (!Request.Query.ContainsKey("bookid"))
            {
                /*
                Response.StatusCode = 400;
                return Content("Book id not provided");
                */

                return BadRequest("Book id not provided");
            }

            // book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"]))) 
            {
                /*
                Response.StatusCode = 400;
                return Content("Book id can't be null or empty");
                */

                return BadRequest("Book id can't be null or empty");
            }

            // book id should between 1 to 1000
            int bookId = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId <= 0)
            {
                // return Content("Book id can't be less then or equal to zero");
                return StatusCode(400);
            }

            if (bookId > 1000)
            {
                // return Content("Book id can't be greater than 1000");
                return NotFound("Book id can't be greater than 1000");
            }

            // isllogedin should be true
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                /*
                Response.StatusCode = 401;
                return Content("User must be authenticated");
                */
                return Unauthorized("User must be authenticated");
            }

            // before Redirection Result
            // return File("/sample.pdf", "application/pdf");

            // new RedirectToActionResult("Nome Della Action","Nome della classe controller senza suffisso", oggetto per le route values);

            return RedirectToAction("Books", "Store", new { id = bookId });

            return new RedirectToActionResult("Book","Store", new { }, false); // 302 - Found

            return RedirectToActionPermanent("Book","Store", new { id = bookId }); // 301 - Moved Permanently

            // l'url passato qua è implicito che sia richiesto che appartenga alla solita web application
            return new LocalRedirectResult($"store/books/{bookId}");

            // utile nell'evenienza uno desidera passare da un dominio a un altro (website1 website2)
            return Redirect($"store/books/{bookId}");
        }
    }
}
