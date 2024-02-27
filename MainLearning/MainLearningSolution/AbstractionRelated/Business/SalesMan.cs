using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionRelated.Business
{
    public class SalesMan : Employee, IPerson
    {
        public string Region { get; set; }
        public DateTime DateOfBirth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //constructor child class
        public SalesMan(int empID, string empName, string location, string region) : base(empID, empName, location)
        {
            Region = region;
        }

        public override string GetHealthInsuranceAmount()
        {
            return "Salesman health insurance is: 500";
        }

        public int GetAge()
        {
            throw new NotImplementedException();
        }
    }
}
