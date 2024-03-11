using System;
using System.IO;
using EventsLesson;

/* EVENTS, sono delegati multicast
 * creati e richiamati nella classe Publisher e sottoscritto nella Subscriber
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
    }
}

/* Anonymous methods sono "metodi senza nome" che possono essere invocati
 * attraverso la variabile delegato o un evento
 */

/* Lambda expression, cavalcano il concetto degli metodi anonimi ma
 * offrono sintassi più conveniente rispetto metodi anonimi.
 */
