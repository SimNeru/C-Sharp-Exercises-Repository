    class Program
    {
        static void Main()
        {

        /*
         * CONVERSIONE IMPLICITA
         * avviene automaticamente da un valore più piccolo ad uno più grande
         */
        System.Console.WriteLine(":::CONVERSIONE IMPLICITA:::");

        //sbyte
        sbyte a = 10;
        System.Console.WriteLine("sbyte a = 10");

        //int
        double b;
        System.Console.WriteLine("double b");

        //copy value from 'a' to 'b'
        b = a;
        System.Console.WriteLine("b = a");

        System.Console.WriteLine($"\na = {a} sbyte"); //Output 10
        System.Console.WriteLine($"b = {b} double"); //Output 10

        System.Console.ReadKey();

        //char
        char c = 'A';
        System.Console.WriteLine("\n\nchar a = 'A'");

        //int
        int d;
        System.Console.WriteLine("int b;");

        //copy the value from 'c' to 'd'
        d = c;
        System.Console.WriteLine("b = a");

        System.Console.WriteLine($"\na = {c}"); //Output 'A'
        System.Console.WriteLine($"b = {d} (valore ASCII)"); //Output valore ASCII del Char

        System.Console.ReadKey();


        System.Console.WriteLine("\n\n:::CONVERSIONE ESPLICITA:::");
        /*
         * CONVERSIONE ESPLICITA
         * avviene manualmente per convertire il tipo di data in un altro
         * Sintassi: (DestinazioneTipoDato)ValoreSorgente
         * 
         * ATTENZIONE: può essere una "LOOSY CONVERTION", ovvero causare una perdita di dati,
         * quando un tipo dato alla destinazione non è sufficientemente grande per archiviare
         * una parte del valore può andar perso.
         */

         //int piccolo 
        int a1 = 100;
        System.Console.WriteLine("int a = 100");

        //float grande
        float b1;
        System.Console.WriteLine("float b");

        //int to float
        b1 = a1;
        System.Console.WriteLine("b = (float) a");
        //si può comunque farlo sia implicito che esplicito
        b1 = (float)a1;

        System.Console.WriteLine($"\na = {a1}");
        System.Console.WriteLine($"b = {b1}");
        System.Console.ReadKey();

        System.Console.WriteLine("");

        //int grande
        int a2 = 500;
        System.Console.WriteLine("int a = 500");

        //byte piccolo
        byte b2;
        System.Console.WriteLine("byte b");

        b2 = (byte)a2;
        System.Console.WriteLine("b = (byte) a");

        System.Console.WriteLine($"\na = {a2}");
        System.Console.WriteLine($"b = {b2}");
        System.Console.ReadKey();
    }
}
