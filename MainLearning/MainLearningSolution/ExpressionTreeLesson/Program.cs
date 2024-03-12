using System.Linq.Expressions;

class Program
{
    static void Main()
    {
        //Create object student
        Student s = new Student() { StudentID = 101, StudentName = "Bob", StudentAge = 15 };

        //Create expression tree with Func
        //nell'espressione sottostante viene ricevuto un parametro int che è "a" e restituendolo esattamente uguale
        Expression<Func<int, int>> expression = a => a * a;

        //Create expression tree with Func for Student
        Expression<Func<Student, bool>> studentExpression = s => s.StudentAge > 12 && s.StudentAge < 20;

        //Compile expression usign Compile method to invoke it as Delegate
        Func<int, int> myDelegate = expression.Compile();

        //Compile expression student
        Func<Student, bool> myStudentDelegate = studentExpression.Compile();

        //Execution the method
        int result = myDelegate.Invoke(10);
        Console.WriteLine(result);

        //Execution the student's method
        bool res = myStudentDelegate.Invoke(s);

        if (res == true)
        {
            Console.WriteLine($"The student {s.StudentID}, named {s.StudentName} is a teenager");
        }
        else
        {
            Console.WriteLine($"The student {s.StudentID}, named {s.StudentName} is a teenager");
        }
        Console.ReadKey();
    }
}

class Student 
{ 
    public int StudentID { get; set; }
    public string? StudentName { get; set; }
    public int StudentAge { get; set; }
}
