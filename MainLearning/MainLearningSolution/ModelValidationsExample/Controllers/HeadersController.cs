using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
    public class HeadersController : Controller
    {
        [Route("register-headers")]
        public IActionResult Index(Person person,
            [FromHeader(Name = "User-Agent")] string UserAgent) // modo tradizionale di leggere gli header
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }

            return Content($"{person}, {UserAgent}");
        }
    }
}
