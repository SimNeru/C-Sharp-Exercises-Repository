using System;

class Program
{
    static void Main()
    {
        Employee employee = new Employee();
        employee.EmpID = 101;
        employee.EmpName = "Simone";
        employee.Location = "Torino";

        Manager manager = new Manager();
        manager.EmpID = 01;
        manager.EmpName = "Lara";
        manager.Location = "Firenze";

        SalesMan salesMan = new SalesMan();
        salesMan.EmpID = 1001;
        salesMan.EmpName = "Pino";
        salesMan.Location = "Roma";

        var x = manager.GetTotalSalesOfTheYear();
        var y = salesMan.GetSalesOfCurrentMonth();

        Console.WriteLine($"\nOggetto della classe 'Genitore' (Employee)\nID: {employee.EmpID},\nNome: {employee.EmpName},\nLocation: {employee.Location}.");

        Console.WriteLine($"\nOggetto della classe 'Figlia' (Manager)\nID: {manager.EmpID},\nNome: {manager.EmpName},\nLocation: {manager.Location}.");
        Console.WriteLine($"manager.GetTotalSalesOfTheYear: {x}");

        Console.WriteLine($"\nOggetto della classe 'Figlia' (SalesMan)\nID: {salesMan.EmpID},\nNome: {salesMan.EmpName},\nLocation: {salesMan.Location}.");
        Console.WriteLine($"salesMan.GetSalesOfCurrentMonth: {y}");

        Console.ReadKey();
    }
}

