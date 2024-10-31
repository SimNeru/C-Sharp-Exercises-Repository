using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
    [Route("register")]
    public class HomeController : Controller
    {
        // Attributo BIND specifica quali proprietà vogliamo includere in un 'model binding'
        // cosìcché le rimanenti proprietà non verranno 'bindate' (di default lo sono tutte),
        // utile per evitare di riportare proprietà indesiderate 

        /* esempio:
         * in un form di registrazione, con 10 campi o 10 proprietà da 'submittare'
         * ma se un hacker dovesse 'submittare' un maggior numero di proprietà inaspettate
         * postando dati sensibili o indesiderati, con il bind attribute
         * solo le proprietà interessato saranno submittate
         */

        // * [BindNever] utilizzabile in alternativa *

        /* nameof operator:
         * riflette il nome dell'attuale proprietà che viene passata nelle parentesi
         * consentirà dinamicamente di poter fare riferimento al nome stringa dell'attributo, in caso
         * uno dovesse cambiare il 'Property Name' in futuro verrà riflettuto senza necessità di doverlo cambiare
         */

        public IActionResult Index([Bind(
            nameof(Person.PersonName),
            nameof(Person.Email),
            nameof(Person.Password),
            nameof(Person.ConfirmPassword))]
            Person person
            )
        {
            // controllo a monte per verificare dati in entrata siano corretti
            if (!ModelState.IsValid) 
            {
                // !!!!!SHORTCUT del codice seguente..
                /* string errors = string.Join("\n",
                    ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(err => err.ErrorMessage).ToList()); */

                // inizializzo lista di errori
                List<string> errorsList = new List<string>();

                // ciclo per ciascuno 'valore' contenuto nei ModelState.Values
                foreach (var value in ModelState.Values) 
                {
                    // ciclo ciascun errore generato che vado ad aggiungere alla lista di errori
                    foreach ( var error in value.Errors) 
                    {
                        errorsList.Add(error.ErrorMessage);
                    }
                }
                // join concatena i membri di una IEnumerables, di tipo stringa
                string errors = string.Join("\n", errorsList);
                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
