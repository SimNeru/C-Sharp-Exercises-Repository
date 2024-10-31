using ServiceContracts;

namespace Services
{
    // IDisposable implementata per necessità logica di servizi Scoped
    public class CitiesService : ICitiesService, IDisposable
    {
        private List<string> _cities;

        public CitiesService()
        {
            _serviceInstanceId = Guid.NewGuid();
            _cities = new List<string>()
            {
                "London",
                "Paris",
                "Rome",
                "Berlin",
                "Madrid",
                "Tokyo",
                "Singapore"
            };
            // Add logic to open db connection
        }

        // proprietà di ICitiesService per testare funzionalità di "Transient, Scope, Singleton"
        private Guid _serviceInstanceId;

        public Guid ServiceInstanceId { get
            { 
                return _serviceInstanceId;
            } 
        }

        public List<string> GetCities { get { return _cities; } }

        public List<string> GetCitiesMethod()
        {
            return GetCities;
        }

        // Nel caso il servizio venga richiamato come 'Scope', il Dispose verrà richiamato solo alla fine della Request
        // ma se si volesse chiuderla appena venga completata un operazione lato database sarà necessario implementare i 'Child scopes'
        public void Dispose()
        {
            //TO DO: add logic to close db connection

        }
    }
}
