using System.ComponentModel.DataAnnotations;

namespace ServicesConcrete.Helpers
{
    public class ValidationHelper
    {
        // Se passato un'oggetto vogliamo che questo metodo lo validi
        internal static void ModelValidation(object obj)
        {
            // Model Validation
            // Da forinire il modelObject da validare 'personAddRequest'
            ValidationContext validationContext = new ValidationContext(obj);

            // Lista che raccoglie i validation errors
            List<ValidationResult> validationResults = new List<ValidationResult>();

            // Da richiamare classe Validator, se ignorato l'ultimo booleano, validerà solo i 'Required'
            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            if (!isValid)
            {
                throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
            }
        }
    }
}
