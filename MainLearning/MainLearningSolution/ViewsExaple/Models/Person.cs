namespace ViewsExaple.Models
{
    public class Person
    {
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender PersonGender { get; set; }
    }

    public enum Gender 
    {
        Male,
        Female,
        Other
    }
}
