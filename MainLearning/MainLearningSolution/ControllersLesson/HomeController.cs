using Microsoft.AspNetCore.Mvc;
using ControllersLesson.Models;

namespace ControllersLesson
{
    // In ordine ad una classe per essere identificata come Controller necessario fornirlo come suffisso
    // Es: EsempioController, il compiler di asp.netcore poi la identificherà automaticamente

    // definisco l'attribute routing

    [Controller] // opzionale se la classe è fornita del suffisso
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        //in runtime ogniqualvolta avviene un match con l'url richiesto
        // asp.net core creerà un oggetto per il questa classe
        [Route("sayhello")]
        [Route("/")]
        public ContentResult Index() // convenzione nome primo metodo
        {
            //return new ContentResult()
            //{
            //    Content = "Hello from Index",
            //    ContentType = "text/plain"
            //};

            // per poter usare il metodo Content(data, tipo del data), necessario prima estendere alla classe Controller
            return Content("<h1>Welcome</h1> <h2>Hello from Index</h2>", "text/html");
        }

        [Route("person")]
        public JsonResult Person()
        {
            // json andrebbe scritto così, interviene però una classe che aiuta
            // return "{ \"\"key: \"value\"}";
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Pino",
                LastName = "Rossi",
                Age = 50
            };
            return new JsonResult(person);
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Hello from contact";
        }

        // IActionResult come return type, interfaccia padre
        // per tutte le azioni di restituzione di sottotipi delle 'result'
        
        [Route("file-virtual-download")]
        public IActionResult FileDownloadVirtual()
        {
            // invece di restituire un nuovo oggetto tutte le volte
            // queste classi consentono esclusivamente una sintassi più "sugar" shortcut

            // return new VirtualFileResult("/sample.pdf", "application/pdf");

            return File("/sample.pdf", "application/pdf");
        }
        
        [Route("file-physical-download")]
        public PhysicalFileResult FileDownloadPhysical()
        {
            // return new PhysicalFileResult(@"C:\Users\TI-LT2302\Documents\sample.pdf", "application/pdf");
            return PhysicalFile(@"C:\Users\TI-LT2302\Documents\sample.pdf", "application/pdf");
        }

        [Route("file-content-download")]
        public FileContentResult FileDownloadContent()
        {
            // un metodo che formatta in formato di bytes un file
            byte[]? bytes = System.IO.File.ReadAllBytes(@"C:\Users\TI-LT2302\Documents\sample.pdf");
            // return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");
        }
    }
}
