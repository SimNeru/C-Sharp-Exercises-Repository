using System;

public class Sample
{
    //target method 1
    public void Add(double a, double b) 
    {
        double c = a + b;
        Console.WriteLine("Addiction result is: " + c);
    }

    //target method 2
    public void Multiply(double a, double b) 
    {
        double c = a * b;
        Console.WriteLine("Multiplication product is: " + c);
    }

    //target method 3
    public void Subtract(double a, double b)
    {
        double c = a - b;
        Console.WriteLine("Subtraction difference is: " + c);
    }

    //target method 4
    public void Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Can't divide by 0");

        }
        else 
        { 
        double c = a / b;
        Console.WriteLine("Division result is: " + c);
        }
    }
}

