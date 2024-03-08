using System;

class Program
{
    //feature di C# 8.0, aggiornabile attraverso il file xaml, nella cartella del progetto
    static void DoWork()
    {
        //create object using "using declaration"
        using Sample s = new Sample();
        s.DisplayDataFromDatabase();
    }// Dispose get called here

    static void Main()
    {
        DoWork();

        /*create object with using structure
         * 
        using (Sample s = new Sample())
        {
            s.DisplayDataFromDatabase();
        }

        alla fine della struttura il metodo Dispose
        verrà automaticamente chiamato, con riferimento alla variabile s.Dispose()*/
        
        Console.WriteLine("Some other work here");
        Console.ReadKey();
    }
}

