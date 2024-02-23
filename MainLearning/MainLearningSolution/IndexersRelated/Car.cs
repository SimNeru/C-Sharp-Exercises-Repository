/*
 * INDEXERS
 * Raro utilizzo ma possono risultare utili
 * Facilitano l'accesso a un array che è archiviato all'interno di un campo
 * (ad esempio una stringa che contiene più nomi separati da virgole o un array)
 * Un Array è una raccolta di più valori dello stesso tipo di dati.
 * Mettiamo che vogliamo semplificare l'accesso a quella particolare matrice o stringa dall'esterno classe
 *
 *
 * Indexers are always created with 'this' keyword
 * Indexers are generally used to access group of elements (items)
 * Parameterized properties are called indexer
 * Indexers are implemented through GET and SET accessors along with the [ ] operator
 * Indexers must have one or more parameters
 * ref and out parameter modifiers are not permitted in indexer
 * Indexer can't be static
 * Indexer is identified by its signature (syntax of calling), where as property is identified it's name
 * Indexer can be overloaded
 */

using System;

public class Car
{
    //private
    private string[] _brands = new string[] { "BMW", "Skoda", "Honda" };
    private string[] _names = new string[] { "first", "second", "third" };


    //public indexer
    public string this[int index]
    {
        //assegnabile il valore che desideriamo con il set, sulla posizione dell'index che passiamo della array
        set { this._brands[index] = value; }

        get { return this._brands[index]; }
    }

    //Indexer Overload
    public string this[string name]
    {

        /* Array.IndexOf cerca un valore all'interno dell'array appropriato
         * Metodo statico che cerca all'interno di un'array (_names) il valore appropriato (name)
         * Quindi una volta eseguito restituirà l'indice su cui è situato il valore
         * e qua successivamente verrà assegnato il valore rispettivo con il SET o recuperato con il GET
         */

        set { this._brands[Array.IndexOf(_names, name)] = value; }

        get { return this._brands[Array.IndexOf(_names, name)]; }
    }
}