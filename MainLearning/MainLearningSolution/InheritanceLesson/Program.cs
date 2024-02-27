using System;

class Program
{
    static void Main()
    {
        Employee employee = new Employee(101, "Luigi", "Mushroom Kingdom");
        /*employee.EmpID = 101;
        employee.EmpName = "Simone";
        employee.Location = "Torino";*/

        Manager manager = new Manager(01,"Mario", "Mushroom Kingdom", "Accounting");
        /*manager.EmpID = 01;
        manager.EmpName = "Lara";
        manager.Location = "Firenze";
        manager.DepartmentName = "Accounting";*/

        SalesMan salesMan = new SalesMan(1001,"Waluigi","Manhattan","New York");
        /*salesMan.EmpID = 1001;
        salesMan.EmpName = "Pino";
        salesMan.Location = "Roma";*/

        Console.WriteLine($"\nOggetto della classe 'Genitore' (Employee)\nID: {employee.EmpID},\nNome: {employee.EmpName},\nLocation: {employee.Location}");
        Console.WriteLine($"employee.GetHealthInsurance: {employee.GetHealthInsuranceAmount()}");
        Console.WriteLine($"employee paycheck: {employee.GetPaycheckAmount()}");

        Console.WriteLine($"\nOggetto della classe 'Figlia' (Manager)\nID: {manager.EmpID},\nNome: {manager.EmpName},\nLocation: {manager.Location}, \nDepartment: {manager.GetFullDepartmentName()}");
        Console.WriteLine($"manager.GetTotalSalesOfTheYear: {manager.GetTotalSalesOfTheYear()}");
        Console.WriteLine($"manager.GetHealthInsurance: {manager.GetHealthInsuranceAmount()}");
        Console.WriteLine($"manager paycheck: {manager.GetPaycheckAmount()}");

        Console.WriteLine($"\nOggetto della classe 'Figlia' (SalesMan)\nID: {salesMan.EmpID},\nNome: {salesMan.EmpName},\nLocation: {salesMan.Location}");
        Console.WriteLine($"salesMan.GetSalesOfCurrentMonth: {salesMan.GetSalesOfCurrentMonth()}");
        Console.WriteLine($"salesMan paycheck: {salesMan.GetPaycheckAmount()}");

        Console.ReadKey();
    }
}

