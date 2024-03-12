using System;
using System.IO;
using EventsLesson;

/* EVENTS, sono delegati multicast
 * creati e richiamati nella classe Publisher e sottoscritto nella Subscriber*/

/* Anonymous methods sono "metodi senza nome" che possono essere invocati
 * attraverso la variabile delegato o un evento */

/* Lambda expression, cavalcano il concetto degli metodi anonimi ma
 * offrono sintassi più conveniente rispetto metodi anonimi.*/

/* Inline Lamda Expression, usabili per un singolo calcolo o singole condizioni*/

/* Func, delegato pre-definito con parametri 
 * public Func <Param1DataType, Param2DataType, ReturnType> referenceVariable;*/

/* Action, delegato con parametri ma senza return */

/* Predicate, può essere usato come Func, ma deve restituire un booleano e avere un solo
 * un parametro di qualsiasi tipo */

/* EVENT HANDLER, è un tipo delegato preferito per eventi ed ha due parametri principali
 * l'object sender e l'EventArgs, senza return.
 * 
 * il Mittente è il tipo oggetto, che rappresenta oggetto corrento della classe sottoscrittore
 * tradotto indica a quale classe ti sottoscrivi, lo stesso oggetto corrente come parametro "sender" (inviante)
 * La classe "subscriber" può essere una qualunque, per questo il tipo dati "sendere" è un oggetto
 * object in questo caso rappresenta System.Object, l'ultima classe padre di tutte le classi, strutture e altri tipi in C#
 * 
 * Il secondo parametro, Event Args, sono i parametri i valori aggiuntivi che desideriamo
 * fornire al metodo di "subscription", di default non contiene proprietà quindi non si potranno
 * passare valori al medoto "subscription", ma è possibile creare una classe figlia per EventArgs,
 * nella quale sia possibile definirne le proprietà e fornirle durante la generazione dell'evento.
 * Uso con eventi predefiniti in WinForms, WPF, o Asp.Net Web Forms.
 * In Asp.Net Core o Asp.Net Mvc è difficile. */

/* Expression Trees, è una collezione di delegati rappresentati da una struttura ad albero,
 * usati poco nei real time projects manualmente, ma usati indirettamente con l'ausilio di LINQ.
 * C'è un delegato padre contenente uno o più delegati figli, che a loro volta possono avere altri figli.
 * Le Expression Trees prima necessitano di essere compilati e solo successivamente invocati, attraverso
 * il metodo prima Compile e successivamente Invoke.
 * Una volta invocato l'Expression Tree tutti i delegati associati verrano eseguiti con un approccio
 * dal basso all'alto, eseguendo prima i figli e poi i padri a seconda dei risultati.
 */

class Program
{
    static void Main()
    {
        //create object of Subscriber class
        Subscriber subscriber = new Subscriber();

        //create object of Publisher class
        Publisher publisher = new Publisher();
        Publisher publisherForLambda = new Publisher();
        Publisher publisherByFunc = new Publisher();
        Publisher publisherByAction = new Publisher();
        Publisher publisherByPredicate = new Publisher();

        //handle the event (or) subscribe to event
        publisher.myEvent += subscriber.Add;

        //anonymous method
        /*publisher.myEvent += delegate (int a, int b)
        {
            Console.WriteLine(a + b);
        };*/

        //lambda expression invocation
        publisherForLambda.myEventImplicit += (a,b) =>
        {
            int c = a + b;
            return c;
        };

        //lamda inline expression
        publisherForLambda.myEventImplicit += (a, b) => a + b;
        //lamda inline expression for func
        publisherByFunc.myEventFunc += (a, b) => a + b;

        //lambda expression invocation for Action
        publisherByAction.myEventAction += (a, b) =>
        {
            int c = a + b;
            Console.WriteLine($"{a} + {b} = {c}");
        };

        //lambda expression invocation for Predicate
        publisherByPredicate.myEventPredicate += (a) =>
        {
            return a >= 0;
        };

        //invoke the Event
        publisher.RaiseEvent(10,20);
        publisher.RaiseEvent(50, 35);
        publisher.RaiseEvent(5,9);
        Console.ReadKey();

        Console.WriteLine("Lambda part");
        Console.WriteLine(publisherForLambda.RaiseEventForLambda(10,20));
        Console.WriteLine(publisherForLambda.RaiseEventForLambda(5,80));
        Console.WriteLine(publisherForLambda.RaiseEventForLambda(14,22));
        Console.ReadKey();

        Console.WriteLine("Func part");
        Console.WriteLine(publisherByFunc.RaiseEventByFunc(2,3));
        Console.ReadKey();

        Console.WriteLine("Action part");
        publisherByAction.RaiseEventByAction(6, 6);
        Console.ReadKey();

        Console.WriteLine("Predicate part");
        Console.WriteLine("8 is positive? " + publisherByPredicate.RaiseEventByPredicate(8));
        Console.WriteLine("-5 is positive? " + publisherByPredicate.RaiseEventByPredicate(-5));
        Console.WriteLine("0 is positive? " + publisherByPredicate.RaiseEventByPredicate(0));
        Console.ReadKey();
    }
}