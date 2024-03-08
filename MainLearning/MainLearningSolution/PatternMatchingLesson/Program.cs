using System;
using InnerClass;
using PatternMatchingRelated;

/* PATTERN MATCHING
 * Utile per convertire la variabile di riferimento della classe genitore
 * nella variabile di riferimento della classe figlia, evitando scrittura esplicita
 * ma tramite una condizione corrispondente in caso
 */

/* IMPLICITY TYPED VARIABLES
 * 1) Utili quando un interfaccia o una classe hanno nomi troppo lunghi
 * ES: namespace1.namespace2.namespace3.classname
 * 2) Il risultato di una LINQ query può essere definito come keyword var
 * poiché generalmente possono restituire diversi tipi di dato a seconda della query effettivo
 */

/* DINAMICALLY TYPED VARIABLES
 * Dichiarati con dynamic, differenza di var è che nel var viene inizializzato
 * il valore assieme alla dichiarazione variabile e il compilatore C# correggerà
 * automaticamente il tipo di dati ma non corregger mai alcun tipo di dati particolari
 * per la variabile.
 * Ad un tipo valore dinamico si può assegnare ogni tipo di valore,
 * le variabili tipizzate dinamicamente possono cambiare il loro tipo di dati nel
 * resto del programma.
 */
class Program
{
    static void Main()
    {
        //reference variable
        ParentClass pc;

        //object child class;
        pc = new ChildClass() { x = 10, y = 20 };

        //access parent class's members
        Console.WriteLine(pc.x); //impossibile accedere al membro y attualmente

        //access parent class's members
        if (pc is ChildClass cc) 
        {
            //ChildClass cc = (ChildClass)pc;
            Console.WriteLine(cc.x);
            Console.WriteLine(cc.y);
        }
        Console.ReadKey();

        //namespace1.namespace2.namespace3.ClasseProva p;
        var p = new namespace1.namespace2.namespace3.ClasseProva() { ProprietàProva = "prova" };
        Console.ReadKey();

        //dynamically typed variable
        dynamic x;

        x = 100;

        x = "Hello";

        x = new ParentClass() { x = 100 };

        //Console.WriteLine(x.ParentName); //C# non controlla la presenza della proprietà
        Console.WriteLine(x.x as String);
        Console.ReadKey();

        /* INNER CLASS
        *  E' una classe inserita dentro un'altra classe,
        *  per impostazione le classi interne sono accessibili solo 
        *  all'interno della stessa classe esterna.
        */

        //create object inner classe
        InnerClass.MarksCalculation.CalculationHelper ch = new InnerClass.MarksCalculation.CalculationHelper();
        Console.WriteLine(ch.Multiply(10,5));

        //call outer class's method
        InnerClass.MarksCalculation mc = new InnerClass.MarksCalculation();
        Student s = new Student() { SecuredMarks = 35, MaxMarks = 50 };

        mc.CalculatePercentage(s);
        Console.WriteLine($"Percentage: {s.Percentage}");
        Console.ReadKey();
    }
}

