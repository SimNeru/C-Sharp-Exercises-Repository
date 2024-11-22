using AutoFixture;
using AutoFixture.Kernel;
using Entities;
using EntityFrameworkCoreMock;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Moq;
using RepositoryContracts;
using ServicesConcrete;
using ServicesInterfaces;
using ServicesInterfaces.DTO;
using ServicesInterfaces.DTO.Enums;
using System.Linq.Expressions;
using Xunit.Abstractions;

namespace CRUDTest
{
    public class PersonServiceTest
    {
        //private fields
        private readonly IPersonService _personService;
        private readonly ICountriesService _countriesService;

        private readonly Mock<IPersonsRepository> _personsRepositoryMock; // Used to mock the methods of IPersoneRepository
        private readonly IPersonsRepository _personsRepository; // Represent the mocked object that was created by Mock

        private readonly ITestOutputHelper _testOutputHelper;
        // Autofixture Model
        private readonly IFixture _fixture;

        #region Constructor
        public PersonServiceTest(ITestOutputHelper testOutputHelper)
        {
            _fixture = new Fixture(); // Fixture creazione dummy objects
            var countriesInitialData = new List<Country>() { };
            var personsInitialData = new List<Person>() { };

            _personsRepositoryMock = new Mock<IPersonsRepository>();
            _personsRepository = _personsRepositoryMock.Object;

            DbContextMock<ApplicationDBContext> dbContextMock = new DbContextMock<ApplicationDBContext>(
               new DbContextOptionsBuilder<ApplicationDBContext>().Options
               );

            ApplicationDBContext dbContext = dbContextMock.Object;

            dbContextMock.CreateDbSetMock(temp => temp.Countries, countriesInitialData);
            dbContextMock.CreateDbSetMock(temp => temp.Persons, personsInitialData);

            _countriesService = new CountriesService(null);
            _personService = new PersonsService(_personsRepository);

            _testOutputHelper = testOutputHelper;
        }
        #endregion

        #region AddPerson

