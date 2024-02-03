/*
 * If the number's last three digits are greater than or equal to 500; it should "round up" the number.
 * If the number's last three digits are less than 500; it should "round down" the number.
 * If the number is less than 500; it should round up to 1000.
 * 
 * Eg:
 * Input: 499  Output: 1000
 * Input: 500  Output: 1000
 * Input: 999  Output: 1000
 * Input: 1000 Output: 1000
 * Input: 1499 Output: 1000
 * Input: 1500 Output: 2000*/

using System;

class Program
{
    static void Main() 
    {
        Console.WriteLine("Input a number");
        int input = int.Parse(Console.ReadLine());
        
        if (input < 1500) 
        { 
            input = 1000;
        } 
        else if (input < 2500) 
        {
            input = 2000;
        }

        Console.WriteLine("Rounded to:");
        Console.WriteLine(input);

        Console.ReadKey();
    }
}



