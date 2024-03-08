namespace PatternMatchingRelated
{
    //parent class
    public class ParentClass
    {
        public int x { get; set; }
    }

    //child class
    public class ChildClass : ParentClass
    {
        public int y { get; set; }
    }
}

namespace namespace1 
{
    namespace namespace2 
    {
        namespace namespace3 
        { 
            public class ClasseProva 
            { 
                public string ProprietàProva { get; set; }
            }
        }
    }
}

namespace InnerClass
{
    public class Student 
    {
        public double SecuredMarks;
        public double MaxMarks;
        public double Percentage;
    }
    //outer class
    public class MarksCalculation 
    {
        public void CalculatePercentage(Student s) 
        {
            CalculationHelper ch = new CalculationHelper();
            s.Percentage = ch.Multiply(s.SecuredMarks / s.MaxMarks, 100);
        }
        //inner class
        public class CalculationHelper 
        {
            public double Multiply(double n1, double n2) 
            {
                return n1 * n2;
            }
        }
    }
}