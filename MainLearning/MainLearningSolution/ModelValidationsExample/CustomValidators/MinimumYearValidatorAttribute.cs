using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        public string DefaultErrorMessage { get; set; } = "Date of birth should not be newer than Jan 01, {0}";

        // parameter less constructor
        public MinimumYearValidatorAttribute()
        {
        }

        // parametrized constructor
        public MinimumYearValidatorAttribute(int minimumYear)
        { 
            MinimumYear = minimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= 2000)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
                }
                else 
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
