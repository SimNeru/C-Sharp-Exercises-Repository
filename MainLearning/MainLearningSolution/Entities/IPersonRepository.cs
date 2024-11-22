using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Entities
{
    public class ApplicationDBContext : DbContext
    {
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        // In runtime ogniqualvolta le 'options' che sono state fornite all'interno della classe 'Program'
        // al momento dell'invocazione del AddDbContext, incluso il database provider, verranno passate all'interno del costruttore
        // come parametro e lo stesso sarà fornito alla classe 'genitore', in questo modo il database provider verrà riconosciuto
        public ApplicationDBContext(DbContextOptions options) : base (options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // all'invocazione del dbContext sull'avvio, verrà invocato il model creating
            // che 'builderà' sul db delle tabelle con delle colonne equivalenti alle proprietà definite lato asp.net
            // come 'entities'
            modelBuilder.Entity<Country>().ToTable("countries");
            modelBuilder.Entity<Person>().ToTable("persons", x => x.HasCheckConstraint("CHK_TIN", "len(TaxIdentificationNumber) = 8"));

            // * Seed Data per definire i records che popoleranno la tabella in fase di creazione
            // eseguo lettura dai file.json
            string countriesJson = System.IO.File.ReadAllText("countries.json");
            string personsJson = System.IO.File.ReadAllText("persons.json");

            #region Seed Country
            // sistema che specifica che lista di oggetti desideriamo generare
            List<Country>? listOfCountries = System.Text.Json.JsonSerializer.Deserialize<List<Country>>(countriesJson);
            foreach (Country country in listOfCountries)
            {
                modelBuilder.Entity<Country>().HasData(country);
            }
            #endregion

            #region Seed Person
            List<Person>? listOfPersons = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(personsJson);
            foreach (Person person in listOfPersons)
            {
                modelBuilder.Entity<Person>().HasData(person);
            }

            #endregion

            #region FluentApi
            modelBuilder.Entity<Person>().Property(tempo => tempo.TIN)
                .HasColumnName("TaxIdentificationNumber")
                .HasColumnType("varchar(8)")
                .HasDefaultValue("ABC12345");

            //modelBuilder.Entity<Person>().HasCheckConstraint();
            #endregion

            #region TableRelations
            // Non necessario definirlo se configurato direttamente su entità come [ForeignKey]
            //modelBuilder.Entity<Person>(entity => 
            //{
            //    entity.HasOne<Country>(c => c.Country)
            //    .WithMany(p => p.Persons)
            //    .HasForeignKey(p => p.CountryID);
            //});
            #endregion
        }

        #region StoredProcedure
        public List<Person> sp_GetAllPersons()
        {
            return Persons.FromSqlRaw("EXECUTE [dbo].[GetAllPersons]").ToList();
        }

        public int sp_InsertPerson(Person person)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@PersonID", person.PersonID),
                new SqlParameter("@PersonName", person.PersonName),
                new SqlParameter("@Email", person.Email),
                new SqlParameter("@DateOfBirth", person.DateOfBirth),
                new SqlParameter("@Gender", person.Gender),
                new SqlParameter("@CountryID", person.CountryID),
                new SqlParameter("@Address", person.Address),
                new SqlParameter("@ReceiveNewsLetters", person.ReceiveNewsLetters)
            };

            return Database.ExecuteSqlRaw("EXECUTE [dbo].[InsertPerson]" +
                "@PersonID, @PersonName, @Email, @DateOfBirth, @Gender, @CountryID, @Address, @ReceiveNewsLetters");
        }
        #endregion
    }
}
