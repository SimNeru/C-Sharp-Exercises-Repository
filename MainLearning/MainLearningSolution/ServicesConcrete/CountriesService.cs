using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using ServicesInterfaces;
using ServicesInterfaces.DTO;
using System.Data;

namespace ServicesConcrete
{
    /*
     * Essenziale indicare await quando i metodi a monte delle interfacce Service
     * diventano dei return type di tipo task
     */
    public class CountriesService : ICountriesService
    {
        // private field
        private readonly ICountriesRepository _countriesRepository;

        // constructor
        public CountriesService(ICountriesRepository personsDBContext)
        {
            _countriesRepository = personsDBContext;
        }

        // Ogniqualvolta uno sviluppatore dovesse implementare una nuova funzionalità lo farà da qua
        public async Task<CountryResponse> AddCountry(CountryAddRequest? countryAddRequest)
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
            if (await _countriesRepository.GetCountryByCountryName(countryAddRequest.CountryName) != null)
            {
                throw new DuplicateNameException("Given country name already exist");
            }

            // Generate countryID
            country.CountryID = Guid.NewGuid();

            // Aggiunge oggetto country nella lista
            await _countriesRepository.AddCountry(country);

            // Uso dell'extension method
            return country.ToCountryResponse();
        }

        public async Task<List<CountryResponse>> GetAllCountries()
        {
            return (await _countriesRepository.GetAllCountries()).Select(x => x.ToCountryResponse()).ToList();
        }

        public async Task<CountryResponse?> GetCountryByCountryID(Guid? countryID)
        {
            if (countryID == null)
            {
                return null;
            }

            Country? result = await _countriesRepository.GetCountryByCountryID(countryID.Value);

            if (result == null)
            {
                return null;
            }
            return result.ToCountryResponse();
        }
    }

}
