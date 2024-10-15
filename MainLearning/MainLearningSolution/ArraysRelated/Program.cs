using System;

class Program
{
    /* Arrays sono un gruppo di valori molteplici dello stesso tipo
     * In memoria "Heap" gli elementi dell'array sono archiviati in posizioni
     * di memoria continue
     * 
     * type [] arrayReferenceVariableName = new type [size]*/

    /* For Loop inizializzatione, controlla condizione, esegue il loop del body ed infine performa l'incremento
     * ES:
     * for (int = 0; i < (arrayRefVariable.Lenght); i++)
     * {
     *      arrayRefVariable[i];
     * }
     * Dato un array inizia da 0, quello sarà il numero di partenza del loop
     * se valore diverso dalla lunghezza array, - 1 poiché la lunghezza di un array parte sempre da un numero inferiore di 1
     * i++ incrementa di 1
     */

    static void Main()
    {
        //create an array
        int[] a = new int[3];
        a[0] = 10;
        a[1] = 20;
        a[2] = 30;
        //a[3] = 40; GIVES ERROR CAUSE IS OUT OF RANGE

        //create a string array
        string[] b = new string[3];
        b[0] = "one";
        b[1] = "two";
        b[2] = "three";

        //display values int array
        for (int i = 0; i < a.Length; i++)
        {
            Console.WriteLine(a[i]);
        }
        //Console.WriteLine(a[3]);

        //display values string array
        for (int i = 0; i < b.Length; i++)
        {
            Console.WriteLine(b[i]);
        }

        foreach (int i in a)
        {
            Console.WriteLine($"Sfrutto il forEach: {i} ciclo");
        }

        foreach (string i in b)
        {
            Console.WriteLine($"Sfrutto il forEach: {i} ciclo");
        }

        //reverse
        for (int i = a.Length - 1; i >= 0; i--)
        {
            Console.WriteLine($"Sfrutto in reverse: {a[i]}");
        }

        Console.ReadKey();
    }
}