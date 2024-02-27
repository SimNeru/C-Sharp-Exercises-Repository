using static System.Console;
using static Country;

class Program
{
    /* Classi statiche accettano solo membri statici, scopo evitare
    * creazione di oggetti accidentali
    */
    static void Main()
    {
        //create object of static class
        //Country country = new Country(); ERROR

        WriteLine($"{CountryName}'s territory is formed by a total of {NoOfRegions} regions and {GetNoOfIndependentStates()} independent states.");

        ReadKey();
    }
}
