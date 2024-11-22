using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// Domain Model for Country
    /// </summary>
    public class Country
    {
        [Key]
        public Guid CountryID { get; set; }

        [StringLength(40)] //nvarchar(40)
        public string? CountryName { get; set; }

        // Per definire relazione chiavi tra due entità tabelle
        public virtual ICollection<Person> Persons { get; set; }
    }
}
