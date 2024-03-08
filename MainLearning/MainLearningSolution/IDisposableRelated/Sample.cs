using System;

public class Sample : IDisposable
{
    //constructor
    public Sample() 
    {
        Console.WriteLine("Database connected.");
    }

    //method
    public void DisplayDataFromDatabase() 
    {
        Console.WriteLine("Reading data from database..");
    }

    //dispose, in genere suggerito inserire connessione db e la chiusura nel corpo metodo
    public void Dispose()
    {
        Console.WriteLine("Database disconnected.");
    }
}

