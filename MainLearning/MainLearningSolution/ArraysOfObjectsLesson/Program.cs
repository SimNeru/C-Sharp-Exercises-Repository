using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArraysOfObjectsRelated;

namespace ArraysOfObjectsLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create objects of Employee class
            Employee employee1 = new Employee() { EmpID = 101, EmpName = "Gino" };
            Employee employee2 = new Employee() { EmpID = 102, EmpName = "Paolo" };
            Employee employee3 = new Employee() { EmpID = 103, EmpName = "Marco" };

            // create array of objects
            Employee[] employees = new Employee[] { employee1, employee2, employee3 };

            foreach (Employee employee in employees) 
            {
                Console.WriteLine(employee.ToString());
            }

            Console.ReadKey();
        }
    }
}
