/*The radius value can be assigned to a variable; need not to take the value from the keyboard input.

Formula: PI* radius * radius
PI is a constant value, approximately equal to 3.14159, which is equal to the ratio of the circumference of any circle to its diameter.*/

using System;

public class Circle 
{
    public double radius;
    public const double pi = 3.14159;

    public double CalculateArea(double radius) 
    { 
        return pi * (radius * radius);
    }
}

public class Program 
{ 
    public static void Main() 
    {
        Circle circle = new Circle();

        Console.WriteLine("Please insert a radius:");
        double input = double.Parse(Console.ReadLine());
        Console.WriteLine($"Given the radius of {input}, circle area is {circle.CalculateArea(input)}");
        Console.ReadLine();
    }
}
