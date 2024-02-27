using static System.Console;

/* CLASSI PARZIALI UTILI PER SPLITTARE IL LAVORO TRA PIU' SVILUPPATORI
 * SU UNA STESSA CLASSE, DEVONO AVERE LO STESSO NOME, DEVONO CONDIVIDERE ANCHE
 * L'EVENTUALE NAMESPACE
 * 
 * Metodi parziali dichiarati in una classe parziale, come un metodo astratto
 * ed implementati in un altra classe parziale, devono essere vuoti e privati
 */

class Program
{
    static void Main()
    {
        Product product = new Product();

        product.ProductID = 101;
        product.Cost = 1000;

        product.CallGetTax();

        ReadKey();
    }
}
