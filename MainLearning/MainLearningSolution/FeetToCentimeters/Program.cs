/*
 * Instructions
    Eg:
    feet = 5
    inches = 7
    output: 170.18 cm

    Formula:
    1 inch = 2.54 cm
    1 feet = 12 inches
 */

using System;
using System.Globalization;

class Program 
{
    public static void Main()
    {
        Console.WriteLine("Welcome to centimeter converter");
        var result = Converter.CentimetersConverter();
        Console.WriteLine($"The result is {result}");
        Console.ReadLine();
    }
}

public class Converter 
{ 
    public static double CentimetersConverter() 
    {
        double inches = 0;
        double feets = 0;
        double tot = 0;
        Console.WriteLine("Digit the inches");
        inches = double.Parse(Console.ReadLine());
        tot += inches * 2.54;
        Console.WriteLine("Digit the feets");
        feets = double.Parse(Console.ReadLine());
        tot += feets * 30.48;
        return tot;
    }
}

/*bool condition = false;
        
        Console.WriteLine("Welcome to feets and inches converter, please choose an option:\n 1. To convert in feets \n 2. To convert in inches \n 3.Exit");
        
        do
        {
            int option = int.Parse(Console.ReadLine());
            double number;

            switch (option) 
            { 
                case 1:
                    Console.WriteLine("Please digit a number you would like to convert:");
                    number = double.Parse(Console.ReadLine());

                    break;
                    
                case 2:
                    Console.WriteLine("Please digit a number you would like to convert:");
                    number = double.Parse(Console.ReadLine());
                    break;
                
                case 3:
                    condition = true;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Please digit a valid option");
                    continue;
            }
        } while (!condition);
        
        Console.WriteLine("Please digit a number you would like to convert from feets to inches:");
    }*/
