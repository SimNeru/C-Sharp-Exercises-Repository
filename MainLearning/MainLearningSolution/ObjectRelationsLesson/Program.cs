using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRelationsLesson
{
    public class Student 
    {
        public int RollNo { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public Branch Branch { get; set; }
        public List<Examination> Examinations { get; set; }
    }

    public class Branch 
    { 
        public int NoOfSemesters { get; set; }
        public string BranchName { get; set; }

    }

    public class Examination 
    {
        public string ExaminationName { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int MaxMarks { get; set; }
        public int SecuredMarks { get; set; }
    }

    public class Department 
    { 
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Email { set; get; }
        public Department dept { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Student student = new Student();
            student.RollNo = 123;
            student.StudentName = "Scott";
            student.Email = "scott@mail.com";
            
            // one-to-one relation
            student.Branch = new Branch();
            student.Branch.BranchName = "Computer Science Engineering";
            student.Branch.NoOfSemesters = 8;

            Console.WriteLine(student.RollNo);
            Console.WriteLine(student.StudentName);
            Console.WriteLine(student.Email);
            Console.WriteLine(student.Branch.BranchName);
            Console.WriteLine(student.Branch.NoOfSemesters);

            // one-to-many relation
            Student student1 = new Student();
            student1.RollNo = 1;
            student1.StudentName = "Allen";
            student1.Email = "Allen@mail.com";
            student1.Examinations = new List<Examination>();
            student1.Examinations.Add(new Examination() { ExaminationName = "Module Test 1", Month = 5, Year = 2021, MaxMarks = 100, SecuredMarks = 87});
            student1.Examinations.Add(new Examination() { ExaminationName = "Module Test 2", Month = 7, Year = 2021, MaxMarks = 100, SecuredMarks = 70});
            student1.Examinations.Add(new Examination() { ExaminationName = "Final Test", Month = 3, Year = 2021, MaxMarks = 100, SecuredMarks = 91});

            // print
            Console.WriteLine("\nRollNo: " + student1.RollNo);
            Console.WriteLine("Name: " + student1.StudentName);
            Console.WriteLine("Email: " + student1.Email);
            Console.WriteLine("\nEXAMINATIONS");
            foreach (Examination exam in student1.Examinations) 
            {
                Console.WriteLine($"\nName: {exam.ExaminationName}\nMonth: {exam.Month}\nYear: {exam.Year}\nMax: {exam.MaxMarks}\nSecured: {exam.SecuredMarks}");
            }

            Console.ReadLine();
        }
    }
}
