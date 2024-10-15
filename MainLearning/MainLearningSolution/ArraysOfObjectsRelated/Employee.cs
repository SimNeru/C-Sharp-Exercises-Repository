using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysOfObjectsRelated
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }

        public override string ToString()
        {
            return $"ID: {EmpID}, NAME: {EmpName}";
        }
    }
}
