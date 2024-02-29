/* System.Object è una classe predefinita di sistema
 * ed è la classe super di una classe base in .Net
 * 
 * class System.Object ----> Classes, Interfaces
 * '-----------------------> System.ValueType ----> Structures, Enumerations
 * 
 * System.Object possiede dei metodi:
 * - Equals: riceve un valore da parametro di tipo oggetto e restituisce true o false in caso o meno di uguaglianza
 * - GetHashCode: restituisce un valore numerico per verificare che due oggetti siano uguali, usato assieme alle collezioni hash table o hash set
 * - GetType: restituisce il nome della classe per la quale l'oggetto viene creato
 * - ToString: restituisce il nome della classe, sovrascrivibile per restitutire altre informazioni relative
 */

class Program
{
    static void Main()
    {
        //create an object of Person class
        System.Object obj = new Person { PersonName = "Scott", Email = "scott@mail.com" };

        //access methods
        Console.WriteLine(obj.Equals(new Person())); //false perché i valori dei campi non "matchano" con quelli dei parametri
        Console.WriteLine(obj.Equals(new Person() { PersonName = "Scott", Email = "scott@mail.com" } )); //sempre false, poiché uno è l'originale e uno creato in secondo luogo, quindi trattasi di due oggetti separati
        //restituirà true perché prenderà il metodo overridato in cui è definita la logica che comparerà il parametro di un oggetto passato con i suoi relativi dati nei campi

        /*System.Object a = new Person() { PersonName = "A", Email = "A@mail.com" }; ;
        System.Object b = new Person() { PersonName = "B", Email = "B@mail.com" }; ;
        b = a;
        Console.WriteLine(a.Equals(b)); //sarà true, poiché condividono anche la variabile di riferimento oltre che ai parametri
        */

        //Hashcode utile per comparare valore oggetto da inserire in un hashtable o altre collezioni simili (raramente overridibile)
        Console.WriteLine(obj.GetHashCode());

        //ToString method di default restituisce il nome della classe, oppure se overridato restituirà la logica definita
        Console.WriteLine(obj.ToString());

        Console.WriteLine(obj.GetType());

        //nei progetti in tempo reale, comparazione, conoscere tipi oggetto sono metodi utili
        //System.Object utile per la type safety
        Console.ReadKey();

        /* BOXING è il passaggio da valueType a ReferenceType
         * ex: int value -> System.Object value 
         * int è una structure, System.Object una classe,
         * in C# viene eseguito automaticamente
         */

        //primitive variable
        int x = 10;

        //boxing (value-type to reference type)
        object boxing = x;
        //convertito dalla struttura System.Int32 alla System.Object
        Console.WriteLine(x); //Output 10
        Console.WriteLine(boxing); //Output 10

        //Generalmente non interessa, ma avviene internamente
        Console.ReadKey();

        /* UNBOXING è il passaggio da ReferenceType a ValueType
         * avviene solo in caso di Types Data compatibili
         * ex: System.Object value -> int value
         * avviene esplicitamente con una sintassi precisa
         * Sintassi: (DestinationDataType) SourceValue
         */

        //reference type variable, valore '10' conservato sullo heap dell'oggetto
        //qua copiando lo stesso valore sullo heap, nello stack del metodo main
        object unboxing = 10;

        //unboxing (reference-type to value-type)
        int y = (int)unboxing;

        Console.WriteLine(y); //Output 10
        Console.WriteLine(unboxing); //Output 10

        //copiare il valore dall'Heap allo Stack si parla di UNBOXING
    
        /* A COSA SERVE:
         * Quando nei progetti in tempo reale, non si è sicuri di che tipo di dato usare,
         * usiamo il System.Object poiché funge da genitore per tutti i tipi in C#
         */
    }
}