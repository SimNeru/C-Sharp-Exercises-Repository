using Entities;

namespace RepositoryContracts
{
    /// <summary>
    /// Represents data access logic for managing Country entity
    /// </summary>
    public interface ICountriesRepository
    {
        /// <summary>
        /// Adds a new country object to the data store
        /// </summary>
        /// <param name="country">Country object to add</param>
        /// <returns>Returns the country object after adding it to the data store
        /// </returns>
        Task<Country> AddCountry (Country country);

        /// <summary>
        /// Return all countries in data store
        /// </summary>
        /// <returns>All countries from the table</returns>
        Task<List<Country>> GetAllCountries();

        /// <summary>
        /// Return the country data with a matching provided id
        /// </summary>
        /// <param name="id">CountryID to search</param>
        /// <returns>The country with the matching id from the table</returns>
        Task<Country?> GetCountryByCountryID(Guid id);

        /// <summary>
        /// Returns a country object based on the given country name
        /// </summary>
        /// <param name="countryName">Country name to search</param>
        /// <returns>Matching country or null</returns>
        Task<Country?> GetCountryByCountryName (string countryName);

    }
}
