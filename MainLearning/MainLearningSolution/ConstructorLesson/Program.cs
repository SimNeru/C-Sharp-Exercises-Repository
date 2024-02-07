using System;

class Program
{
    static void Main()
    {
        /* ::CONSTRUCTOR METHOD::
         * Speciale metodo di classe che contiene l'inizializzazione logica dei campi di classe
         * Può essere definita della logica addizionale all'interno dell'inizializzazione dei fields
         * 
         * ::SINTASSI::
         * accessModifier modifier ClassName (param1, param2)
         * {
         *      Initialize fields here
         * }
         * 
         * ::CONVENZIONI::
         * Costruttore deve avere il nome della classe
         * Costruttore raccomandato sia pubblic o internal
         * (se "privato", può essere chiamato solo all'interno della classe stessa,
         * quindi creabile l'oggetto di una classe solo all'interno della stessa e non all'esterno)
         * Costruttore può avere uno o più parametri
         * Costruttore non può restituire alcun valore
         * Costruttori possono essere uno o più, ma devono ciascuno avere diversi tipi di parametri
         */

        //create 3 objects of class employee
        Employee one = new Employee();
        Employee two = new Employee();
        Employee three = new Employee();

        //creo 4° employee
        Employee four = new Employee(1, "John Wick", "Killer");

        //OBJECT INITIALIZER
        //utile per quando desideriamo inserire valori nei fields senza specifiche
        Employee five = new Employee() { id = 5, name = "Pibbo" , job = "Baudo" };

        //print employee one
        Console.WriteLine($"\n::EMPLOYEE:: \nID: {one.id}, \nNAME: {one.name}, \nJOB: {one.job}\nCOMPANY: {Employee.companyName}");
        Console.WriteLine($"HASHCODE: {one.GetHashCode()}");

        //print employee two
        Console.WriteLine($"\n::EMPLOYEE:: \nID: {two.id}, \nNAME: {two.name}, \nJOB: {two.job}\nCOMPANY: {Employee.companyName}");
        Console.WriteLine($"HASHCODE: {two.GetHashCode()}");
        
        //print employee three
        Console.WriteLine($"\n::EMPLOYEE:: \nID: {three.id}, \nNAME: {three.name}, \nJOB: {three.job}\nCOMPANY: {Employee.companyName}");
        Console.WriteLine($"HASHCODE: {three.GetHashCode()}");

        //print employee four
        Console.WriteLine($"\n::EMPLOYEE:: \nID: {four.id}, \nNAME: {four.name}, \nJOB: {four.job}\nCOMPANY: {Employee.companyName}");
        Console.WriteLine($"HASHCODE: {four.GetHashCode()}");

        Console.ReadKey();
    }
}

