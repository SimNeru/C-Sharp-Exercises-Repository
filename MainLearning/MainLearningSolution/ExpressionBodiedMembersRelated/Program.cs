using System;
using System.Collections.Generic;

/* Expression Bodied Members, consente allo sviluppatore di usare "Inline lambda expressions" per creare
 * metodi, proprietà accessor, constructors, destructors, indicizzatori in una classe
 * 
 * ES: 
 * Metodo che usa "Expression body members", senza valori di ritorno.
 * public ReturnType MethodName( ) => dichiarazione(esempio Console.Writeline); 
 * 
 * Metodo che usa "Expression body members", con valori di ritorno.
 * public ReturnType MethodName( ) => AnyValue(tipo un'espressione unica 10*20); */

/* SWITCH Expression, è una semplificazione dello "switch-case"
 * 
 * ES:
 * sourceVariable switch
 * {
 *      value1 => result1,
 *      value2 => result2,
 *      ...
 *       _  => defaultResult
 * }
 * 
 * Non usabile se desideriamo chiamare un metodo */

class Program
{
    static void Main()
    {
        //create object Student
        Student s = new Student() { StudentName = "Jimmy"};
        Student st = new Student();

        Console.WriteLine(s.StudentName);
        Console.WriteLine(s.GetStudentNameLenght());

        Console.WriteLine(st.StudentName);
        Console.WriteLine(st.GetStudentNameLenght());

        Console.ReadKey();
        Console.WriteLine("\nSWITCH EXPRESSION");

        int operation = 1;
        string result;

        //switch expression
        //<LangVersion>v8.0</LangVersion>
        //Da aggiungere nel file xml del progetto nella prima categoria Properties
        result = operation switch
        {
            1 => "Customer",
            2 => "Employee",
            3 => "Supplier",
            4 => "Distributor",
            _ => "No case avaiable"
        };

        Console.WriteLine(result);
        Console.ReadKey();
    }
}

public class Student 
{
    //private field
    private string _studentName;

    //public method
    public int GetStudentNameLenght() => _studentName.Length;

    //public constructors
    public Student() => _studentName = "Me";

    //public properties
    public string StudentName
    {
        set => _studentName = value;
        get => _studentName;
    }
}