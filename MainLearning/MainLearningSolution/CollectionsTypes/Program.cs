using System;
using System.Collections.Generic;

namespace CollectionsTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Dimensioni dinamiche,
             * Possibile + e - per chiavi/valori,
             * Chiave non può essere nulla o duplicata, il valore si
             * Non è index-based, accesso necessario attraverso chiave
             * Non è sorted di default, l'ordine degli è elementi è quello inizializzato
             * 
             * Properties:
             * Count: conteggio elementi,
             * [Tkey]: restituzione valore in base alla chiave,
             * Keys: Restituisce una collezione di chiavi (ignorando valori)
             * Values: restituisce una collezione di valori (ignorando le chiavi)
             * 
             * Methods:
             * Add(TKey, Tvalue)
             * Remove(Tkey)
             * ContainsKey(Tkey)
             * ContainsValue(TValue)
             * Clear()
             */
            Console.WriteLine("DICTIONARY_LIST");

            Dictionary<int, string> employees = new Dictionary<int, string>()
            {
                { 101, "Gianni" },
                { 102, "Maria" },
                { 103, "Roberta" },
            };

            // Remove, se non presente non restituisce errori
            employees.Remove(104);

            // for each loop print dictionary
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Key + ", " + employee.Value);
            }
            Console.WriteLine();

            // for each loop print dictionary 2nd method
            foreach (KeyValuePair<int, string> item in employees)
            {
                Console.WriteLine(item.Key + ", " + item.Value);
            }
            Console.WriteLine();

            // print single value by the value
            Console.WriteLine("Value at 101 " + employees[101]);

            // print keys
            Dictionary<int, string>.KeyCollection keys = employees.Keys;
            Console.WriteLine("\nKeys:");
            foreach (int item in keys) 
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // duplicate key: exception ERROR
            // employees.Add(103, "Anna");

            // ContainsKey
            bool a = employees.ContainsKey(102);
            Console.WriteLine($"Is key 102 present? {a}");
            Console.WriteLine();

            Console.WriteLine("SORTED LIST");
            SortedList<int, String> employees2 = new SortedList<int, String>()
            {
                { 103, "Mary" },
                { 102, "Robert" },
                { 105, "Carl" },
                { 104, "Beatrice" },
                { 101, "Zachary" },
            };

            //Add element
            employees2.Add(106, "Ania");
            
            //Remove element
            employees2.Remove(102);

            //Foreach
            foreach (KeyValuePair<int,string> item in employees2)
            {
                Console.WriteLine(item);
            }

            //Get value based on key
            string res = employees2[106];
            Console.WriteLine("\nEmployee at 106 is: " + res);

            //Search for specific key
            bool k = employees2.ContainsKey(105);
            Console.WriteLine("\n105 exist:" + k);

            //Search for specific value
            bool c = employees2.ContainsValue("Ania");
            Console.WriteLine("\nAnia exist:" + c);

            //Index of specific key
            int ki = employees2.IndexOfKey(105);
            Console.WriteLine("\nIndex of 105: " + ki);

            //Index of specific key (not present case)
            int ki2 = employees2.IndexOfKey(108);
            Console.WriteLine("\nIndex of 108: " + ki2);

            //Index of value 
            int vi = employees2.IndexOfValue("Ania");
            Console.WriteLine("\nIndex of Ania: " + vi);


            Console.ReadLine();

        }
    }
}
