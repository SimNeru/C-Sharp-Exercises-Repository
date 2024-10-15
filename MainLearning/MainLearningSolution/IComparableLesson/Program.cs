using System;
using System.Collections.Generic;

namespace IComparableLesson
{
    /*
     * Interfaccia usata per effettuare comparazioni
     * se implementata o ereditata in una classe figlia
     * restituisce 0 o + o - numero
     * 
     * Necessaria per definire logica per il sorting tra oggetti
     * Confronta tra due oggetti quale dovrebbe venire prima, tra il corrente e quello parametrizzato
     * 
     * 0 : l'oggetto corrente e quello parametrizzato rimangono sulla stessa posizione
     * < 0: l'oggetto corrente viene per primo, parametrizzato successivo
     * > 0: l'oggetto parametrizzato viene per primo, corrente successivo
     */

    class Employee : IComparable
    {

        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Job { get; set; }

        /* ESEMPIO ORDINAMENTO SU COMPARAZIONE NUMERICA
        public int CompareTo(object other)
        {
            Employee otherEmp = (Employee)other;
            Console.WriteLine(this.EmpID + ", " + ((Employee)other).EmpID);
            return this.EmpID - otherEmp.EmpID;
        }
        */

        /* ESEMPIO ORDINAMENTO SU COMPARAZIONE STRINGHE 
         * Compara il valore dei char in ordine per dettare l'ordine
         */
        public int CompareTo(object other)
        {
            Employee otherEmp = (Employee)other;
            Console.WriteLine(this.EmpName + ", " + ((Employee)other).EmpName);
            return this.EmpName.CompareTo(otherEmp.EmpName);
        }
    }

    /*
     * IComparer utile quando si vuole implementare funzioni comparable su una classe che non ha IComparable implementata come interfaccia
     */
    class CustomClass : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.EmpID - y.EmpID;
        }
    }

    // Sort by Job, EmpName

    // enumeratore perché il sorting eseguito sulla colonna sarà per forza su uno di questi 3 attributi
    public enum SortBy 
    {
        EmpID, EmpName, Job
    }

    class CustomSortBy : IComparer<Employee> 
    {
        public int Compare(Employee x, Employee y)
        {
            int res = 0;
            switch (this.sortBy)
            {
                case SortBy.EmpID:
                    res = x.EmpID - y.EmpID; break;
                case SortBy.EmpName:
                    res = (x.EmpName!=null) ? x.EmpName.CompareTo(y.EmpName) : 0; break;
                case SortBy.Job:
                    res = (x.Job!=null) ? x.Job.CompareTo(y.Job) : 0; break;
                default: 
                    res = 0;break;
            }
            /*
            if (x.Job != null)
            { 
                res = x.Job.CompareTo(y.Job);
            }
            
            if (res == 0) 
            {
                if (x.EmpName != null) 
                {
                    res = x.EmpName.CompareTo(y.EmpName);
                }
            }
            */
            return res;
        }

        public SortBy sortBy { get; set; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {

            // list of employees
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { EmpID= 104, EmpName= "Mary", Job= "Designer"},
                new Employee() { EmpID= 102, EmpName= "Alexa", Job= "Manager"},
                new Employee() { EmpID= 101, EmpName= "Steven", Job= "Consultant"},
                new Employee() { EmpID= 103, EmpName= "Jade", Job= "Analyst"},
            };
            employees.Sort();

            Console.WriteLine();

            foreach (Employee e in employees)
            {
                Console.WriteLine(e.EmpID + ", " + e.EmpName + ", " + e.Job);
            }

            /* 
             * ICOMPARER interfaccia separata da IComparable ma implementata appunto all'interno di essa
             * ed usata per la logica posta dietro l'utilizzo di IComparable con i suoi vari metodi (stesso ragionamento di IEnumerable)
             */

            CustomClass customClass = new CustomClass();
            employees.Sort(customClass);

            Console.WriteLine();
            Console.WriteLine("CUSTOM_COMPARER");

            foreach (Employee e in employees)
            {
                Console.WriteLine(e.EmpID + ", " + e.EmpName + ", " + e.Job);
            }   

            // SORT BY JOB OR NAME
            CustomSortBy customSortBy = new CustomSortBy();
            customSortBy.sortBy = SortBy.EmpName;
            employees.Sort(customSortBy);

            Console.WriteLine();
            Console.WriteLine("CUSTOM_SORT_BY_NAME");
            foreach (Employee e in employees)
            {
                Console.WriteLine(e.EmpID + ", " + e.EmpName + ", " + e.Job);
            }

            Console.ReadLine();
        }
    }
}
