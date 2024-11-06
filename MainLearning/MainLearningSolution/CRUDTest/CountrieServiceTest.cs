using ServicesInterfaces;
using ServicesConcrete;
using System.Data;
using ServicesInterfaces.DTO;
using Xunit.Abstractions;

namespace CRUDTest
{
    public class CountrieServiceTest
    {
        private readonly ICountriesService? _countriesService;

        // TestOutputHelper 
        public CountrieServiceTest()
        {
            _countriesService = new CountriesService();
        }

        #region AddCountry
        [Fact]
        // Quando CountryAddRequest è null, dovrebbe restituire un ArgumentNullException
        public void AddCountry_NullCountry()
        {
            // Arrange
            CountryAddRequest? request = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
                // Act
                _countriesService?.AddCountry(request)
            );
        }

        [Fact]
        // Quando il CountryName è null, dovrebbe restituire ArgumentException 
        public void AddCountry_CountryNameIsNull()
        {
            // Arrange
            CountryAddRequest request = new CountryAddRequest();
            request.CountryName = null;

            // Assert
            Assert.Throws<ArgumentException>(() =>
                // Act
                _countriesService?.AddCountry(request)
            );
        }

        [Fact]
        // Quando il CountryName è duplicato, dovrebbe restituire ArgumentException
        public void AddCountry_DuplicatedCountryName()
        {
            // Arrange

            CountryAddRequest request1 = new CountryAddRequest()
            {
                CountryName = "Rome"
            };

            CountryAddRequest request2 = new CountryAddRequest()
            {
                CountryName = "Rome"
            };

            // Assert
            Assert.Throws<DuplicateNameException>(() =>
            {
                // Act
                _countriesService?.AddCountry(request1);
                _countriesService?.AddCountry(request2);
            }
            );
        }

        [Fact]
        // Quando fornisci il country name appropriato dovrebbe aggiungerlo alla lista già esistente
        public void AddCountry_ProperCountryDetails()
        {
            // Arrange
            CountryAddRequest request = new CountryAddRequest()
            {
                CountryName = "Japan"
            };

            // Act
            CountryResponse response = _countriesService.AddCountry(request);
            List<CountryResponse> countries_from_GetAllCountries = _countriesService.GetAllCountries();

            // Assert
            Assert.True(response.CountryID != Guid.Empty && response.CountryName is not null);
            Assert.Contains(response, countries_from_GetAllCountries);
        }
        #endregion

        #region GetAllCountries
        [Fact]
        public void GetAllCountries_EmptyList()
        {
            // Act
            List<CountryResponse> actual_country_response_list =
            _countriesService.GetAllCountries();

            // Assert
            Assert.Empty(actual_country_response_list);
        }

        [Fact]
        public void GetAllCountries_AddFewCountries()
        {
            // Arrange
            List<CountryAddRequest> county_request_list = new List<CountryAddRequest>()
            {
                new CountryAddRequest() { CountryName = "Italy" },
                new CountryAddRequest() { CountryName = "Greenland" }
            };

            // Act
            List<CountryResponse> countries_list_from_add_country = new List<CountryResponse>();

            foreach (CountryAddRequest country_request in county_request_list)
            {
                countries_list_from_add_country.Add(_countriesService.AddCountry(country_request));
            }

            List<CountryResponse> actualCountryResponseList = _countriesService.GetAllCountries();

            // legge ciascun elemento
            foreach (CountryResponse expected_country in countries_list_from_add_country)
            {
                // Assert
                Assert.Contains(expected_country, actualCountryResponseList);
            }
        }
        #endregion

        #region GetCountryByCountryID
        [Fact]
        // Se fornito un null come CountryID, dovrebbe ritornare un null come risposta 
        public void GetCountryByCountryID_NullCountryID()
        {
            //Arrange
            Guid? countryID = null;

            //Act
            CountryResponse? country_response_from_get_method = _countriesService.GetCountryByCountryID(countryID);

            //Assert
            Assert.Null(country_response_from_get_method);
        }

        [Fact]
        // Se fornito un valido country id, dovrebbe restituire il match dei dettagli del paese come oggetto CountryResponse 
        public void GetCountryByCountryID_ProperCountryID()
        {
            //Arrange (di default la lista sarà sempre vuota quindi necessario popolarla)
            CountryAddRequest? country_add_request = new CountryAddRequest() { CountryName = "China" };
            CountryResponse country_response_from_add = _countriesService.AddCountry(country_add_request);
            Guid id = country_response_from_add.CountryID;

            //Act
            CountryResponse? country_response_from_get = _countriesService.GetCountryByCountryID(id);

            //Assert
            Assert.Equal(country_response_from_add, country_response_from_get);
        }
        #endregion
    }
}
