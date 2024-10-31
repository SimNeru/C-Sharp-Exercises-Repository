using Microsoft.AspNetCore.Mvc;
using ViewsExaple.Models;

namespace ViewsExaple.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["pageTitle"] = "Asp.Net Core Demo App";

            List<Person> people = new List<Person>()
             {
                     new Person()
                     {
                         Name = "Jane",
                         BirthDate = DateTime.Parse("2005-01-09"),
                         PersonGender = Gender.Female
                     },

                     new Person()
                     {
                         Name = "John",
                         BirthDate = DateTime.Parse("2008-07-06"),
                         PersonGender = Gender.Male
                     },

                     new Person()
                     {
                         Name = "Jojo",
                         BirthDate = DateTime.Parse("2000-05-12"),
                         PersonGender = Gender.Other
                     },
             };

            // people è la key
            ViewData["people"] = people;

            return View("Index", people); // Views/Home/Index.cshtml -> default nome Index se non specificato
            // return new ViewResult() { ViewName = "abc"}; // lenghty way
        }

        [Route("person-details/{name}")]
        public IActionResult Details(string? name) 
        {
            if (name == null)
            {
                return Content("Person name can't be null");
            }

            List<Person> people = new List<Person>()
             {
                     new Person()
                     {
                         Name = "Jane",
                         BirthDate = DateTime.Parse("2005-01-09"),
                         PersonGender = Gender.Female
                     },

                     new Person()
                     {
                         Name = "John",
                         BirthDate = DateTime.Parse("2008-07-06"),
                         PersonGender = Gender.Male
                     },

                     new Person()
                     {
                         Name = "Jojo",
                         BirthDate = DateTime.Parse("2000-05-12"),
                         PersonGender = Gender.Other
                     },
             };

            Person? matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();

            return View(matchingPerson); //Views/Home/Details.cshtml
        }

        // STRONGLY TYPED VIEWS WITH MULTIPLE MODELS
        [Route("person-with-product")]
        public IActionResult PersonWithProduct() 
        {
            Person person = new Person()
            {
                Name = "Jojo",
                BirthDate = DateTime.Parse("2000-05-12"),
                PersonGender = Gender.Other
            };

            Product product = new Product()
            {
                ProductId = 1,
                ProductName = "Air Conditioner"
            };

            PersonProductWrapper wrapper = new PersonProductWrapper()
            {
                PersonData = person,
                ProductData = product
            };

            return View(wrapper);
        }
    }
}
