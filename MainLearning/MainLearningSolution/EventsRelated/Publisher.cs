using System;
using System.ComponentModel;

/* Auto-Implemented Events, forniscono una shortcut per creare eventi 
 * con meno codice, senza necessità si creare "add" e "remove" accessors
 * con il compiler che lo eseguirà automaticamente */

//delegate type
public delegate void MyDelegateType(int a, int b);
public delegate int MyDelegateTypeInt(int a, int b);

//child class of Event Args
public class CustomEventArgs:EventArgs
{
    public int a { get; set; }
    public int b { get; set; }
}

//publisher
public class Publisher
{
    //private delegate
    private MyDelegateType myDelegate;
    //rimovibile per l'auto implementazione

    //step 1: event
    public event MyDelegateType myEvent
    {
        add
        {
            myDelegate += value;
        }
        remove
        {
            myDelegate -= value;
        }
    }

    /* step 1: autoimplement senza add e remove*/
    public event MyDelegateTypeInt myEventImplicit;

    //step 1: create event Func, tra le <> ci sono vari tipi generici che possono essere presi fino a 16, e poi restituiti
    public event Func<int, int, int> myEventFunc;

    //step 1: create event for Action, must be void
    public event Action<int, int> myEventAction;

    //step 1: create event for Action, return void
    public event Predicate<int> myEventPredicate;

    //step 1: create event for EventHandler, return void
    public event EventHandler<CustomEventArgs> myEventHandler;

    //step 2: raise event
    public void RaiseEvent(int a, int b)
    {
        if (this.myDelegate != null)
        {
            this.myDelegate(a, b);
        }
        /* step 2: raise event con autoimplement
         * if (this.myEvent != null)
         * {
         *    int x = this.myEvent(a,b);
         *    return x;
         * }
         *    else
         * {
         *    return 0;
         * }
         */
    }

    public void RaiseEventByEventHandler(int a, int b)
    {
        if (this.myEventHandler != null)
        {
            CustomEventArgs customEventArgs = new CustomEventArgs() { a = a, b = b };
            /* nel subscription method si riceve i valori al secondo parametro, mentre lo scopo
            del primo è conoscere il data type della classe subscription */
            this.myEventHandler(this,customEventArgs);
        }
    }

    public int RaiseEventForLambda(int a, int b)
    {
        if (this.myEventImplicit != null)
        {
            int x = this.myEventImplicit(a, b);
            return x;
        }
        else
        {
            return 0;
        }
    }

    public int RaiseEventByFunc(int a, int b)
    {
        if (this.myEventFunc != null)
        {
            int x = this.myEventFunc(a, b);
            return x;
        }
        else
        {
            return 0;
        }
    }

    public void RaiseEventByAction(int a, int b)
    {
        if (this.myEventAction != null)
        {
            this.myEventAction(a, b);
        }
        else
        {
            Console.WriteLine("myEventAction is null");
        }
    }

    public bool RaiseEventByPredicate(int a)
    {
        if (this.myEventPredicate != null)
        {
            bool result = this.myEventPredicate(a);
            return result;
        }
        else
        {
            return false;
        }
    }
}