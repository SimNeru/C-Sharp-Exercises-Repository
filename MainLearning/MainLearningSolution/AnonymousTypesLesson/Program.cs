using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypesLesson
{
    /*
     * ANONYMOUS OBJECT
     * Utili per quando si desideri raccogliere in un oggetto unico non definito dei valori in entrata da altre fonti
     * C# compiler genererà in automatico un oggetto con le proprietà in questione ed effettuerà assegnazione del tipo con una classe nome random
     */

    class Person 
    {
        public int GetAge() 
        {
            return 10;
        }
        public string GetName() 
        {
            return "Bob";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();

            // invece di creare un'ipotetica classe Person Details, posso creare
            // un anonymous type che prenda i dati in entrata
            var anonP = new { PersonName = p.GetName(), PersonAge = p.GetAge() };
            
            // non si possono assegnare null
            // non si possono creare, campi valori, proprietà, eventi o metodi return
            // raccomandato usare gli anonimous objects all'interno del metodo in cui vengono creati

            Console.WriteLine("ANONIMOUS_OBJECTS");
            Console.WriteLine(anonP.PersonName);
            Console.WriteLine(anonP.PersonAge);
            Console.WriteLine(anonP.GetType());

            Console.ReadLine();

            Console.WriteLine("ANONIMOUS_NESTING");
            // si possono nestare uno dentro all'altro
            var anonN = new { PersonName = p.GetName(), PersonAge = p.GetAge(), Address = new { Street = "street_name", City = "city_name" } };

            Console.WriteLine(anonN.PersonName);
            Console.WriteLine(anonN.PersonAge);
            Console.WriteLine(anonN.Address.City);
            Console.WriteLine(anonN.Address.Street);

            Console.ReadLine();

            Console.WriteLine("ANONIMOUS_ARRAY");
            // si possono creare array di anonimous objects
            // devono contenere lo stesso set di proprietà

            var anonA = new[]
            {
                new {PersonName = "A", Email = "a@mail"},
                new {PersonName = "B", Email = "b@mail"},
                new {PersonName = "C", Email = "c@mail"},
            };

            foreach (var a in anonA) Console.WriteLine(a.PersonName + ", " + a.Email);

            Console.ReadLine();
        }
    }
}
