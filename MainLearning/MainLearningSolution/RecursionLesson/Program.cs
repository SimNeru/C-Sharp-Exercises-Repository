using System;

class Sample 
{ 
    public double Factorial(int number) 
    {
        int store = number;
        if (number == 0) 
        { 
            return 1; 
        }
        else 
        {
            Console.WriteLine($"Call is {number} * Factorial({--store})");
            
            return number * Factorial(number - 1);
        }
    }
}

class Program 
{
    public static void Main() 
    {
        //read number from keyboard
        System.Console.WriteLine("Enter a number:");
        int n = int.Parse(System.Console.ReadLine());

        //create object
        Sample sample = new Sample();
        
        //call Factorial method
        double fact = sample.Factorial(n);
        System.Console.WriteLine($"Factorial of {n} is {fact}");
        System.Console.ReadKey();

        //n=5
        //Factorial(5) = 5 * Factorial(4)
        //Factorial(4) = 4 * Factorial(3)
        //Factorial(3) = 3 * Factorial(2)
        //Factorial(2) = 2 * Factorial(1)
        //Factorial(1) = 1 * Factorial(0)
        //Factorial(0) =  1
        //Factorial(1) =  1 * 1
        //Factorial(2) =  2 * 1
        //Factorial(3) =  3 * 2
        //Factorial(4) =  4 * 6
        //Factorial(5) =  120
    }
}
