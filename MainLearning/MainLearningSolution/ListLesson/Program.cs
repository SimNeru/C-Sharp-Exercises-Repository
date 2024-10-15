using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create reference variable for List class & crete object of List class
            List<int> myList = new List<int>(10) { 10,20,30};
            Console.WriteLine("Lista di partenza");
            StampaLista(myList);
            Console.ReadKey();
            Console.WriteLine();

            // ADD new element at the end of existing collection
            myList.Add(40);
            Console.WriteLine("Lista dopo uso 'Add'");
            StampaLista(myList);
            Console.ReadKey();
            Console.WriteLine();

            List<int> myAddRange = new List<int>() { 50, 60, 70 };
            Console.WriteLine("Lista dopo uso 'AddRange'");
            // ADD new elements at the end of existing collection trough another List
            myList.AddRange(myAddRange);
            StampaLista(myList);
            Console.ReadKey();
            Console.WriteLine();

            // insert element to position 0
            myList.Insert(0, 1);
            Console.WriteLine("Lista dopo 'Insert'");
            StampaLista(myList);
            Console.ReadKey();
            Console.WriteLine();

            // insert elements starting from 1
            List<int> myRangeInsert = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9 };
            myList.InsertRange(1, myRangeInsert);
            Console.WriteLine("Lista dopo 'InsertRange'");
            StampaLista(myList);
            Console.ReadKey();
            Console.WriteLine();

            // remove element
            myList.Remove(70);
            Console.WriteLine("Lista dopo 'Remove'");
            StampaLista(myList);
            Console.ReadKey();
            Console.WriteLine();

            // remove element at index, error se eccede il limite
            myList.RemoveAt(14);
            Console.WriteLine("Lista dopo 'RemoveAt'");
            StampaLista(myList);
            Console.ReadKey();
            Console.WriteLine();

            // remove from index 10, 4 elements
            myList.RemoveRange(10, 4);
            Console.WriteLine("Lista dopo 'RemoveRange'");
            StampaLista(myList);
            Console.ReadKey();
            Console.WriteLine();

            // remove all numbers < 10
            myList.RemoveAll(x => x < 10);
            Console.WriteLine("Lista dopo 'RemoveAll(<10)'");
            StampaLista(myList);
            Console.ReadKey();
            Console.WriteLine();

            // Clear 
            myList.Clear();
            Console.WriteLine("Lista dopo 'Clear'");
            StampaLista(myList);
            Console.ReadKey();
            Console.WriteLine();

            myList.Add(10);
            myList.Add(20);
            myList.Add(30);
            myList.Add(40);
            myList.Add(50);
            myList.Add(30);

            // IndexOf restituisce indice di un valore oppure -1
            int n = myList.IndexOf(40);
            int n2 = myList.IndexOf(60);

            StampaRisultato(n, 40);
            StampaRisultato(n2, 60);

            // secondo paramentro indica indice da cui ripartire con la ricerca
            int n3 = myList.IndexOf(30, n+1);
            StampaRisultato(n3, 30);
            
            Console.ReadKey();
            Console.WriteLine();

            // BinarySearch 
            List<int> myBinarySearch = new List<int>() { 10,20,30,40,50,60,70,80,90,100 };
            int n4 = myBinarySearch.BinarySearch(80);
            Console.WriteLine("Binary search of 80: " + n4);
            
            Console.ReadKey();
            Console.WriteLine();

            // Contains
            bool b = myBinarySearch.Contains(50);
            bool b1 = myBinarySearch.Contains(110);

            Console.WriteLine("E' presente il numero 50? " + b);
            Console.WriteLine("E' presente il numero 110? " + b1);

            Console.ReadKey();
            Console.WriteLine();

            // Reverse
            List<double> myDoubles = new List<double>() { 170, 150, 445, 120, 10, 4, 661};

            // sort - asc
            myDoubles.Sort();
            Console.WriteLine("Lista dopo il Sort");
            // after sorting
            foreach (double d in myDoubles) 
            {
                Console.Write(d + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("Lista dopo il Reverse");
            // reverse
            myDoubles.Reverse();
            // after reverse
            foreach (double d in myDoubles)
            {
                Console.Write(d + " ");
            }            
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();

            // convert to Array
            List<string> myStrings = new List<string>() { "Tizio", "Caio", "Sempronio" };

            string[] myStringsArray = myStrings.ToArray();

            Console.WriteLine("Lista dopo conversione toArray");
            // display array
            foreach (string value in myStringsArray)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("Lista dopo foreach");
            // foreach
            myStrings.ForEach(s => Console.WriteLine(s + " amico"));
            Console.WriteLine();
            Console.ReadKey();

            // exist
            // controlla tutti gli elementi
            List<int> marksA = new List<int>() { 40, 95, 74, 23, 50, 81 };
            List<int> marksB = new List<int>() { 40, 65, 87, 35, 12, 69 };


            // check if student A failed
            if (marksA.Exists(x => x < 35))
            {
                Console.WriteLine("Student A failed");
            }
            else 
            {
                Console.WriteLine("Student A passed");
            }

            // check if student A failed
            if (marksB.Exists(x => x < 35))
            {
                Console.WriteLine("Student B failed");
            }
            else
            {
                Console.WriteLine("Student B passed");
            }

            Console.WriteLine();
            Console.ReadKey();

            // Find
            // controlla ciascun elemento e si ferma al primo che match, restituisce il data tipe base in caso di insuccesso (EX: Int = 0)
            int firstFailedMark = marksB.Find(x => x < 40);
            Console.WriteLine($"First failed mark is: {firstFailedMark}");

            Console.WriteLine();
            Console.ReadKey();
            
            // Find Index
            // controlla ciascun elemento e si ferma al primo che matcha, restituisce -1 in caso di insuccesso
            int indexFirstFailedMark = marksB.FindIndex(x => x < 40);
            Console.WriteLine($"First failed mark's index is: {indexFirstFailedMark}");

            Console.WriteLine();
            Console.ReadKey();

            // Find Last
            // controlla ciascun elemento e si ferma all'ultimo che matcha, restituisce il data tipe base in caso di insuccesso (EX: Int = 0)
            int lastFailedMark = marksB.FindLast(x => x < 40);
            Console.WriteLine($"Last failed mark is: {lastFailedMark}");

            Console.WriteLine();
            Console.ReadKey();

            // Find Last Index
            // controlla ciascun elemento e si ferma al primo che matcha, restituisce -1 in caso di insuccesso
            int indexLastFailedMark = marksB.FindLastIndex(x => x < 40);
            Console.WriteLine($"Last failed mark's index is: {indexLastFailedMark}");

            Console.WriteLine();
            Console.ReadKey();
            
            // Find All
            // controlla ciascun elemento e li restituisce come collection, restituisce una collection empty in caso di insuccesso
            List<int> allFailedMarks = marksB.FindAll(x => x < 40);

            Console.Write("There are some failed marks, which are: ");
            foreach (int i in allFailedMarks)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();

            // Convert All
            // Con una lambda expression viene eseguita su ciascun elemento di una lista,
            // aggiunge ogni nuovo elemento convertito in una nuova collection fino all'ultimo 
            List<int> simpleNums = new List<int>() { 1, 2, 3 };
            List<string> allConvertedMarks = simpleNums.ConvertAll(x => Convert.ToString(x));

            foreach (string i in allConvertedMarks) 
            { 
                Console.WriteLine($"{i} tipo: {i.GetType()}");
            }

            Console.WriteLine();
            Console.ReadKey();
        }

        static void StampaLista(List<int> lista) 
        {
            if (lista.Count <= 0) 
            {
                Console.WriteLine("La lista è vuota");
            } 
            else 
            { 
            foreach (int i in lista) 
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            }
        }

        static void StampaRisultato(int position, int value)
        {
            if (position > 0)
            {
                Console.WriteLine($"{value} trovato in posizione: {position}");
            }
            else
            {
                Console.WriteLine($"Valore non presente");
                Console.WriteLine();
            }
        }
    }
}
