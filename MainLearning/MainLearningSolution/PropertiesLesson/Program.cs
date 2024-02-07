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

        //Scrivibile anche attraverso OBJECT INITIALIZER
        Class1 employee2 = new Class1()
        { EmpName = "Luigi", EmpID = 102, EmpJob = "Plumber"};


        //trying to set wrong values
        employee.EmpID = 10; //<100
        employee.EmpCompany = "12345678900"; //string >10

        //stampa dell'employee attraverso il ritorno dei valori tramite il GET
        Console.WriteLine($"\n::EMPLOYEE:: \nID: {employee.EmpID}, \nNAME: {employee.EmpName}, \nJOB: {employee.EmpJob},\nCOMPANY: {employee.EmpCompany},\nSALARY: {employee.EmpSalary},");
        Console.WriteLine($"Taxed: {employee.CalculateNetSalary()}");
        Console.WriteLine($"HASHCODE: {employee.GetHashCode()}");

        Console.WriteLine($"\n::EMPLOYEE:: \nID: {employee2.EmpID}, \nNAME: {employee2.EmpName}, \nJOB: {employee2.EmpJob},\nCOMPANY: {employee2.EmpCompany},\nSALARY: {employee2.EmpSalary}");
        Console.WriteLine($"Taxed: {employee2.CalculateNetSalary()}");
        Console.WriteLine($"HASHCODE: {employee.GetHashCode()}");

        Console.ReadKey();
    }
}

