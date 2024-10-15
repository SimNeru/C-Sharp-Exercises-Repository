using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyAndClone
{
    // model class
    class Employee 
    {
        public string EmployeeName { get; set; }
        public string Role { get; set; }

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

            Console.WriteLine("COPY_TO");

            // new array
            Employee[] higlyPaidEmployees = new Employee[3];
            // necessario indicare l'array da cui copiare elementi che scalerà, e l'indice da cui partire
            employees.CopyTo(higlyPaidEmployees,0);

            foreach (Employee employee in higlyPaidEmployees) 
            {
                Console.WriteLine($"NAME: {employee.EmployeeName} ROLE: {employee.Role}");
            }
            Console.WriteLine();

            // new array
            Employee[] higlyPaidEmployees2 = new Employee[5];
            // riporto l'indice da cui inizierà ad inserire gli oggetti copiati, su un array necessariamente abbstanza largo
            employees.CopyTo(higlyPaidEmployees2, 2);

            foreach (Employee employee in higlyPaidEmployees2)
            {
                if (!(employee is null))
                {
                    Console.WriteLine($"NAME: {employee.EmployeeName} ROLE: {employee.Role}");
                }
                else 
                {
                    Console.WriteLine("null");
                }
            }
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("CLONE");
            // NOTA BENE: il clone restituisce in forma di oggetto e non di array, precisamente un array object (necessario cast)
            // Basandosi su un pricipio chiamato "Reflection" il codice in background del metodo riconosce il tipo di oggetto Employee analizzando il tipo dell'oggetto clonato
            // non stiamo creando un nuovo array, il metodo clone stesso crea un nuovo oggetto, il cui reference object sarà ricevuto nella variabile dichiarata
            Employee[] higlyPaidEmployeesCloned = (Employee[])employees.Clone();

            foreach (Employee emp in higlyPaidEmployeesCloned) 
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

            /* 
             * Riassunto il Clone creerà un nuovo oggetto array implicitamente,
             * nel caso di CopyTo è richiesto creare un oggetto manualmente
             * 
             * Differenza tra "Shallow Copy", "Deep Copy":
             * SHALLOW COPY *
             * All'interno degli indici di un array, non viene conservato l'oggetto di per sé, ma il suo "riferimento",
             * quest'ultimo è ciò che viene realmente 'copiato'
             * 
             * In parole povere l'oggetto una volta allocato sulla sua HEAP, non viene ricreato per occupare altro 'spazio'
             * ma il riferimento ad esso si.
             * 
             * Se effettuate modifiche, chiamando uno dei due riferimenti, l'oggetto in questione verrà cambiato.
             * 
             * DEEP COPY *
             * Quando invece viene creato un nuovo oggetto partendo dall'originale, un oggetto che occuperà a tutti gli effetti una sua area di memoria HEAP
             * 
             * Entrambi i metodi precedentemente citati performano una SHALLOW COPY
             */

            Console.ReadKey();
        }
    }
}
