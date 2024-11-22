using CsvHelper;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using RepositoryContracts;
using ServicesConcrete.Helpers;
using ServicesInterfaces;
using ServicesInterfaces.DTO;
using ServicesInterfaces.DTO.Enums;
using System.Data;
using System.Globalization;
using System.IO;

namespace ServicesConcrete
{
    /*
     * Essenziale indicare await quando i metodi a monte delle interfacce Service
     * diventano dei return type di tipo task
     */
    public class PersonsService : IPersonService
    {
        // private field
        private readonly IPersonsRepository _personsRepository;

        // constructor
        public PersonsService(IPersonsRepository personsRepository)
        {
            _personsRepository = personsRepository;
        }

        // Commentato una volta implementato Country come Proprietà nella Person entity
        //private PersonResponse ConvertPersonToPersonResponse(Person person)
        //{
        //    PersonResponse personResponse = person.ToPersonResponse();
        //    personResponse.Country = person.Country?.CountryName;
        //        //_countriesService.GetCountryByCountryID(person.CountryID)?.CountryName; 'pre' implementazione della proprietà Country nell'entità di Person
        //    return personResponse;
        //}

        public async Task<PersonResponse> AddPerson(PersonAddRequest? personAddRequest)
        {
            //check if PersonAddRequest is not null
            if (personAddRequest == null)
            {
                throw new ArgumentNullException(nameof(personAddRequest));
            }

            //Model validation
            ValidationHelper.ModelValidation(personAddRequest);

            //convert personAddRequest into Person type
            Person person = personAddRequest.ToPerson();

            //generate PersonID
            person.PersonID = Guid.NewGuid();

            //add person object to persons list, LINQ SQL
            await _personsRepository.AddPerson(person);

            // Stored procedure implementation
            // _db.sp_InsertPerson(person);

            //convert the Person object into PersonResponse type
            return person.ToPersonResponse();
        }

        public async Task<List<PersonResponse>> GetAllPersons()
        {
            // LINQ * SQL: Select * from persons 
            // NOTA: qua viene effettuata un'Entity Framework operation per recuperare il data da db ed assegnarla alla 'person'
            var persons = await _personsRepository.GetAllPersons();
            // metterà in confronto il CountryID di Person e il CountryID di Country, includendo l'oggetto
            // 'Country' raffigura il nome della proprietà e non il tipo

            // se non vogliamo caricare il navigation property data
            // var persons = _db.Persons.ToList();

            // NOTA: qua la 'person' possiede già i valori recuperati da un operazione precedente sul db,
            // il data si trova all'interno del codice quindi non sarà necessario richiamare l'asincronia
            return persons
                .Select(temp => temp.ToPersonResponse()).ToList();

            // By using stored_procedure, commented duo the adding of TIN properties in Person's entity
            //return _db.sp_GetAllPersons()
            //    .Select(temp => ConvertPersonToPersonResponse(temp)).ToList();
        }

        public async Task<PersonResponse?> GetPersonByPersonID(Guid? personID)
        {
            if (personID == null)
                return null;

            Person? person = await _personsRepository.GetPersonsByPersonID(personID.Value);

            if (person == null)
                return null;

            return person.ToPersonResponse();
        }

        public async Task<List<PersonResponse>> GetFilteredPerson(string searchBy, string? searchString)
        {
            List<Person> allPersons =
                searchBy
            switch
                {
                    nameof(PersonResponse.PersonName) =>
                        await _personsRepository.GetFilteredPersons(
                            temp => temp.PersonName.Contains(searchString/*, StringComparison.OrdinalIgnoreCase*/)), // in SQL operazione effettuatz di default

                    nameof(PersonResponse.Email) =>
                        await _personsRepository.GetFilteredPersons(
                            temp => temp.Email.Contains(searchString/*, StringComparison.OrdinalIgnoreCase*/)),

                    nameof(PersonResponse.DateOfBirth) =>
                        await _personsRepository.GetFilteredPersons(
                            temp => temp.DateOfBirth.Value.ToString("dd MMM yyyy").Contains(searchString/*, StringComparison.OrdinalIgnoreCase*/)),

                    nameof(PersonResponse.Gender) =>
                        await _personsRepository.GetFilteredPersons(
                            temp => temp.Gender.Contains(searchString/*, StringComparison.OrdinalIgnoreCase*/)),

                    nameof(PersonResponse.CountryID) =>
                        await _personsRepository.GetFilteredPersons(
                            temp => (temp.Country.CountryName).Contains(searchString/*, StringComparison.OrdinalIgnoreCase*/)),

                    nameof(PersonResponse.Address) =>
                        await _personsRepository.GetFilteredPersons(
                            temp => temp.Address.Contains(searchString/*, StringComparison.OrdinalIgnoreCase*/)),

                    _ => await _personsRepository.GetAllPersons()
                };

            return allPersons.Select(temp => temp.ToPersonResponse()).ToList();
        }

