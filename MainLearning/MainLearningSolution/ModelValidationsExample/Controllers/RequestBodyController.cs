using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.CustomModelBinders;
using ModelValidationsExample.Models;

/*
 * CUSTOM MODEL BINDER
 * Ogniqualvolta si desideri performare complesse manipolazioni sui 'data types' al di fuori
 * della built-in data: come custom data types o strutture o enumerazioni
 * 
 * ESEMPIO:
 * Abbiamo una string value submittata come parte di una richiesta di un tipo 'BankAccount' equal to 'SavingsAccount';
 * basandoci sulla string value abbiamo da generare un corrispondente enumeration value, per questo tipo di operazioni
 * sarà necessario creare un 'Custom Model Binder'
 * 
 * CUSTOM MODEL BINDER PROVIDER
 * Supponiamo che si desideri di usare lo stesso model binder per tutte gli 'action methods' ovunque un tipo di model class sia usata
 * possiamo dichiararlo globally usando il 'binder provider'
 */

namespace ModelValidationsExample.Controllers
{
    public class RequestBodyController : Controller
    {
        [Route("register-body")]
        // necessario passare il tipo di custom model binder
        public IActionResult Index(/*[FromBody] 
        [ModelBinder(BinderType = typeof (PersonModelBinder))] <- Superfluo dopo impl del binding provider */ Person person )
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
