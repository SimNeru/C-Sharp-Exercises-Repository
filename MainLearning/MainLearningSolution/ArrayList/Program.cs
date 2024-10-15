using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListLesson
{
    class Sample 
    {
        public int GetNumber() 
        {
            return 10;
        }
        
        public double GetAnotherNumber() 
        {
            return 10.7;
        }
        
        public string GetMessage() 
        {
            return "Hello";
        }

        public Employee GetEmployee()
        {
            return new Employee()
            {
                EmployeeName = "Mario"
            };
        }    
    }

    class Employee 
    {
        public string EmployeeName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            /* ArrayList
             * Non è una classe generica, quindi non è necessario definire il tipo di dato
             * durante la creazione di un'oggetto
             * E' utile in circostanze in cui eventualmente sia doveroso manipolare dati in entrata sconosciuti
             * di risultati restituiti da metodi sviluppati da programmatori terzi
             */

            ArrayList arrayList = new ArrayList() { 100, 'A'};

            Sample s = new Sample();
            // Add
            arrayList.Add(s.GetNumber());
            arrayList.Add(s.GetAnotherNumber());
            arrayList.Add(s.GetMessage());
            arrayList.Add(s.GetEmployee());

            // ForEach
            foreach (var item in arrayList) 
            {
                if (item is Employee emp)
                {
                    Console.WriteLine(emp.EmployeeName + " " + item.GetType());
                }
                else 
                { 
                    Console.WriteLine(item + " " + item.GetType());
                }
            }

            Console.ReadLine();
        }
    }
}