        public async Task<List<PersonResponse>> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy))
            {
                return allPersons;
            }

            List<PersonResponse> sortedPersons =
                (sortBy, sortOrder)
                switch
                {
                    ((nameof(PersonResponse.PersonName)), SortOrderOptions.ASC) =>
                      allPersons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                    ((nameof(PersonResponse.PersonName)), SortOrderOptions.DESC) =>
                        allPersons.OrderByDescending(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                    ((nameof(PersonResponse.Email)), SortOrderOptions.ASC) =>
                        allPersons.OrderBy(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                    ((nameof(PersonResponse.Email)), SortOrderOptions.DESC) =>
                        allPersons.OrderByDescending(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                    ((nameof(PersonResponse.DateOfBirth)), SortOrderOptions.ASC) =>
                        allPersons.OrderBy(temp => temp.Email).ToList(),

                    ((nameof(PersonResponse.DateOfBirth)), SortOrderOptions.DESC) =>
                        allPersons.OrderByDescending(temp => temp.DateOfBirth).ToList(),

                    ((nameof(PersonResponse.Age)), SortOrderOptions.ASC) =>
                        allPersons.OrderBy(temp => temp.Age).ToList(),

                    ((nameof(PersonResponse.Age)), SortOrderOptions.DESC) =>
                        allPersons.OrderByDescending(temp => temp.Age).ToList(),

                    ((nameof(PersonResponse.Gender)), SortOrderOptions.ASC) =>
                        allPersons.OrderBy(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

                    ((nameof(PersonResponse.Gender)), SortOrderOptions.DESC) =>
                        allPersons.OrderByDescending(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

                    ((nameof(PersonResponse.Country)), SortOrderOptions.ASC) =>
                        allPersons.OrderBy(temp => temp.Country).ToList(),

                    ((nameof(PersonResponse.Country)), SortOrderOptions.DESC) =>
                        allPersons.OrderByDescending(temp => temp.Country).ToList(),

                    ((nameof(PersonResponse.Address)), SortOrderOptions.ASC) =>
                        allPersons.OrderBy(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

                    ((nameof(PersonResponse.Address)), SortOrderOptions.DESC) =>
                        allPersons.OrderByDescending(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

                    ((nameof(PersonResponse.ReceiveNewsLetters)), SortOrderOptions.ASC) =>
                        allPersons.OrderBy(temp => temp.ReceiveNewsLetters).ToList(),

                    ((nameof(PersonResponse.ReceiveNewsLetters)), SortOrderOptions.DESC) =>
                        allPersons.OrderByDescending(temp => temp.ReceiveNewsLetters).ToList(),

                    _ => allPersons
                };

            return sortedPersons;
        }

        public async Task<PersonResponse> UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            if (personUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(personUpdateRequest));
            }

            ValidationHelper.ModelValidation(personUpdateRequest);

            // get matching person object to update
            Person? matchingPerson = await _personsRepository.GetPersonsByPersonID(personUpdateRequest.PersonID);

            if (matchingPerson == null)
            {
                throw new ArgumentException("Given person ID dosn't exist");
            }

            //update all details
            matchingPerson.PersonName = personUpdateRequest.PersonName;
            matchingPerson.Email = personUpdateRequest.Email;
            matchingPerson.Gender = personUpdateRequest.Gender.ToString();
            matchingPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
            matchingPerson.CountryID = personUpdateRequest.CountryID;
            matchingPerson.Address = personUpdateRequest.Address;
            matchingPerson.ReceiveNewsLetters = personUpdateRequest.ReceiveNewsLetters;

            await _personsRepository.UpdatePerson(matchingPerson);

            return matchingPerson.ToPersonResponse();
        }

        public async Task<bool> DeletePerson(Guid? personID)
        {
            if (personID == null)
            {
                throw new ArgumentNullException(nameof(personID));
            }

            Person? matchingPerson = await _personsRepository.GetPersonsByPersonID(personID.Value);

            if (matchingPerson == null)
                return false;

            await _personsRepository.DeletePersonByPersonID(personID.Value);

            return true;
        }

        public async Task<MemoryStream> GetPersonsCSV() 
        { 
            //MemoryStream usa la ram di memoria, salva un file anziché su memoria fisica su ram virtuale e velocizza
            MemoryStream memoryStream = new MemoryStream();
            //Streamwriter scriverà il contenuto in un oggetto memorystream
            StreamWriter streamWriter = new StreamWriter(memoryStream);
            //CultureInfo necessaria ad indicare con quale punteggiatura sarà riconosciuto,
            //leaveOpen indica che dopo la scrittura, nella conversione del flusso del file sarà necessario
            //ripartire dall'inizio (es. dopo scrittura di 100 byte bisogna ripartire dall'inizio per scrivere gli stessi dati)
            CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture, leaveOpen: true);

            csvWriter.WriteHeader<PersonResponse>(); //PersonID,PersonName... Colonna nome
            csvWriter.NextRecord(); // per spostarsi nella successiva linea di codice(aggiunge una barra rovesciata)

            List<Person> persons = await _personsRepository.GetAllPersons();

            await csvWriter.WriteRecordsAsync(persons); //1,abc,....

            //Dopo aver scritto tutte le persone il cursore sarà in attesa internamente alla fine del flusso di memoria
            //è necessario riportalo alla partenza, indicando la posizione 0
            memoryStream.Position = 0;

            //restituisco poi il memoryStream
            return memoryStream;
        }
    }
}
