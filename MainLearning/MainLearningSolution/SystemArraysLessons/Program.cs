using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemArraysLessons
{
    internal class Program
    {
        static void Main()
        {

            // INDEX_OF
            Console.WriteLine("INDEX_OF");
            // create array
            
            double[] a = new double[6] {10,20,30,40,50,30};

            // search for 30 in the array
            // restituirà primo risultato
            Console.WriteLine($"Ricerca del 30 sull'array: posizione {Array.IndexOf(a, 30)}");
            
            // search for 30 in the array SECOND OCCURENCE
            // deve essere indicato un 3° parametro per indicare la posizione dell'occurence
            Console.WriteLine($"Ricerca del 30 sull'array come secondo risultato: posizione {Array.IndexOf(a, 30, 3)}");

            // in caso la ricerca di un valore non fosse presente sull'array
            Console.WriteLine($"Ricerca del 300 sull'array: posizione {Array.IndexOf(a, 300)}");

            Console.ReadLine();

            /* BINARY_SEARCH
               NOTA BENE: Ottimizza la ricerca su un array (necessariamente ordinato)
               perché separa la ricerca in base al "calculate midpoint" da cui effettua ricerca
               
               ESEMPIO:
               Su un Array ordinato di [1, 3, 5, 7, 9] cerco un valore di 5
               1. Puntatore di partenza: low = 0, high = 4 (indici primo ed ultimo elemento array)
               2. Primo "punto intermezzo" calcolato in base alla formula = 2 
                  mid = low + (high - low)/2 | mid = 2 (valore = 5)
               3. Comparato: Il 5 equivale al valore di intermezzo, quindi restituirà 2

               Il processo continuerà aggiornando i valori low e high (ovvero le posizioni degli indici) a seconda del risultato restituito 
               del valore di intermezzo restituiti se è maggiore o minore della cifra da ottenere (finché non sarà uguale o assente)
             
               In termini di tempo la ricerca binaria è molto più efficente di una lineare
             */ 
            Console.WriteLine("BINARY_SEARCH");

            double[] b = new double[10] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100};

            // search for 30 in the array (solo prima metà)
            int n = Array.BinarySearch( b, 30 );
            Console.WriteLine($"30 is found at {n}");

            // search for 30 in the array (partendo dalla metà in poi)
            int n1 = Array.BinarySearch(b, 100);
            Console.WriteLine($"30 is found at {n}");

            // search for 100 in the array (not exist)
            int n2 = Array.BinarySearch(b, 300);
            Console.WriteLine($"100 is found at {n2}");

            Console.ReadLine();

            // Clear
            Console.WriteLine("CLEAR");

            // create array
            int[] c = new int[] {10,20,30,40,50,60};

            Console.WriteLine("Array di partenza:");
            foreach (var item in c)
            {
                Console.Write(item + " ");
            }

            // clear elements (array object, indice i partenza, totale di cifre da azzerare)
            Array.Clear(c, 2, 4);

            Console.WriteLine("Array dopo clear:");
            foreach (var item in c) 
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();
            Console.WriteLine();

            // RESIZE
            Console.WriteLine("RESIZE");

            /* Resize aumenta o riduce le dimensioni di un Array, se incrementato verranno inseriti
               valori di default 0, in caso di stringa risulterà null.
               L'array manipolato non verrà direttamente manipolato ma piuttosto duplica i dati in un nuovo array
             */

            // create array start
            int[] d = new int[] { 10, 20, 30 };

            Console.WriteLine("Array di partenza:");
            foreach (var item in d)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // resize dell'array a 6
            Array.Resize(ref d,6);
            Console.WriteLine("Array ridimensionato a 6 elementi:");
            foreach (var item in d)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Array.Resize(ref d, 2);
            Console.WriteLine("Array ridimensionato a 2 elementi:");
            foreach (var item in d)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();
            Console.WriteLine();

            // SORT
            Console.WriteLine("SORT");

            /* Ordina di default per ASC ordine un array */

            // create array start
            int[] e = new int[] { 56, 67,12, 99, 4, 500, 125};

            Console.WriteLine("Array di partenza:");
            foreach (var item in e)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Array.Sort(e);

            Console.WriteLine("Array dopo sort:");
            foreach (var item in e)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.ReadLine();

            // REVERSE
            Console.WriteLine("REVERSE");

            /* Metodo che inverte posizionamento elementi array */

            // create array start
            int[] f = new int[] { 1, 2, 3, 4, 5};

            Console.WriteLine("Array di partenza:");
            foreach (var item in f)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Array.Reverse(f);

            Console.WriteLine("Array dopo reverse:");
            foreach (var item in f)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
