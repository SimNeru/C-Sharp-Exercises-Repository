using static System.Console;

public partial class Product
{
    //partial method con definizione
    partial void GetTax() 
    {
        double tax = Cost * 10/100;
        WriteLine("Tax: " + tax); ;
    }
}

