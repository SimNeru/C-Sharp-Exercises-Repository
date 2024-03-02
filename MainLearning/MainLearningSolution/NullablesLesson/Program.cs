using System;

namespace NullablesLesson
{
    internal class Program
    {
        static void Main()
        {
            //create object
            //oggetti classi nullable by default, structures come int no
            Person p1 = new Person() { NoOfChildren = 2, Age = 20 };
            Person p2 = new Person() { NoOfChildren = 5 };
            Person p3 = null;
            Person p4 = new Person() { NoOfChildren = null };


            Console.WriteLine(p1.NoOfChildren);

            //HasValue accede ai nullables
            if (p4.NoOfChildren.HasValue)
            {
                Console.WriteLine(p4.NoOfChildren.Value);
            }

            if (p2.NoOfChildren.HasValue)
            {
                Console.WriteLine(p2.NoOfChildren.Value);
            }
            Console.ReadKey();

            // OPERATORE COALESCENZA NULLO --------------------------------
            // Controlla se il valore è nullo o no:
            // Restituisce operando a sinistra se il valore non è nullo
            // Restituisce operando a destra se il valore è nullo
            // Semplifica sintassi dello stato "if" se un valore è nullo o no

            // variableName ?? valueIfNull

            //se (p4.NoOfChildren.HasValue) stamperà il valore, altrimenti stamperà il valore assegnato a destra ovvero 0
            Console.WriteLine((p4.NoOfChildren.HasValue) ? p4.NoOfChildren.Value : 0);

            Console.WriteLine((p2.NoOfChildren.HasValue) ? p2.NoOfChildren.Value : 0);

            //sintassi ulteriormente semplificabile
            Console.WriteLine(p4.NoOfChildren ?? 0);

            Console.ReadKey();

            // NULL PROPRAGRATION OPERATOR --------------------------------
            // Accede ad un campo, proprietà o metodo di una particolare
            // variabile di riferimento solo quando essa non è uguale a null

            Console.WriteLine((p1 == null)? null : Convert.ToString(p1.Age));
            //scrivibile anche
            Console.WriteLine(p1?.Age);

            Console.ReadKey();
        }
    }

    public class Person
    {
        //per dichiararlo nullable si può usare o il ? oppure usare Nullable

        public Nullable<int> NoOfChildren { get; set; }

        public int Age;
    }
}
