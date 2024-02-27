using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionRelated
{
    public class Plane : IVehicle
    {
        public void RequiredLicense()
        {
            Console.WriteLine("BREVETTO DI VOLO");
        }

        public void TypeOf()
        {
            Console.WriteLine("ARIA");
        }

        public void VehicleClassification()
        {
            Console.WriteLine("VELIVOLO");
        }
    }
}
