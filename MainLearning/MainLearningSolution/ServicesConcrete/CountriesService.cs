using Entities;
using ServicesInterfaces;
using ServicesInterfaces.DTO;
using System.Data;

namespace ServicesConcrete
{
    public class CountriesService : ICountriesService
    {
        // private field
        private readonly List<Country> _countries;

        // constructor
        public CountriesService()
        {
            _countries = new List<Country>();
        }

        // Ogniqualvolta uno sviluppatore dovesse implementare una nuova funzionalità lo farà da qua
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            /* TO DOES:
            - Check if "countryAddRequest" is not null

            - Validate all properties of "countryAddRequest"

            - Convert "countryAddRequest" from "CountryAddRequest" type to "Country"

            - Generate a new Country ID

            - Add it into List<Country>

            - Return CountryResponse object with generated CountryID
            */

            // Validation: countryAddRequest parameter can't be null
            ArgumentNullException.ThrowIfNull(countryAddRequest, $"{countryAddRequest} countryAddRequest is null");
            // Più lento? 
            //if (countryAddRequest == null)
            //{
            //    throw new ArgumentNullException(nameof(countryAddRequest));
            //}

            // Validation: countryAddRequest parameter can't be null
            if (countryAddRequest.CountryName == null) 
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            // Converte oggetto da CountryAddRequest al Country type
            Country country = countryAddRequest.ToCountry();

            // Validation: countryName can't duplicate
            if (_countries.Any(temp => temp.CountryName == countryAddRequest.CountryName))
            {
                throw new DuplicateNameException("Given country name already exist");
            }

            // Generate countryID
            country.CountryId = Guid.NewGuid();

            // Aggiunge oggetto country nella lista
            _countries.Add(country);

            // Uso dell'extension method
            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
            return _countries.Select(x => x.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryID(Guid? countryID)
        {
            if (countryID == null) 
            {
                return null;
            }

            Country? result = _countries?.FirstOrDefault(x => x.CountryId == countryID);

            if (result == null)
            {
                return null;
            } 

                return result.ToCountryResponse();
            }
        }
    
}
