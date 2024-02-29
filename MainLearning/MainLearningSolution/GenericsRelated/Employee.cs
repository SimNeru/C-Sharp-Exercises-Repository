using System;

public class Employee
{
    public int Salary;
}

public class Intern
{
    public string Evaluation;
}

//a class with a generic method
public class Sample
{
    //generic method
    public void PrintData<T>(T obj) where T : class
    {
        if (obj.GetType() == typeof(Intern))
        {
            Intern temp = obj as Intern;
            Console.WriteLine(temp.Evaluation);
        }
        else if (obj.GetType() == typeof(Employee))
        {
            Employee temp = obj as Employee;
            Console.WriteLine(temp.Salary);
        }
    }
}