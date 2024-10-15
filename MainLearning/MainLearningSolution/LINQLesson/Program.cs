using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLesson
{
    /*
     * Language Integrated Query
     * Libreria di funzioni per la gestione di oggetti / db records / formato xml, csv, etc
     */

    class Employee 
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string City { get; set; }

        public double Salary { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "a_name", City = "a_city", Job = "a_job", Salary = 4500 },
                new Employee() { Id = 2, Name = "b_name", City = "b_city", Job = "b_job", Salary = 1500 },
                new Employee() { Id = 3, Name = "c_name", City = "c_city", Job = "a_job", Salary = 1500 },
                new Employee() { Id = 4, Name = "d_name", City = "d_city", Job = "c_job", Salary = 5000 },
                new Employee() { Id = 5, Name = "e_name", City = "e_city", Job = "b_job", Salary = 1000 },
            };

            // Filter by matching values WHERE
            //var res = employees.Where(emp => emp.Job == "a_job");
            
            // OrderBy a set of elements, più ordinamenti grazie a ThenBy
            IOrderedEnumerable<Employee> res = employees.OrderBy(emp => emp.Salary).ThenBy(emp => emp.Name);

            Console.WriteLine("Employees with a_job");
            foreach (Employee emp in res) 
            {
                Console.WriteLine(emp.Name + ", " + emp.Salary);
            }

            Console.ReadKey();

            // Where
            List<Employee> filteredEmployees = employees.Where(emp => emp.Job == "b_job").ToList();
            Console.WriteLine(filteredEmployees[0].Id + ", " + filteredEmployees[0].Id);

            // NOTA: Se risultato operazione First o Last è NULL, porta errore
            // Suggerito usare il metodo FirstOrDefault(), LastOrDefault() che richiederà comunque un check della variabile

            // First
            Employee firstEmployee = employees.FirstOrDefault(emp => emp.Job == "b_job");
            Console.WriteLine(filteredEmployees[0].Id + ", " + filteredEmployees[0].Id);

            Console.ReadKey();


        }
    }
}
