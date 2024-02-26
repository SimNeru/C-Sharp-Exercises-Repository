using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionRelated
{
    public class Boat : IVehicle
    {
        public void RequiredLicense()
        {
            Console.WriteLine("DEPENDS, TYPE A");        
        }

        public void TypeOf()
        {
            Console.WriteLine("WATER");
        }

        public void VehicleClassification()
        {
            Console.WriteLine("natante da diporto, imbarcazione da diporto e nave da diporto.");
        }
    }
}
