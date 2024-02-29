
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
        System.Object obj = new Person { PersonName = "Scott", Email= "scott@mail.com" };
    }
}

