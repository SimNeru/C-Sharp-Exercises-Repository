using System;

/* COSA SONO LE STRUTTURE 
 * Ci sono due categorie classificabili:
 * 1) VALUE TYPES (Structures, Enumerations)
 * 2) REFERENCE TYPES (string, Classes, Interfaces, Delegate)
 * 
 * 1) Pensato per immagazzinare semplici valori,
 *    Le istanze sono definite: "structure instances" o "enumeration instances",
 *    Le istanze vengono "immagazzinate" sullo "Stack", a ogni chiamata di metodo un nuovo stack viene creato
 * 
 * 2) Pensato per immagazzinare valori complessi,
 *    Le istanze sono definite: "Objects",
 *    Le istanze vengono "immagazzinate" sullo "Heap", ne esiste uno per l'intera applicazione
 *
 *    Le strutture non supportano l'ereditarietà
 */

struct StructureName 
{ 
    /* Fields
     * methods
     * parametrized constructors
     * properties
     * events
     */
}

class Program
{
    static void Main()
    {
        //Si possono creare solo direttamente istanze struct basate su struct
        //new è fittizio, serve solo a chiamare in questo caso il costruttore senza parametri
        //IMPORTANTE, non si può creare un'oggetto da una structure
        Category category = new Category();

        //inizializzo i campi attraverso le proprietà
        category.CategoryID = 1;
        category.CategoryName = "General";

        //access methods
        Console.WriteLine(category.CategoryID);
        Console.WriteLine(category.CategoryName);
        Console.WriteLine(category.GetCategoryNameLenght());
        Console.WriteLine("");
        Console.ReadKey();

        //create structure instance
        Structure1 structure1;
        structure1.x = 10;
        structure1.y = 20;

        //create object based on class
        Class1 class1;
        class1 = new Class1();
        class1.x = 10;
        class1.y = 20;

        //create structure instance 2
        Structure1 structure2;
        structure2 = structure1;
        // i valori di 1 verranno copiati sul 2, ma l'allocazione in memoria resterà separata

        //modify data of structure2
        structure2.x = 100;
        structure2.y = 200;

        Console.WriteLine($":::::STRUCTURE:::::");
        Console.WriteLine($"1) X: {structure1.x}");
        Console.WriteLine($"1) Y: {structure1.y}");

        Console.WriteLine($"2) Y: {structure2.x}");
        Console.WriteLine($"2) Y: {structure2.y}");
        Console.WriteLine("");
        Console.ReadKey();

        //copy reference from class1 to class2
        Class1 class2;
        class2 = class1;
        //Le variabili di riferimento class1,class2 puntano alla stessa allocazione
        //sull'Heap dei dati, quindi per quanto separati restituiranno lo stesso risultato

        //modify data object through reference variable2
        class2.x = 100;
        class2.y = 200;

        Console.WriteLine($":::::CLASS:::::");
        Console.WriteLine($"1) X: {class1.x}");
        Console.WriteLine($"1) Y: {class1.y}");

        Console.WriteLine($"2) Y: {class2.x}");
        Console.WriteLine($"2) Y: {class2.y}");
        Console.WriteLine("");
        Console.ReadKey();

        System.SByte x = 8;

        /* DATO CHE GLI STRUCT SONO TIPI DI VALORE, 
         * I DATI SONO STATI COPIATI NELLA NUOVA ISTANZA DI STRUCT
         * 
         * LE CLASSI ESSENDO TIPI DI RIFERIMENTO, 
         * I DATI VENGONO SOVRASCRITTI SULL'OBJECT
         * 
         * Tutti i tipi primitivi sono structures (eccetto strings)
         * 
         */
    }
}