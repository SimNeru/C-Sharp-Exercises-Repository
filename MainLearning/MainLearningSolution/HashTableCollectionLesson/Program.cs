using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableCollectionLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //HASHTABLE COLLECTION
            Console.WriteLine("\nHASH_TABLE COLLECTION");
            /*
             * NOTA BENE: Utilizzata in caso desiderassimo creare una lista contenente più data types
             * Simile alla SORTED_LIST, il processo di recupero è più veloce di una DICTIONARY
             * Ma il meccanismo di salvataggio interno è completamente diverso di una sorted list:
             * Sorted list performano in ordine ascendente di sorting basandosi sulle chiavi,
             * le Hashtable automaticamente e randomicamente calcolano l'indice e distorce la 'KEY_VALUE'
             * a coppie come una LINKED_LIST ad un dato indice
             * 
             * Cos'è un Hashcode e come viene generato:
             * In caso la chiave sia di tipo numerico, lo stesso numero viene 'estratto' come hash code
             * (Ex: numero 10, l'hashcode sarà 10) ed esso è utilizzato in modo univoco a scopo 'identificativo',
             * nei casi qualora venisse duplicato e nei casi una chiave sia una stringa
             * il metodo toString della classe wrapper String, genererà automticamente un random hashcode
             * l'hashcode generato sarà basato sui 'Chars' assegnati: Microsoft ha una sua logica interna di conversione delle stringa,
             * ma nel caso la 'KEY_VALUE' sia di un oggetto di una classe in particolare è responsabilità dello sviluppatore
             * scrivere un metodo hashcode per generare il nostro personale hashcode
             * 
             */

            Hashtable employees = new Hashtable()
            {
                { 103, "Mary" },
                { 102, "Robert" },
                { 105, "Carl" },
                { 104, "Beatrice" },
                { 101, "Zachary" },
                { "hello", 10.39 }
            };

            // foreach
            foreach (var item in employees) 
            {
                Console.WriteLine(item);
            }

            // foreach as DICTIONARY_ENTRY
            Console.WriteLine("\nDICTIONARY_ENTRY");
            foreach (DictionaryEntry item in employees)
            {
                Console.WriteLine(item.Key + ", " + item.Value);
            }

            //Add element
            employees.Add(106, "Ania");

            //Remove element
            employees.Remove(102);

            //get valure based on key
            if (employees[105] is string) 
            {
                string value = Convert.ToString(employees[105]);
                Console.WriteLine(value);
            }
            else if (employees[105] is double) 
            {
                double value = Convert.ToDouble(employees[105]);
                Console.WriteLine(value);
            }

            //Search for specific key
            bool k = employees.ContainsKey(105);
            Console.WriteLine("\n105 exist:" + k);

            //Search for specific value
            bool c = employees.ContainsValue("Ania");
            Console.WriteLine("\nAnia exist:" + c);

            // Keys
            Console.WriteLine("\nKeys:");
            foreach (var item in employees.Keys) 
            {
                Console.WriteLine(item);
            }

            // Keys
            Console.WriteLine("\nValues:");
            foreach (var item in employees.Values)
            {
                Console.WriteLine(item);
            }

            //HASHSET COLLECTION
            Console.WriteLine("\nHASH_SET COLLECTION");
            /*
             * Hash Set contiene un gruppo di elementi di valori univoci, conservati ai rispettivi indici
             * Sull' Hash Set l'hash code sarà calcolato in base al 'VALUE' anziché la 'KEY' come sull' HashTable, è quindi richiesto che i valori siano 'unici'
             * Utilissimo su enormi quantità di dati, velocissimo
             * 
             * NOTA: HashSet acconsente solo un null value; Hastable acconsento solo un null key, ma acconsente a molteplici null values
             */

            HashSet<string> messages = new HashSet<string>()
            {
                "Good Morning",
                "How Are You",
                "Have a good day",
            };

            // Count
            Console.WriteLine("\nCount: " + messages.Count);

            // Remove
            messages.Remove("Have a good day");

            // Add
            messages.Add("Good luck");

            // Search
            bool b = messages.Contains("Good Morning");
            Console.WriteLine("\nContains 'Good Morning': " + b);

            // Remove where
            messages.RemoveWhere(m => m.EndsWith("You"));

            // foreach
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }

            // Union
            // create two Hashset 
            HashSet<string> employees2021 = new HashSet<string>() { "Amar", "Akhil", "Samareen" };
            HashSet<string> employees2022 = new HashSet<string>() { "John", "Scott", "Smith", "David" };

            // Union, unisce due hash set in uno
            employees2021.UnionWith(employees2022);

            Console.WriteLine("\nUNION");
            foreach (string item in employees2021) 
            {
                Console.WriteLine(item);
            }
            
            // Intersection
            // create two Hashset 
            HashSet<string> employees2023 = new HashSet<string>() { "Amar", "Akhil", "Samareen" };
            HashSet<string> employees2024 = new HashSet<string>() { "Amar", "Akhil", "Smith", "David", "John" };

            // InterctWith, restituisce Hashset solo su valori che matchano
            employees2023.IntersectWith(employees2024);

            Console.WriteLine("\nINTERSECT_WITH");
            foreach (string item in employees2023) 
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
