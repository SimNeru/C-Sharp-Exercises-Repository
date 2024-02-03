using System;

class Student 
{ 
    //vengono indicati un numero di parametri specifici, ma se non siamo al corrente del numero di argomenti che devono essere passati?
    public void DisplaySubjects(string s1, string s2, string s3, string s4) { }

    //si usa la sintassi param
    public void DisplaySubjects(params string[] subjects) 
    { 
        var j = subjects.Length;
        for (int i = 0; i < j; i++) 
        {
            Console.WriteLine(subjects[i]);
        }
    }

    public void DisplayMarks(params int[] marks) 
    {
        int a = 0;
        int tot = 0;
        var j = marks.Length;

        for (int i = 0; i < j; i++)
        {
            Console.WriteLine($"Mark {++a} = {marks[i]}");
            tot += marks[i];
        }
        double avgMarks = getAverageMarks();
        Console.WriteLine("Average marks:" + avgMarks);

        //create local function
        double getAverageMarks() 
        {
            //create local variable local function
            double avg;
            avg = (double)(tot)/j;
            return avg;
        }
    }
}

class Program
{
   public static void Main() 
    { 
        //create object of Student
        Student student = new Student();

        //access DisplaySubject method
        student.DisplaySubjects("Theory of Computation", 
            "Computer Networks", 
            "Discrete Mathematics", 
            "Digital System Design","Basics of C", "Hello World");

        student.DisplayMarks(80,45,71);
        Console.ReadKey();
    }
}