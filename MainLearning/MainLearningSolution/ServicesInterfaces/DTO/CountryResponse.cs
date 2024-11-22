using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ServicesInterfaces.DTO
{
    /// <summary>
    /// DTO class that is used as return type for most of CountriesService methods
    /// </summary>
    public class CountryResponse
    {
        public Guid CountryID { get; set; }
        public string? CountryName { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj.GetType() != typeof(CountryResponse)) return false;

            var output = obj as CountryResponse;

            return this.CountryID == output.CountryID && this.CountryName == output.CountryName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// Come parte della business logic c'è da convertire il 'CountryObject' nella 'CountryResponse',
    /// 
    /// es: l'utente sta cercando di eseguire una getAll() dei countries, una lista di oggetti che avrà 
    /// come reference type i countries
    /// 
    /// Necessario quindi creare un'extension method che convertirà il data object in un contry response
    /// </summary>
    
    
    public static class CountryExtensions 
    {
        /* Creo un extension method, che sarà iniettato nella classe Country entity 
         * comportandosi come il metodo venisse aggiunto alla stessa */
        public static CountryResponse ToCountryResponse(this Country country) 
        {
            return new CountryResponse()
            {
                CountryID = country.CountryID,
                CountryName = country.CountryName
            };
        }
    }
}

