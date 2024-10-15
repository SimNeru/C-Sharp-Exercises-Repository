using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuplesLesson
{
    /*
     * Utili per restituire valori multipli da un metodo o passarne a un altro
     * Alternativa agli anonimous object, a usare come tipi parametro/return
     */

    public class Gatto 
    {
        public string getNoise() 
        {
            return "MIAO!";
        }
    }
    
    public class Cane 
    {
        public string getNoise() 
        {
            return "BAU!";
        }
    }

    public class Cliente
    {
        public (int id, string name, string email) GetDettagliCliente() 
        {
            return (101, "Mario", "mario@mail.com");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Tuple<string, int> person = new Tuple<string, int>("Scott",20);
            Tuple<Gatto, Cane> animal = new Tuple<Gatto, Cane>(new Gatto(), new Cane());

            Console.WriteLine("TUPLE");
            Console.WriteLine(person.Item1);
            Console.WriteLine(person.Item2);

            Console.ReadKey();

            Console.WriteLine("\nTIPI COMPLESSI");
            Console.WriteLine(animal.Item1.getNoise());
            Console.WriteLine(animal.Item2.getNoise());

            // richiamare item1 o item2 può essere confusionario
            // Value Tuple è miglior practice, invece di utilizzare precedenti classi
            // <--- classe Cliente
            Console.WriteLine("\nVALUES TUPLES");
            Cliente cliente = new Cliente();

            //get details
            (int id, string name, string email) customer = cliente.GetDettagliCliente();
            
            Console.WriteLine(customer.id);
            Console.WriteLine(customer.name);
            Console.WriteLine(customer.email);

            Console.ReadKey();

            // Importante ordine dei valori iniziali per l'assegnazione
            // Deconstruction di una tupla per recuperare valori e poterli assegnare a variabili locali
            (int id, string name, string email) = cliente.GetDettagliCliente();
            
            Console.WriteLine("\nDOPO DECONSTRUCT");
            Console.WriteLine(id);
            Console.WriteLine(name);
            Console.WriteLine(email);

            Console.ReadKey();

            // Discard permettere di 'skippare' un valore della Tupla
            Console.WriteLine("\nDISCARD");
            (int idDiscard, _ , string emailDiscard) = cliente.GetDettagliCliente();

            Console.WriteLine(idDiscard);
            Console.WriteLine(emailDiscard);

            Console.ReadKey();
        }
    }
}
