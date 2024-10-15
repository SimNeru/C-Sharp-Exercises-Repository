using System.Collections;

namespace ThreadingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Come accedere al main thread 'programmalmente'
            // Thread invoker
            Thread mainThread = Thread.CurrentThread;

            // assegno un 'nome' al thread
            mainThread.Name = "Main Thread";

            // stampo l'oggetto mainThread in stringa
            Console.WriteLine(mainThread.ToString());

            // stampo il nome del thread che avevo precedentemente assegnato
            Console.WriteLine(mainThread.Name + " start ");

            // richiamo il metodo eseguito nel thread main
            MethodMain();

            // accedo alla priorità clock cpu (default: Normal)
            ThreadPriority priority = mainThread.Priority;

            Console.WriteLine("Priorità:" + priority.ToString());

            // controllo che il thread sia stato lanciato e sia in esecuzione
            Console.WriteLine("Il main thread è stato lanciato e in esecuzione:" + mainThread.IsAlive);

            // controllo un primo 'stato del thread'
            // valori enum assegnati a degli int che indicheranno il vario stato
            ThreadState state = mainThread.ThreadState;
            Console.WriteLine("Stato del thread: " + state);

            //INIZIO PARTE MULTI-THREADING
            // istanza della classe che conterrà i metodi che ci interessano
            // NumbersCounter numbersCounter = new NumbersCounter();

            // Create first thread, Count UP
            /*
            ThreadStart firstThread = new ThreadStart(
                () => {
                    numbersCounter.CountUp(50);
                    // invoked thread method manually
                    });
            */

            /*
            // Create first PARAMETERIZED THREAD, Count UP
            // Prima creo un delegate object che non invoca il thread method ma stora
            // la reference dell'argument 
             ParameterizedThreadStart firstThread = new ParameterizedThreadStart(
               numbersCounter.CountUp); 

            // Qui creo il thread object che conterrà l'istanza di ParametrizedStart con il delegato
            Thread thread1 = new Thread(firstThread)
            { Name = "Count-Up Thread", Priority = ThreadPriority.Highest };

            // Invoke CountUp attraverso start, il paramatro verrà passato internamente al codice
            MaxCount maxCount = new MaxCount() { Count = 50 };
            thread1.Start(maxCount);
            Console.WriteLine($"{thread1.Name} ({thread1.ManagedThreadId}) is {thread1.ThreadState.ToString()}"); // Running
            */

            // Create second thread, Count DOWN
            /*ThreadStart secondThread = new ThreadStart(
                () => {
                    numbersCounter.CountDown(50);
                    // invoked thread method manually
                });
            */

            /*
            ParameterizedThreadStart secondThread = new ParameterizedThreadStart(
                numbersCounter.CountDown);
            Thread thread2 = new Thread(secondThread)
            { Name = "Count-Down Thread", Priority = ThreadPriority.BelowNormal };

            // Invoke CountDown attraverso start
            MaxCount maxCount2 = new MaxCount() { Count = 50 };
            thread2.Start(maxCount2);
            Console.WriteLine($"{thread2.Name} ({thread2.ManagedThreadId}) is {thread2.ThreadState.ToString()}"); // Running
            */

            //Join interrompe il thread principale che recupererà alla conclusione dei due joinati
            //thread1.join();
            //thread2.join();

            // Thread.Sleep(2000); // 2 sec delay
            // thread 1 get interrupted
            // thread1.Interrupt(); // Interrupts the thread

            // specifico il completamento del main thread

            /* CUSTOM THREAD PARAMETER */
            NumbersUpCounter numbersUpCounter = new NumbersUpCounter()
            { Count = 50};

            // CALLBACK METHOD
            Action<long> callback = (long sum) =>
            {
                Console.WriteLine($"\nReturn value from Count-Up is {sum}");
            };

            ThreadStart threadStart1 = new ThreadStart
                (() => { numbersUpCounter.CountUp(callback); });

            Thread thread1 = new Thread(threadStart1);
            
            thread1.Start();
            
            NumbersDownCounter numbersDownCounter = new NumbersDownCounter()
            { Count = 50};

            ThreadStart threadStart2 = new ThreadStart
                (numbersDownCounter.CountDown);

            Thread thread2 = new Thread(threadStart2);

            thread2.Start();

            Console.WriteLine(mainThread.Name + " completato");

            Console.ReadKey();

        }

        static void MethodMain()
        {
            Console.WriteLine("Metodo he viene eseguito nel main Thread");
        }
    }

    #region SHARED RESOURCES
    class Shared
    {
        public static int SharedResource { get; set; }
    }
    #endregion

    #region PARAMETERIZED THREAD CODE

    /* Classe definita per ParameterizedThreadStart
 
        class MaxCount
        {
            public int Count { get; set; }
        }
    
    class NumbersCounter
    {
        public void CountUp(object? count)
        {
            try
            {
                Console.WriteLine("\nCount Up Started");
                Thread.Sleep(1000);

                // i = 1 to 50
                MaxCount? countInt = (MaxCount?)count;
                if (countInt == null)
                {
                    return;
                }

                for (int i = 0; i <= countInt.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"i = {i}, ");
                    Thread.Sleep(1000); // 1000 milliseconds = 1 sec
                }
                Thread.Sleep(1000);
                Console.WriteLine("\nCount Up Completed\n");
            }
            catch (ThreadInterruptedException ex)
            {
                Console.Write("Count up interrupted");
            }
        }

        public void CountDown(object? count)
        {
            try
            {
                Console.WriteLine("\nCount Down Started");
                Thread.Sleep(1000);

                // i = 50 to 1
                MaxCount? countInt = (MaxCount?)count;

                if (countInt == null)
                {
                    return;
                }

                for (int? j = countInt.Count; j >= 1; j--)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"j = {j}, ");
                    Thread.Sleep(1000); // 1000 milliseconds = 1 sec
                }
                Thread.Sleep(1000);
                Console.WriteLine("\nCount Down Completed\n");
            }
            catch (ThreadInterruptedException ex)
            {
                Console.Write("Count down interrupted");
            }
        }
    } */
    #endregion

    #region CUSTOM THREAD OBJECT
    class NumbersUpCounter
    {
        public int Count { get; set; }

        public void CountUp(Action<long> callback)
        {
            long sum = 0;

            try
            {
                Console.WriteLine("Count Up Started");
                Thread.Sleep(1000);

                // i = 1 to 50
                if (Count == 0)
                {
                    return;
                }

                for (int i = 0; i <= Count; i++)
                {
                    sum += i;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"i = {i}, ");
                    Thread.Sleep(500); // 1000 milliseconds = 1 sec
                }
                Thread.Sleep(1000);
                Console.WriteLine("Count Up Completed");
            }
            catch (ThreadInterruptedException ex)
            {
                Console.Write("Count up interrupted");
            }
            finally 
            {
                callback(sum);
            }
        }
    }

    class NumbersDownCounter
    {
        public int Count { get; set; }
        public void CountDown()
        {
            try
            {
                Console.WriteLine("Count Down Started");
                Thread.Sleep(1000);

                if (Count == 0)
                {
                    return;
                }

                for (int? j = Count; j >= 1; j--)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"j = {j}, ");
                    Thread.Sleep(500); // 1000 milliseconds = 1 sec
                }
                Thread.Sleep(1000);
                Console.WriteLine("Count Down Completed");
            }
            catch (ThreadInterruptedException ex)
            {
                Console.Write("Count down interrupted");
            }
        }
    }
    #endregion

}
