using System;
using System.ComponentModel;
using DelegatesRelated;

/* DELEGATES
 * Sono oggetti speciali che memorizzano un riferimento a un metodo,
 * possono uno o più di uno, garantendo un accesso indiretto ai metodi diversamente
 * dalla creazione di un oggetto di una data classe e invocando il metodo attraverso l'oggetto
 * Nei real-time-projects non c'è un vero vantaggio, in compenso sono molto utili per la
 * costruzione di eventi.
 * 
 * I Delegati vengono usati nei real-time projects solo utilizzando eventi.
 * 
 * I tipi delegati sono derivati da System.Delegate, sono "classi" internamente
 * e creerà oggetti basati sul tipo di delegato, e nell'oggetto delegato effettivo
 * memorizzerà i riferimenti di uno o più metodi che soddisfano i parametri e i tipi
 * restituiti che sono definiti dal tipo di delegato.
 * 
 * "public delegate ReturnType DelegateTypeName(param1, param2)" -> Creating Delegate
 * (creato tipo delegato che internamente è anche una classe, quindi creabile una variabile i riferimento
 * per il tipo di delegato, proprio come fosse una classe)
 * 
 * "DelegateTypeName ReferenceVariable = MethodName;" -> Creating Delegate Object
 * memorizzabile il riferimento a uno o più metodi, che possono appartenere a qualunque altra classe, statico o d'istanza
 * 
 * "ReferenceVariable.Invoke(arg1, arg2, ..);"
 * Invocabile poi quindi lo stesso metodo attraverso Invoke del delegato
 */

class Program
{
    static void Main()
    {
        //create object of Sample class
        Sample referenceToSampleObject = new Sample();

        //create delegate reference, add method reference to delegate object
        MyDelegateType myDelegateType;

        myDelegateType = new MyDelegateType(referenceToSampleObject.Add);

        //invoke method to call Add
        myDelegateType.Invoke(30, 40);
        Console.ReadKey();

        //multi cast delegates
        MyDelegateType myMultiCastDelegateType = referenceToSampleObject.Subtract;

        //add ref of second target method
        myMultiCastDelegateType += referenceToSampleObject.Multiply;
        myMultiCastDelegateType += referenceToSampleObject.Divide;

        //invoking both target methods 
        myMultiCastDelegateType.Invoke(40, 10);
        Console.ReadKey();

        //removing ref target method
        myMultiCastDelegateType -= referenceToSampleObject.Divide;
        myMultiCastDelegateType -= referenceToSampleObject.Multiply;

        //invoking only subtraction
        myMultiCastDelegateType.Invoke(10.5, 65.3);
        Console.ReadKey();
    }
}