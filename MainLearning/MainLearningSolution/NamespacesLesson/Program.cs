
//per evitare ripetizione dei namespace si può aggiungere using in cima al programma
using HR.Mgr;
using m = FrontOffice; //si può adattare un alias

using static System.Math; //using + classe statica serve per evitare l'invocazione stessa
                          //della classe ed accedere direttamente ai metodi
using System;

//namespaces diversi consentono di creare e di accedere a classi nominate separatamente

namespace NamespacesLesson
{
    /* Namespaces sono una collezione di classi e altri tipi come:
     * interfacce, strutture, delegati, enumerazioni.
     * Nei progetti in tempo reale, lo scopo principali di un namespace
     * è ragggruppare tutti questi tipo come unica unità destinata ad uno scopo specifico
     */

    class Program
    {
        static void Main()
        {
            HR.Mgr.Manager manager = new HR.Mgr.Manager();
            HR.Mgr.IManager interfaceManager = new HR.Mgr.Manager();

            //Namespace comune ma classi diversa destinazione
            m.CustomerEnquiry customer = new FrontOffice.CustomerEnquiry();
            m.FrontOfficeExecutive frontOffice = new FrontOffice.FrontOfficeExecutive();

            int x = 4;
            var y = Pow(x, 2);

            Console.WriteLine("result: " + y);

            Console.ReadKey();
        }
    }
}
