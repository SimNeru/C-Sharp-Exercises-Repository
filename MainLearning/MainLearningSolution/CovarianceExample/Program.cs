using System.Diagnostics.Metrics;

namespace CovarianceExample
{
    class LivingThing 
    { 
        public int NumberOfLegs { get; set; }
    }
    
    class Parrot : LivingThing 
    { 

    }
    
    class Dog : LivingThing 
    { 

    }

    interface IMoverCovariance<out T> 
        // out keyword significa che questo tipo di parametro generico, solo come return type di un metodo o di una proprietà
    {
        T Move();
        //T MoveNo(T x); non concesso perché controvariante
    }

    interface IMoverContravariance<in T>
    {
        void Move(T x);
    }

    class MoverCovariance<T> : IMoverCovariance<T> 
    {
        public T thing { get; set; }
        public T Move() 
        {
            return thing;
        }
    }

    // contravariance
    class MoveContravariancer<T> : IMoverContravariance<T>
    {
        public T thing { get; set; }
        public void Move( T x )
        {
            if (x is Parrot)
            Console.WriteLine("Moving with " + (x as Parrot).NumberOfLegs + " legs");
            else
            Console.WriteLine("Moving with " + (x as Dog).NumberOfLegs + " legs");
        }
    }

    class Sample
    {
        public void PrintValues(IEnumerable<object> values) 
        {
            foreach (string value in values) 
            { 
                Console.Write(value + ", ");
            }
            Console.WriteLine();
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            //create object
            LivingThing livingThing = new Parrot(); // not covariance, normal behaviour ereditarietà

            Parrot parrot = new Parrot() { NumberOfLegs = 2 }; // normal

            //IMover<LivingThing> mover = new Mover<Parrot>(); C# non lo consente,
            //le classi sono usati come parametri di tipo generico, di default senza generici viene consentito
            //per il principio dell'ereditarietà, con i generics no

            #region Covariance
            IMoverCovariance<LivingThing> mover = new MoverCovariance<Parrot>() { thing = parrot }; // covariance con uso di out
            
            Console.WriteLine("Moving with " + mover.Move().NumberOfLegs + " legs"); 
            //LivingThing vs Parrot, supplying the child type (Parrot), where the parent type (LivingThing) is expected

            //Covariance in real life
            Sample s = new Sample();
            s.PrintValues(new List<object>() { "hello", "world" });
            #endregion

            #region Contravariance
            //Contravariance = fornisci il nome tipo del genitore, dove il tipo figlio è aspettato
            IMoverContravariance<Parrot> obj1 = new MoveContravariancer<LivingThing>() { thing = parrot }; // controvariance con uso di in
            obj1.Move(parrot);

            Dog dog = new Dog() { NumberOfLegs = 4 };
            IMoverContravariance<Dog> obj2 = new MoveContravariancer<LivingThing>() { thing = dog };
            obj2.Move(dog);
            #endregion

            Console.ReadLine();
        }
    }
}
