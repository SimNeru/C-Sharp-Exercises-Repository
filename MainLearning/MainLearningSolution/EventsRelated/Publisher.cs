using System.ComponentModel;
/* Auto-Implemented Events, forniscono una shortcut per creare eventi 
 * con meno codice, senza necessità si creare "add" e "remove" accessors
 * con il compiler che lo eseguirà automaticamente */

//delegate type
public delegate void MyDelegateType(int a, int b);
public delegate int MyDelegateTypeInt(int a, int b);

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

    public void RaiseEvent(int a, int b)
    {
        //step 2: raise event
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
}

 /* Auto-Implemented Events, forniscono una shortcut per creare eventi 
  * con meno codice, senza necessità si creare "add" e "remove" accessors
  * con il compiler che lo eseguirà automaticamente
  */


