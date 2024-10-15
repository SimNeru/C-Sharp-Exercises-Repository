using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousLesson
{
    /*
     * Per programmazione asincrona si intende un paradigma di programmazione
     * che consente a delle operazioni di essere eseguite indipendentemente e contemporaneamente,
     * senza il blocco del thread principale in esecuzione
     * 
     * Async usato per rendere un metodo, lambda o metodo anonymous come asincrono
     * Il type return solitamente è Task o Task <T>, dove T sta per il tipo del risultato
     * 
     * Il metodo asyncrono si chiama ponendo la keyword 'await' è opzionale ma suggerita
     * lì il metodo pausa la sua esecuzione in attesa di una risposta di un metodo asincrono,
     * inoltre cede il 'controllo di esecuzione' indietro al chiamante finché il metodo asincrono è completato
     * 
     * Good Practices:
     * Evitare ritorno di void, non ci sarà errori runtime ma non compatibili con wait keyword
     * Handle Exceptions nel modo giusto
     * Async Await ideali per le I/O-bound operazioni, come gestio di file, network requestes o queries al db. Non ci sono benefici di performace con operazioni legate alla CPU
     * Essere sicuri di propagare l'asincronia di un metodo fino alla fine dell'ordine di esecuzione dei metodi in esso
     * Evitare uso di Task.Run() per scaricare lavoro in sincrono su un thread di background con un metodo asincrono, usa await altrimenti rischia perdita performance
     * Usare un CancellationToken per cancellazione all'interno dei metodi asyncroni, per ottimizzazione
     * 
     */

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
