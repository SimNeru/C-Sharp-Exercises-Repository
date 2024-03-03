/* E' un metodo scritto fuori dalla classe ma inserito (injected) logicamente nella classe.
 * Cioè invece di scrivere il codice dentro la classe di appartenenza, viene scritto lo 
 * stesso metodo in un'altra e inserendo logicamente quel metodo nella classe esistente.
 * In altre parole senza modificare il codice sorgente della classe, iniettiamo un nuovo metodo in essa.
 * 
 * Possibile aggiungere metodi di estensioni a classi predefinite parte di .Net Framework
 * o aggiungere metodi estesi ad altre classi definite da altri sviluppatori e fornite come librerie di classi
 * 
 * ESEMPIO: System.String, una classe che contiene un metodo predefinito come ToUpperCase,
 * ma non contiene un metodo tipo ToTitleCase (che potrebbe avere lo scopo di rendere maiuscola
 * solo la prima lettera), usando il concetto è possibile aggiungerlo alla classe predefinita
 * 
 * Per implementare i metodi estesi è richiesta una classe statica obblig
 * aggiungere il metodo statico e il primo parametro deve essere preceduto dalla
 * keyword "this", il metodo statico puoi diventerà d'istanza al momento che sarà inserito
 * nella classe esistente
 */

using System;

class Program
{
    static void Main()
    {
        //create object
        Product p = new Product() { ProductCost = 150, DiscountPercentage = 10 };
        
        //call of the extensione method
        Console.WriteLine($"The {p.DiscountPercentage}% discount on a product's price of {p.ProductCost} is {p.GetDiscount()}");
        Console.ReadKey();
    }
}

//TARGET CLASS
public class Product
{
    //properties
    public int ProductCost { get; set; }
    public int DiscountPercentage { get; set; }
}

public static class ProductExtension
{
    //this indica che il metodo corrente non è ordinario, ma mirato per un estensione
    public static double GetDiscount(this Product product)
    {
        return product.ProductCost * product.DiscountPercentage / 100;
    }
}
