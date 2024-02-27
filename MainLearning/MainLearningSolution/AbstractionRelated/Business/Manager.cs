using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionRelated.Business
{
    public class Manager : Employee, IPerson
    {
        private string _departmentName;
        private DateTime _dateOfBirth;

        public Manager(int empID, string empName, string location, string departmentName) : base(empID, empName, location)
        {
            _departmentName = departmentName;
        }

        public string DepartmentName
        {
            set { _departmentName = value; }

            get { return _departmentName; }
        }

        public System.DateTime DateOfBirth
        {
            set
            {
                _dateOfBirth = value;
            }
            get
            {
                return _dateOfBirth;
            }
        }

        //metodo overriding metodo astratto
        public override string GetHealthInsuranceAmount()
        {
            return "Manager health insurance is: 1000";
        }

        public string GetFullDepartmentName()
        {
            return DepartmentName + " at " + base.Location;
        }

        public int GetAge()
        {
            /* DateTime.Now recupera data e ora del sistema in cui il programma è in esecuzione
             * sottrae dalla data di nascita e restituisce il valore in forma di
             * TimeSpan dove restituisce il valore sotto numero di giorni
             * divide per 365 per ottenere il numero di anni preciso
             */
            int a = System.Convert.ToInt32((System.DateTime.Now - DateOfBirth).TotalDays / 365);
            return a;
        }
    }
}
