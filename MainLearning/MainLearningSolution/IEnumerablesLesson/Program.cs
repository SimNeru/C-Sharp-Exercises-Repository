using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerablesLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Utile definire IEnumerable una reference object, che successivamente pensiamo
            // che dovremo instanziare tipi complessi come figlie con le loro relative funzioni e logiche

            // create collection
            IEnumerable<string> messages = new List<string>() { "How are you", "Have a great day", "Thanks for meeting"};

            //for each
            Console.WriteLine("IENUMERABLE:");
            foreach (string message in messages) 
            {
                Console.WriteLine(message);
            }

            // IEnumerator è un'interfaccia indipendente da IEnumerable,
            // IEnumerable usa IEnumerator, la funzionalità di quest'ultimo è quella di leggere attraverso set di elementi non per storarli
            // IEnumerator consente il for each loop, attraverso cui vengono chiamati i suoi metodi che ne consentono il funzionamento (Current, MoveNext, Reset)

            // ESEMPIO FUNZIONAMENTO IENUMERATOR
            Console.WriteLine("\nIENUMERATOR ESEMPIO:");
            IEnumerator<string> enumerator = messages.GetEnumerator();
            enumerator.Reset();
            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);
            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);
            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);
            enumerator.Reset();
            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);

            Console.WriteLine("\nCICLO_WHILE");
            // MoveNext torna false in caso di elemento assente
            while (enumerator.MoveNext()) 
            {
                Console.WriteLine(enumerator.Current);
            }

            Console.ReadLine();
        }
    }
}
