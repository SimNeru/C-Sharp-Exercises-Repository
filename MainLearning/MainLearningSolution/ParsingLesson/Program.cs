class Program
{
    static void Main() 
    {
        /* ::PARSING::
         * E' una delle tecniche di "conversione del tipo", usata per convertire
         * un valore da un tipo stringa ad un "tipo numerico", il presupposto per l'analisi
         * è che il valore di orgine debba contenere solo cifre (spazi, lettere o altri caratteri speciali)
         * Nel caso in cui contenga uno qualunque di quei valori, lancerà un'eccezione FormatException
         * 
         * Il metodo Parse è utile per convertire il valore di 'string' in un qualsiasi altro tipo numerico come 'int',
         * ma c'è da assicurarsi che non contenga caratteri particolari.
         */
        
        System.Console.WriteLine("::PARSING::");

        //string
        string a = "100";

        //int
        int b;

        b = int.Parse(a);

        System.Console.WriteLine($"{a} as a String");
        System.Console.WriteLine($"{b} as an Integer");

        System.Console.ReadKey();

        /*
         * ::TRY PARSE::
         * Di base simile al Parse, usato anche per convertire un valore dal 
         * tipo "string" al tipo numerico, proprio come "Parse", ma la differenza sostanziale
         * è che il TRY PARSE controlla il valore sorgente prima della conversione.
         *
         * Il valore stringa è convertibile (no special chars)
         * Si --> Converte il valore stringa in un tipo numerico an lo conserva in una variabile "out" e ritorna true.
         * No --> Non converte il valore della stringa in un tipo numerico e restituisce falso.
         * 
         * Non solleva eccezioni e sorpassa la conversione.
         * 
         * SINTASSI:
         * bool variable = DestinationType.TryParse(SourceValue, out DestinationVariable)
         */

        System.Console.WriteLine("\n::TRY PARSING::");

        //read input value from keyboard
        string s;
        System.Console.WriteLine("\nEnter a number:");
        s = System.Console.ReadLine();

        //TryParse
        bool condition = int.TryParse(s, out int n);

        if (condition == true)
        {
            System.Console.WriteLine("Conversion is successful");
            System.Console.WriteLine(n);
        }
        else
        { 
            System.Console.WriteLine("Conversion failed"); 
        }

        System.Console.ReadKey();

        /*
         * ::CONVERSION METHOD::
         * E' un metodo predefinito per convertire un qualunque tipo primitivo
         * (anche 'stringa') in un qualunque altro tipo primitivo (pure 'stringa')
         * 
         * Es: string -> int & int -> string
         * 
         * System.Convert, è una classe che contiene un set di metodi predefiniti
         * Lancia FormatException, se la sorgente valore è valida
         * Per ogni tipo di dato, abbiamo un metodo di conversione
         * Tutti i metodi di conversione sono metodi statici
         */

        System.Console.WriteLine("::\nCONVERSION METHOD::");

        //int
        int a1 = 1000;

        //string
        string b1;

        //int -> string
        b1 = System.Convert.ToString(a1);

        System.Console.WriteLine($"OUTPUT = {a1} as INT");
        System.Console.WriteLine($"OUTPUT = {b1} as STRING");
        System.Console.ReadKey();
    }
}
