using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Classe che implementa un'interfaccia deve implementarne tutti i metodi
 * 
 * I metodi di interfaccia sono public e abstract di default
 * 
 * La classe figlia deve implementare i metodi interfaccia con la stessa firma
 * 
 * Non possono essere creati oggetti interfaccia
 * 
 * La reference variabile di un tipo interfaccia può solo contenere l'indirizzo 
 * di oggetti di una qualsiasi corrispondente classe figlia
 * 
 * Si possono implementare interfacce della stessa classe figlia
 * 
 * Un'interfaccia può essere figlia di un'altra interfaccia
 */

namespace AbstractionRelated
{
    internal interface IVehicle
    {
        void TypeOf();
        void RequiredLicense();
        void VehicleClassification();
    }
}
