using System;
using System.Threading;

class Program
{
    /* PROPERTIES
     * Sono un membro composito di una classe che contengono due accessi:
     * GET -
     * SET -
     * Creano un livello di protezione attorno ai campi, prevenendo l'assegnazione
     * di valori invalidi all'interno di essi, oltre che fare alcuni calcoli automatici
     * quando vengono invocate.
     * Non viene allocata sulla memoria la proprietà (usata solo per i field dell'oggetto), properties e metodi fanno parte della classe
     * Suggerito inserire per ogni field le sue proprierties sia per istance e che gli static fields
     *
     * SUGGERITE PER PROGETTI IN TEMPO REALE
     * A real time project means a project in which you are processing 
     * or computing something based on inputs being given by sensors or otherwise 
     * and trying to get a meaningful output. 
     * In IEEE project, it need not have a real time project 
     * but still it can be an IEEE project.
     * 
     * INDEXERS
     * Raro utilizzo ma possono risultare utili
     * Facilitano l'accesso a un array che è archiviato all'interno di un campo
     * (ad esempio una stringa che contiene più nomi separati da virgole o un array)
     * Un Array è una raccolta di più valori dello stesso tipo di dati.
     * Mettiamo che vogliamo semplificare l'accesso a quella particolare matrice o stringa dall'esterno classe
     * 
     */

    static void Main()
    {
        Class1 employee = new Class1();
        //assegnazione dei valori ai field attraverso la proprietà SET
        employee.EmpID = 101;
        employee.EmpName = "Mario";
        employee.EmpJob = "Plumber";
        employee.Tax = 50;
        employee.EmpCompany = "Brothers";
        employee.Description = "Super Cool";

        //Scrivibile anche attraverso OBJECT INITIALIZER
        Class1 employee2 = new Class1()
        { EmpName = "Luigi", EmpID = 102, EmpJob = "Plumber", BirthPlace = "New York"};

        //trying to set wrong values
        employee.EmpID = 10; //<100
        employee.EmpCompany = "12345678900"; //string >10

        //stampa dell'employee attraverso il ritorno dei valori tramite il GET
        Console.WriteLine($"\n::EMPLOYEE:: \nID: {employee.EmpID}, \nNAME: {employee.EmpName}, \nJOB: {employee.EmpJob},\nCOMPANY: {employee.EmpCompany},\nSALARY: {employee.EmpSalary},\nDESCRIPTION: {employee.Description}\nBIRTHPLACE: {employee.BirthPlace}");
        Console.WriteLine($"Taxed: {employee.CalculateNetSalary()}");
        Console.WriteLine($"HASHCODE: {employee.GetHashCode()}");

        Console.WriteLine($"\n::EMPLOYEE:: \nID: {employee2.EmpID}, \nNAME: {employee2.EmpName}, \nJOB: {employee2.EmpJob},\nCOMPANY: {employee2.EmpCompany},\nSALARY: {employee2.EmpSalary}\nBIRTHPLACE: {employee2.BirthPlace}");
        Console.WriteLine($"Taxed: {employee2.CalculateNetSalary()}");
        Console.WriteLine($"HASHCODE: {employee.GetHashCode()}");

        Console.ReadKey();
    }
}

