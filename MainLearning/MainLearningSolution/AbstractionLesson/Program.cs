using System;

class Program
{
    /* Astrazione è un concetto di rappresentare oggetti in un modo semplificato concentrandosi solo su features e ignorando i dettagli irrilevanti
     * Fornisce un contratto per le classi che ne aderiscono per assicurare la consistenza del codice
     */

    /* Una CLASSE ASTRATTA è una classe parent della quale non si possono
     * creare oggetti relativi ma si possono creare delle classi figlie ad essa correlate
     * Una classe astratta può contenere campi, proprietà, metodi, costruttori, distruttori, etc..
     */

    /* 
     * 
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
    }
}

