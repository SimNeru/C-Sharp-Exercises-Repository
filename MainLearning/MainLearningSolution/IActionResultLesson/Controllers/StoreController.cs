using Microsoft.AspNetCore.Mvc;

namespace IActionResultLesson.Controllers
{
    public class StoreController : Controller
    {
        // {oggetto} che può essere passato dal reinderizzamento
        [Route("store/books/{id}")]
        public IActionResult Books()
        {
            int id = Convert.ToInt32(Request.RouteValues["id"]);
            return Content($"You have been redirected to this page, looking for the book with the follow id: {id}");
        }
    }
}
