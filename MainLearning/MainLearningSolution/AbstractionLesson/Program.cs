using System;
using AbstractionRelated;

class Program
{
    /* Astrazione è un concetto di rappresentare oggetti in un modo semplificato concentrandosi solo su features e ignorando i dettagli irrilevanti
     * Fornisce un contratto per le classi che ne aderiscono per assicurare la consistenza del codice
     */

    /* Una CLASSE ASTRATTA è una classe parent della quale non si possono
     * creare oggetti relativi ma si possono creare delle classi figlie ad essa correlate
     * Una classe astratta può contenere campi, proprietà, metodi, costruttori, distruttori, etc..
     *
     * Quando usare una classe Astratta e un'Interfaccia IMPORTANTE
     * Nella classe ASTRATTA si possono definire sia metodi astratti che non, le classi che le estenderanno
     * sono obbligate ad implementare i metodi definiti astratti al suo interno, ma gli altri no.
     * Le INTERFACCE sono obbligano ad implementare tutti i metodi definiti al loro interno
     */

    static void Main()
    {
        //Car car = new Car(); ERROR non si può creare oggetto classe astratta

        AutomaticCar one = new AutomaticCar();
        Console.WriteLine("Car one has been created and got.. ");
        one.ChangeGear();
        ManualCar two = new ManualCar();
        Console.WriteLine("Car two has been created and got.. ");
        two.ChangeGear();

        Console.ReadKey();
        
        Console.WriteLine("\nCar object created..");
        Console.WriteLine(":::Type:::"); one.TypeOf();
        Console.WriteLine(":::Classification:::"); one.VehicleClassification();
        Console.WriteLine(":::License requested:::"); one.RequiredLicense();

        Boat boat = new Boat();
        Console.WriteLine("\nBoat object created..");
        Console.WriteLine(":::Type:::"); boat.TypeOf();
        Console.WriteLine(":::Classification:::"); boat.VehicleClassification();
        Console.WriteLine(":::License requested:::"); boat.RequiredLicense();

        Plane plane = new Plane();
        Console.WriteLine("\nPlane object created..");
        Console.WriteLine(":::Type:::"); plane.TypeOf();
        Console.WriteLine(":::Classification:::"); plane.VehicleClassification();
        Console.WriteLine(":::License requested:::"); plane.RequiredLicense();

        Console.ReadKey();
    }
}

