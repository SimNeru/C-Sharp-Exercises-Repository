using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionRelated.Business
{
    public abstract class Employee
    {
        private int _empID;
        private string _empName;
        private string _location;
        private long _paycheck;

        //costruttore classe genitore
        public Employee(int empID, string empName, string location)
        {
            _empID = empID;
            _empName = empName;
            _location = location;
        }

        //metodo astratto
        public abstract string GetHealthInsuranceAmount();

        public int EmpID
        {
            set { this._empID = value; }

            get { return _empID; }
        }

        public string EmpName
        {
            set { this._empName = value; }

            get { return _empName; }
        }

        public string Location
        {
            set { this._location = value; }

            get { return _location; }
        }
    }
}
