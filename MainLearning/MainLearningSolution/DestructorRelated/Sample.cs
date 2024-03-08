public class Sample
{
    //constructor
    public Sample() 
    {
        //file & db connection logic here
        System.Console.WriteLine("File is opened");
    }

    /* destructor
     * eseguito automaticamente prima di eliminare oggetto memoria
     * solitamente oggetti eliminati alla chiusura dell'applicazione
     */
    ~Sample() 
    {
        //file & db closing logic here
        System.Console.WriteLine("File is closed");
    }

    /* IDispose è un'interfaccia per funzionalità simile al Distruttore
     * tuttavia: il distruttore non è controllabile e viene eseguito in automatico
     * l'interfaccia se la implementiamo, lo possiamo chiamare esplecitamente
     * non eliminano oggetti ma risorse inutilizzate
     */
}

