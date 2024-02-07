public class Employee
{
    //Ogni classe in C# deve avere un costruttore, inizializzato automatico

    //fields
    public int id;
    public string name;
    public string job;

    /* INSTANCE CONSTRUCTOR 
     * Inizializza i campi dell'istanza (fields)
     * Eseguito ogni volta automaticamente alla creazione
     * di oggetto della classe
     * Modicatori di accesso presenti
     */

    public Employee() 
    { 
        this.id = 101;
        this.name = "No name";
        this.job = "some job title";
    }

    public Employee(int id, string name, string job)
    {
        this.id = id;
        this.name = name;
        this.job = job;
    }

    /* STATIC CONSTRUCTOR
     * Inizializzato con lo static
     * Viene eseguito unica volta, quando il primo oggetto viene
     * creato per la classe o quando viene effettuato l'accesso 
     * alla classe tramite l'ausilio del metodo MAIN
     * Modificatore accesso non modificabile
     */

    public static string companyName;

    static Employee()
    {
        companyName = "ABC Company";
    }
}