        //When we supply null value as PersonAddRequest, it should throw ArgumentNullException
        [Fact]
        public async Task AddPerson_NullPerson_ToBeArgumentNullException()
        {
            //Arrange
            PersonAddRequest? personAddRequest = null;

            //Act
            /*await Assert.ThrowsAsync<ArgumentNullException>*/ // commented after implementation of Fluent Assertions
            Func<Task> action = async () =>
            {
                await _personService.AddPerson(personAddRequest);
            };

            //action.Invoke(); invocabile manualmente in questo modo ma vogliamo farlo tramite le Fluent Assertions
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        //When we supply null value as PersonName, it should throw ArgumentException
        [Fact]
        public async Task AddPerson_PersonNameIsNull_ToBeArgumentException()
        {
            // Arrange
            PersonAddRequest? personAddRequest = /* new PersonAddRequest() { PersonName = null };*/
                _fixture.Build<PersonAddRequest>()
                .With(temp => temp.PersonName, null as string)
                .Create();

            Person person = personAddRequest.ToPerson();

            // When PersonsRepository.AddPerson is called, it has to return the same "person" object
            _personsRepositoryMock.Setup(temp => temp.AddPerson(It.IsAny<Person>()))
                .ReturnsAsync(person);

            // Assert
            Func<Task> action =
            async () =>
            {
                // Act
                await _personService.AddPerson(personAddRequest);
            };

            await action.Should().ThrowAsync<ArgumentException>();
        }

        //When we supply proper person details, it should insert the person into the persons list; and it should return an object of PersonResponse, which includes with the newly generated person id
        [Fact]
        public async Task AddPerson_FullPersonDetails_ToBeSuccessful()
        {
            // Arrange
            PersonAddRequest? personAddRequest = _fixture.Build<PersonAddRequest>()
                .With(temp => temp.Email, "someone@mail.com")
                .Create();

            Person person = personAddRequest.ToPerson();

            PersonResponse person_response_expected = person.ToPersonResponse();

            // If supplied any argument value to addPerson method, it should return the same return value
            _personsRepositoryMock.Setup(temp => temp.AddPerson(It.IsAny<Person>())).ReturnsAsync(person);

            // MOCKATA con AutoFixture
            //new PersonAddRequest() { 
            //    PersonName = "Person name...", 
            //    Email = "person@example.com", 
            //    Address = "sample address", 
            //    CountryID = Guid.NewGuid(), 
            //    Gender = GenderOptions.Male, 
            //    DateOfBirth = DateTime.Parse("2000-01-01"), 
            //    ReceiveNewsLetters = true 
            //}; 

            // Act
            PersonResponse person_response_from_add = await _personService.AddPerson(personAddRequest);
            person_response_expected.PersonID = person_response_from_add.PersonID;

            // Assert
            // Assert.True(person_response_from_add.PersonID != Guid.Empty);
            person_response_from_add.PersonID.Should().NotBe(Guid.Empty);

            person_response_from_add.Should().Be(person_response_expected);
        }
        #endregion

        #region GetPersonByPersonID

        // If we supply null as PersonID, it should return null as PersonResponse
        [Fact]
        public async Task GetPersonByPersonID_NullPersonID_ToBeNull()
        {
            // Arrange
            Guid? personID = null;

            // Act
            PersonResponse? person_response_from_get = await _personService.GetPersonByPersonID(personID);

            // Assert
            // Assert.Null(person_response_from_get);
            person_response_from_get.Should().BeNull();
        }


        //If we supply a valid person id, it should return the valid person details as PersonResponse object
        [Fact]
        public async Task GetPersonByPersonID_WithPersonID_ToBeSuccessful()
        {
            // Arrange
            /*CountryAddRequest country_request =
            //    // new CountryAddRequest() { CountryName = "Canada" };
            //    _fixture.Create<CountryAddRequest>();
            // CountryResponse country_response = await _countriesService.AddCountry(country_request);*/

            Person person =
                /*new PersonAddRequest() { 
                //    PersonName = "person name...", 
                //    Email = "email@sample.com", 
                //    Address = "address", 
                //    CountryID = country_response.CountryID, 
                //    DateOfBirth = DateTime.Parse("2000-01-01"), 
                //    Gender = GenderOptions.Male, 
                //    ReceiveNewsLetters = false };*/
                _fixture.Build<Person>()
                .With(temp => temp.Email, "email@sample.com")
                .With(temp => temp.Country, null as Country)
                .Create();

            PersonResponse person_response_expected = person.ToPersonResponse();

            _personsRepositoryMock.Setup(temp =>
            temp.GetPersonsByPersonID(It.IsAny<Guid>()))
            .ReturnsAsync(person);

            // Act
            PersonResponse? person_response_from_get = await _personService.GetPersonByPersonID(person.PersonID);

            // Assert
            // Assert.Equal(person_response_from_add, person_response_from_get);
            person_response_from_get.Should().Be(person_response_expected);

            // se dà errori
            // person_response_from_get.Should().Be(person_response_from_add);
        }

        #endregion

        #region GetAllPersons

        // The GetAllPersons() should return an empty list by default
        [Fact]
        public async Task GetAllPersons_EmptyList()
        {
            // Arrange
            var persons = new List<Person>();
            _personsRepositoryMock.Setup(temp => temp.GetAllPersons())
                .ReturnsAsync(persons);

            // Act
            List<PersonResponse> persons_from_get = await _personService.GetAllPersons();

            // Assert
            // Assert.Empty(persons_from_get);
            persons_from_get.Should().BeEmpty();
        }

        //First, we will add few persons; and then when we call GetAllPersons(), it should return the same persons that were added
        [Fact]
        public async Task GetAllPersons_WithFewPersons_ToBeSuccessful()
        {
            //Arrange
            List<Person> persons = new List<Person>()
            {
                _fixture.Build<Person>()
                .With(temp => temp.Email, "email1@sample.com")
                .With(temp => temp.Country, null as Country) // nullo perché crea circular reference
                .Create(),
                _fixture.Build<Person>()
                .With(temp => temp.Email, "email2@sample.com")
                .With(temp => temp.Country, null as Country)
                .Create(),
                _fixture.Build<Person>()
                .With(temp => temp.Email, "email3@sample.com")
                .With(temp => temp.Country, null as Country)
                .Create(),
            };

            List<PersonResponse> person_response_list_expected_list = persons.Select(temp => temp.ToPersonResponse()).ToList();

            // print person_response_list_from_add
            _testOutputHelper.WriteLine(" *** Expected *** ");
            foreach (PersonResponse temp in person_response_list_expected_list)
            {
                _testOutputHelper.WriteLine(temp.ToString());
            }

            _personsRepositoryMock.Setup(temp => temp.GetAllPersons()).ReturnsAsync(persons);

            //Act
            List<PersonResponse> persons_list_from_get = await _personService.GetAllPersons();

            // print person_list_from_get
            _testOutputHelper.WriteLine("*** Result ***");
            foreach (PersonResponse temp in persons_list_from_get)
            {
                _testOutputHelper.WriteLine(temp.ToString());
            }

            //Assert
            //foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            //{
            //    Assert.Contains(person_response_from_add, persons_list_from_get);
            //}

            persons_list_from_get.Should().BeEquivalentTo(person_response_list_expected_list);
        }
        #endregion

        #region GetFilteredPersons
        /* If the search text is empty and search is PersonName, it should return all person */
        [Fact]
        public async Task GetFilteredlPersons_EmptySearchText_ToBeSuccessful()
        {
            //Arrange
            List<Person> persons = new List<Person>()
            {
                _fixture.Build<Person>()
                .With(temp => temp.Email, "email1@sample.com")
                .With(temp => temp.Country, null as Country) // nullo perché crea circular reference
                .Create(),
                _fixture.Build<Person>()
                .With(temp => temp.Email, "email2@sample.com")
                .With(temp => temp.Country, null as Country)
                .Create(),
                _fixture.Build<Person>()
                .With(temp => temp.Email, "email3@sample.com")
                .With(temp => temp.Country, null as Country)
                .Create(),
            };

            List<PersonResponse> person_response_list_expected = persons.Select(temp => temp.ToPersonResponse()).ToList();

            // print person_response_list_from_add
            _testOutputHelper.WriteLine(" *** Expected *** ");
            foreach (PersonResponse temp in person_response_list_expected)
            {
                _testOutputHelper.WriteLine(temp.ToString());
            }

            _personsRepositoryMock.Setup(temp => temp.GetFilteredPersons(It.IsAny<Expression<Func<Person, bool>>>()))
                .ReturnsAsync(persons);

            //Act
            List<PersonResponse>? persons_list_from_search = await _personService.GetFilteredPerson(nameof(PersonResponse.PersonName), "");

            // print person_list_from_get
            _testOutputHelper.WriteLine("*** Result ***");
            foreach (PersonResponse temp in persons_list_from_search)
            {
                _testOutputHelper.WriteLine(temp.ToString());
            }

            //  Assert
            //  foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            //  {
            //    Assert.Contains(person_response_from_add, persons_list_from_search);
            //  }

            persons_list_from_search.Should().BeEquivalentTo(person_response_list_expected);
        }

        /* First we will add few persons; and then we will search based on person name with some search string */
        [Fact]
        public async Task GetFilteredlPerson_SearchByPersonName_ToBeSuccessfull()
        {
            //Arrange
            List<Person> persons = new List<Person>()
            {
                _fixture.Build<Person>()
                .With(temp => temp.Email, "email1@sample.com")
                .With(temp => temp.Country, null as Country)
                .Create(),
                _fixture.Build<Person>()
                .With(temp => temp.Email, "email2@sample.com")
                .With(temp => temp.Country, null as Country)
                .Create(),
                _fixture.Build<Person>()
                .With(temp => temp.Email, "email3@sample.com")
                .With(temp => temp.Country, null as Country)
                .Create(),
            };

            List<PersonResponse> person_response_list_expected = persons.Select(temp => temp.ToPersonResponse()).ToList();

            _testOutputHelper.WriteLine(" *** Expected *** ");
            foreach (PersonResponse temp in person_response_list_expected)
            {
                _testOutputHelper.WriteLine(temp.ToString());
            }

            _personsRepositoryMock.Setup(temp => temp.GetFilteredPersons(It.IsAny<Expression<Func<Person, bool>>>()))
                .ReturnsAsync(persons);

            //Act
            List<PersonResponse>? persons_list_from_search = await _personService.GetFilteredPerson(nameof(PersonResponse.PersonName), "ma");

            _testOutputHelper.WriteLine("*** Result ***");
            foreach (PersonResponse temp in persons_list_from_search)
            {
                _testOutputHelper.WriteLine(temp.ToString());
            }

            persons_list_from_search.Should().BeEquivalentTo(person_response_list_expected);
        }
        #endregion

        #region GetSortedPersons
        // When we sort based on PersonName in DESC, should return person list in descending on PersonName
        [Fact]
        public async Task GetSortedPersons_ToBeSuccessful()
        {
            // Arrange
            List<Person> persons = new List<Person>()
            {
                _fixture.Build<Person>()
                .With(temp => temp.Email, "email1@sample.com")
                .With(temp => temp.Country, null as Country) // nullo perché crea circular reference
                .Create(),
                _fixture.Build<Person>()
                .With(temp => temp.Email, "email2@sample.com")
                .With(temp => temp.Country, null as Country)
                .Create(),
                _fixture.Build<Person>()
                .With(temp => temp.Email, "email3@sample.com")
                .With(temp => temp.Country, null as Country)
                .Create(),
            };

            List<PersonResponse> person_response_list_expected = persons.Select(temp => temp.ToPersonResponse()).ToList();

            _personsRepositoryMock.Setup(temp => temp.GetAllPersons()).ReturnsAsync(persons);

            // print person_response_list_from_expected
            _testOutputHelper.WriteLine(" *** Before *** ");
            foreach (PersonResponse temp in person_response_list_expected)
            {
                _testOutputHelper.WriteLine(temp.ToString());
            }

            List<PersonResponse> allPersons = await _personService.GetAllPersons();

            // Act
            List<PersonResponse>? persons_list_from_sort = await _personService.GetSortedPersons(allPersons, nameof(PersonResponse.PersonName), SortOrderOptions.DESC);

            // print person_list_from_sort
            _testOutputHelper.WriteLine("*** After sort ***");
            foreach (PersonResponse temp in persons_list_from_sort)
            {
                _testOutputHelper.WriteLine(temp.ToString());
            }

            // Assert
            persons_list_from_sort.Should().BeInDescendingOrder(temp => temp.PersonName);
        }
        #endregion

        #region UpdatePerson
        // When we supply null as PersonUpdateRequest, it should throw ArgumentNullException
        [Fact]
        public async Task UpdatePerson_NullPerson_ToBeArgumentNullException()
        {
            // Arrange 
            PersonUpdateRequest person_update_request = null;

            Func<Task> action = (async () =>
                // Act
                await _personService.UpdatePerson(person_update_request)
            );

            // Assert
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        // Supply an invalid person id, it throw an ArgumentException
        [Fact]
        public async Task UpdatePerson_InvalidPersonID_ToBeArgumentException()
        {
            // Arrange 
            PersonUpdateRequest? person_update_request = _fixture.Build<PersonUpdateRequest>()
                .Create();

            // Assert
            Func<Task> action = (async () =>
                // Act
                await _personService.UpdatePerson(person_update_request)
            );

            await action.Should().ThrowAsync<ArgumentException>();
        }

        // When PersonName is null, it should throw ArgumentException
        [Fact]
        public async Task UpdatePerson_PersonNameIsNull_ToBeArgumentException()
        {
            //Arrange
            Person person = _fixture.Build<Person>()
             .With(temp => temp.PersonName, null as string)
             .With(temp => temp.Email, "someone@example.com")
             .With(temp => temp.Country, null as Country)
             .With(temp => temp.Gender, "Male")
             .Create();

            PersonResponse person_response_from_add = person.ToPersonResponse();

            PersonUpdateRequest person_update_request = person_response_from_add.ToPersonUpdateRequest();


            //Act
            var action = async () =>
            {
                await _personService.UpdatePerson(person_update_request);
            };

            //Assert
            await action.Should().ThrowAsync<ArgumentException>();
        }

        // First, add a new person and try to update the person name and email
        [Fact]
        public async Task UpdatePerson_PersonFullDetailsUpdate()
        {
            //Arrange
            Person person = _fixture.Build<Person>()
             .With(temp => temp.Email, "someone@example.com")
             .With(temp => temp.Country, null as Country)
             .With(temp => temp.Gender, "Male")
             .Create();

            PersonResponse person_response_expected = person.ToPersonResponse();

            PersonUpdateRequest person_update_request = person_response_expected.ToPersonUpdateRequest();

            _personsRepositoryMock
             .Setup(temp => temp.UpdatePerson(It.IsAny<Person>()))
             .ReturnsAsync(person);

            _personsRepositoryMock
             .Setup(temp => temp.GetPersonsByPersonID(It.IsAny<Guid>()))
             .ReturnsAsync(person);

            //Act
            PersonResponse person_response_from_update = await _personService.UpdatePerson(person_update_request);

            //Assert
            person_response_from_update.Should().Be(person_response_expected);
        }

        #endregion

        #region DeletePerson
        // Supplied a valid PersonID, return is true as confirm of deletion
        [Fact]
        public async Task DeletePerson_ValidPersonID()
        {
            //Arrange
            Person person = _fixture.Build<Person>()
             .With(temp => temp.Email, "someone@example.com")
             .With(temp => temp.Country, null as Country)
             .With(temp => temp.Gender, "Female")
             .Create();


            _personsRepositoryMock
             .Setup(temp => temp.DeletePersonByPersonID(It.IsAny<Guid>()))
             .ReturnsAsync(true);

            _personsRepositoryMock
             .Setup(temp => temp.GetPersonsByPersonID(It.IsAny<Guid>()))
             .ReturnsAsync(person);

            //Act
            bool isDeleted = await _personService.DeletePerson(person.PersonID);

            //Assert
            isDeleted.Should().BeTrue();
        }

        // Supply an invalid person id, return false as result
        [Fact]
        public async Task DeletePerson_InvalidPersonID()
        {
            // Act
            bool isDeleted = await _personService.DeletePerson(Guid.NewGuid());

            // Assert
            // Assert.False(isDeleted);
            isDeleted.Should().BeFalse();
        }
        #endregion
    }
}
