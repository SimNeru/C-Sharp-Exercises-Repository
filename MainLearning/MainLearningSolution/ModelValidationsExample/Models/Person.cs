using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using ModelValidationsExample.CustomValidators;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelValidationsExample.Models
{
    public class Person : IValidatableObject
    {
        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z]$", ErrorMessage = "{0} should contain only alphabets, space and dot")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
        [Required(ErrorMessage = "{0} can't be empty or null")]
        public string? Email {  get; set; }

        [Phone(ErrorMessage = "{0} should contain 10 digits")]
        // [ValidateNever] quando non vogliamo che una proprietà venga mai validata
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
        [Display(Name = "Re-enter Password")]
        public string? ConfirmPassword { get; set; }
        
        [Range(0,999.99, ErrorMessage = "{0} should be between {2}$ and {1}$")]
        public double? Price { get; set; }

        // Custom validator importato attraverso MinimumYearValidator
        [MinimumYearValidator(2005)]
        // [BindNever] in caso non venga usato [Bind] per specificare quale vogliamo che vengano 'bindati' e quali no,
        // possiamo usare quest'altra annotazione per specificare solo quelli che non vogliamo che siano 'bindati'
        public DateTime? DateOfBirth { get; set; }

        // Custom validator multiple properties
        [Required]
        public DateTime? FromDate { get; set; }

        [Required]
        [DateRangeValidator("FromDate", ErrorMessage = "'From Date' should be older than or equal to 'To date'")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }

        public List<string>? Tags { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"- Person object -" +
                $"\nname: {PersonName} " +
                $"\nemail: {Email} " +
                $"\nphone: {Phone} " +
                $"\npassword: {Password} " +
                $"\npassword confirm: {ConfirmPassword} " +
                $"\nprice: {Price}";
        }

        public Person() { }

        // dopo implementazione IValidableObject in questo metodo possiamo definire le nostre logiche
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.HasValue == false && Age.HasValue == false) 
            {
                // 'yield' è una keyword che consente il ritorno di 'molteplici values' che saranno automaticamente convertiti in IEnumerables 
                yield return new ValidationResult("Either of Date of Birth or Age must be supplied", new[] { nameof(Age) });
            }

            /* PUO' RESTITUIRE PIU' DI UN VALORE 
             * 
             * if(...)
             * {
             *      return new ValidationResult();
             * }
             */
        }
    }
}
