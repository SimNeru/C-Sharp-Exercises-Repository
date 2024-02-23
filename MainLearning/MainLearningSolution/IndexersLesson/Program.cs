using System;

class Program
{
    static void Main()
    {
        //oggetto classe Car
        Car c = new Car();

        //chiama automaticamente il GET dell'indexer
        Console.WriteLine($"\nLista auto: {c[0]}, {c[1]}, {c[2]}");
        Console.ReadKey();

        //chiama il SET dell'indexer
        c[0] = "Nissan";
        Console.WriteLine($"\nCambiato valore");
        Console.ReadKey();
        Console.WriteLine($"\nLista auto: {c[0]}, {c[1]}, {c[2]}");
        Console.ReadKey();

        //Indexer overload
        Console.WriteLine($"\nCalling overloader");
        Console.WriteLine($"\nLista auto: {c["first"]}, {c["second"]}, {c["third"]}");
        Console.ReadKey();
    }
}


