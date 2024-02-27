using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionRelated.Business
{
    public interface IPerson
    {
        DateTime DateOfBirth { get; set; }
        int GetAge();
    }
}
