using System;

class Program
{
    static void Main()
    {
        //int rappresenta lo stato della domanda
        User<int, int> user1 = new User<int, int>();
        //set value 
        user1.RegistrationStatus = 1234;
        user1.Age = 22;
        Console.WriteLine(user1.RegistrationStatus);
        Console.WriteLine("AGE: " + user1.Age + "\n");

        //string rappresenta lo stato della domanda
        User<string, string> user2 = new User<string, string>();
        //set value
        user2.RegistrationStatus = "HELLO";
        user2.Age = "35-40";
        Console.WriteLine(user2.RegistrationStatus);
        Console.WriteLine("AGE: " + user2.Age + "\n");


        //bool rappresenta lo stato della domanda
        User<bool, bool> user3 = new User<bool, bool>();
        //set value
        user3.RegistrationStatus = true;
        user3.Age = true;
        Console.WriteLine(user3.RegistrationStatus);
        Console.WriteLine("AGE is 22? " + user3.Age + "\n");
        Console.ReadKey();

        //create object generic class
        MarksPrinter<GraduateStudent> mp = new MarksPrinter<GraduateStudent>();
        mp.stu = new GraduateStudent() { Marks = 80 };
        mp.PrintMarks();
        Console.WriteLine();
        Console.ReadKey();

        //create object Employee
        Sample sample = new Sample();
        Employee emp = new Employee() { Salary = 1000 };
        Intern intern = new Intern() { Evaluation = "Good" };

        //call generic method
        sample.PrintData<Employee>(emp);
        sample.PrintData<Intern>(intern);
        Console.ReadKey();
    }
}

