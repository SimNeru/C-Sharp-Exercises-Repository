using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCopyLesson
{
    /* MODEL CLASS CON METODO DI CLONAZIONE MANUALE 
    class Employee
    {
        public string EmployeeName { get; set; }
        public string Role { get; set; }

        public Employee CreateNewEmployee() 
        {
            Employee new_one = new Employee() 
            { 
                EmployeeName = this.EmployeeName, 
                Role = this.Role
            };
            return new_one;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[]
            {
                new Employee() { EmployeeName="Paolo", Role="Manager"},
                new Employee() { EmployeeName="Mario", Role="Developer"},
                new Employee() { EmployeeName="Sara", Role="Analist"}
            };

            Console.WriteLine("DEEP_COPY");
            // Deep Copy Manual implementation
            Employee[] employee_deep_copy = new Employee[employees.Length];
            for (int i = 0; i < employees.Length; i++)
            {
                var result = employees[i].CreateNewEmployee();
                employee_deep_copy[i] = result;
            }

            foreach (Employee emp in employee_deep_copy)
            {
                if (!(emp is null))
                {
                    Console.WriteLine($"NAME: {emp.EmployeeName} ROLE: {emp.Role}");
                }
                else
                {
                    Console.WriteLine("null");
                }
            }

            Console.WriteLine("");
            // NOTA: Come se cambio attributo dell'oggetto in indice 0 nell'array originale non altero
            // anche l'oggetto copiato nell'array successivo perché diverso
            employees[0].Role = "Changed";

            Console.WriteLine("ARRAY ORIGINALE");
            foreach (Employee emp in employees) 
            {
                Console.WriteLine($"NAME: {emp.EmployeeName} ROLE: {emp.Role}");
            }

            Console.WriteLine("ARRAY COPIATO");
            foreach (Employee emp in employee_deep_copy) 
            {
                Console.WriteLine($"NAME: {emp.EmployeeName} ROLE: {emp.Role}");
            }

            Console.ReadKey();
        }
    }
    */

    // MODEL CLASS raccomandata tramite implementazione interfaccia IClonable
    class Employee : ICloneable
    {
        public string EmployeeName { get; set; }
        public string Role { get; set; }

        public object Clone() // convenzionalmente nome giusto
        {
            Employee new_one = new Employee()
            {
                EmployeeName = this.EmployeeName,
                Role = this.Role
            };
            return new_one;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[]
            {
                new Employee() { EmployeeName="Paolo", Role="Manager"},
                new Employee() { EmployeeName="Mario", Role="Developer"},
                new Employee() { EmployeeName="Sara", Role="Analist"}
            };

            Console.WriteLine("DEEP_COPY");
            // Deep Copy implementation
            Employee[] employees_deep_copy = new Employee[employees.Length];
            for (int i = 0; i < employees.Length; i++)
            {
                var result = (Employee)employees[i].Clone(); // casting necessario poiché IClonable restituisce object generico
                employees_deep_copy[i] = result;
            }

            foreach (Employee emp in employees_deep_copy)
            {
                if (!(emp is null))
                {
                    Console.WriteLine($"NAME: {emp.EmployeeName} ROLE: {emp.Role}");
                }
                else
                {
                    Console.WriteLine("null");
                }
            }

            Console.WriteLine("");
            // NOTA: Come se cambio attributo dell'oggetto in indice 0 nell'array originale non altero
            // anche l'oggetto copiato nell'array successivo perché diverso
            employees[0].Role = "Changed";

            Console.WriteLine("ARRAY ORIGINALE");
            foreach (Employee emp in employees) 
            {
                Console.WriteLine($"NAME: {emp.EmployeeName} ROLE: {emp.Role}");
            }

            Console.WriteLine("ARRAY COPIATO");
            foreach (Employee emp in employees_deep_copy) 
            {
                Console.WriteLine($"NAME: {emp.EmployeeName} ROLE: {emp.Role}");
            }

            Console.ReadKey();
        }
    }
}
