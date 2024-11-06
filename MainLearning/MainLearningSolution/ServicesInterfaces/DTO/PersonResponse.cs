using Entities;
using ServicesInterfaces.DTO.Enums;

namespace ServicesInterfaces.DTO
{
    public class PersonResponse
    {
        public Guid PersonID { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }
        public double? Age { get; set; }

        /// <summary>
        /// Compares the current object data with the parameter object
        /// </summary>
        /// <param name="obj">The PersonResponse Object to compare</param>
        /// <returns>True or false, indicating whether all person details are matched with the specified parameter object</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj.GetType() != typeof(PersonResponse)) return false;

            PersonResponse person = (PersonResponse)obj;
            return PersonID == person.PersonID && PersonName == person.PersonName && Email == person.Email && DateOfBirth == person.DateOfBirth && Gender == person.Gender && CountryID == person.CountryID && Address == person.Address && ReceiveNewsLetters == person.ReceiveNewsLetters;
        }

        public override string ToString()
        {
            return
                "{\n" +
                $"  Person ID: {PersonID},\n" +
                $"  Person Name: {PersonName},\n" +
                $"  Email: {Email},\n" +
                $"  Date Of Birth: {DateOfBirth?.ToString("dd MMM yyyy")},\n" +
                $"  Gender: {Gender},\n" +
                $"  CountryID: {CountryID},\n" +
                $"  Address: {Address},\n" +
                $"  Received News Letter: {ReceiveNewsLetters}\n" +
                "}\n";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public PersonUpdateRequest ToPersonUpdateRequest() 
        {
            return new PersonUpdateRequest()
            {
                PersonID = PersonID,
                PersonName = PersonName,
                Email = Email,
                DateOfBirth = DateOfBirth,
                CountryID = CountryID,
                Gender = (GenderOptions)Enum.Parse(typeof(GenderOptions), Gender, true),
                Address = Address,
                ReceiveNewsLetters = ReceiveNewsLetters
            };
        }
    }

    public static class PersonExtensions
    {
        /// <summary>
        /// An extension method to convert an object of Person class into PersonResponse class
        /// </summary>
        /// <param name="person">The Person object to convert</param>
        /// /// <returns>Returns the converted PersonResponse object</returns>
        public static PersonResponse ToPersonResponse(this Person person)
        {
            //person => convert => PersonResponse
            return new PersonResponse()
            {
                PersonID = person.PersonID,
                PersonName = person.PersonName,
                Email = person.Email,
                DateOfBirth = person.DateOfBirth,
                ReceiveNewsLetters = person.ReceiveNewsLetters,
                Address = person.Address,
                CountryID = person.CountryID,
                Gender = person.Gender,
                Age = (person.DateOfBirth != null) ? Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25) : null
            };
        }
    }
}
