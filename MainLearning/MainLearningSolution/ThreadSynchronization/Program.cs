namespace ThreadSynchronization
{

    /*
     * MONITOR: lo scopo di monitor è di assicurarsi che venga eseguito solo un thread alla volta, anche se il risultato finale potrebbe essere diverso poi l'ordine di esecuzione comunque dei threads potrebbe invertirsi
     * 
     */

    class Shared 
    {
        public static int SharedResource { get; set; } = 0;
        // non vogliamo che questo oggetto venga cambiato, in quel caso altrimenti potrebbe essere tratto come uno diverso e la classe Monitor
        // potrebbe erroneamente poi acconsentire l'accesso alla 'shared resource'
        public static readonly object lockObject = new object();
    }

    class NumbersUpCounter
    {

        // critical code è il nome per la parte di codice che mira ad accedere alla 'shared resource'
        public void CountUp()
        {
            try
            {
                Console.WriteLine("Count Up Started");
                Thread.Sleep(1000);

                for (int i = 0; i <= 10; i++)
                {
                    Monitor.Enter(Shared.lockObject); // wait for lock gets opened
                    Console.WriteLine($"Shared Resource in Count-Up: {Shared.SharedResource}");

                    // Data shared tra i threads 
                    Shared.SharedResource++;

                    Monitor.Exit(Shared.lockObject); // close lock

                    Console.ForegroundColor = ConsoleColor.Green;
                    Thread.Sleep(100); // 1000 milliseconds = 1 sec
                }
                Thread.Sleep(1000);
                Console.WriteLine("Count Up Completed");
            }
            catch (ThreadInterruptedException ex)
            {
                Console.Write("Count up interrupted");
            }

        }
    }

    class NumbersDownCounter
    {
        public void CountDown()
        {
            try
            {
                Console.WriteLine("Count Down Started");
                Thread.Sleep(1000);

                for (int? j = 10; j >= 1; j--)
                {
                    // Monitor.Enter(Shared.lockObject); // wait for lock gets opened
                    // scrivibile anche
                    lock (Shared.lockObject)
                    { 
                        Console.WriteLine($"Shared Resource in Count-Down: {Shared.SharedResource}");
                        Shared.SharedResource--;
                    }
                    // Monitor.Exit(Shared.lockObject);
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Thread.Sleep(100); // 1000 milliseconds = 1 sec
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

    internal class Program
    {
        static void Main(string[] args)
        {

            Thread mainThread = Thread.CurrentThread;

            mainThread.Name = "Main Thread";

            NumbersUpCounter numbersUpCounter = new NumbersUpCounter();

            Action<long> callback = (long sum) =>
            {
                Console.WriteLine($"\nReturn value from Count-Up is {sum}");
            };

            ThreadStart threadStart1 = new ThreadStart
                (numbersUpCounter.CountUp);

            Thread thread1 = new Thread(threadStart1);

            thread1.Start();

            NumbersDownCounter numbersDownCounter = new NumbersDownCounter();

            ThreadStart threadStart2 = new ThreadStart
                (numbersDownCounter.CountDown);

            Thread thread2 = new Thread(threadStart2);

            thread2.Start();

            Console.WriteLine(mainThread.Name + " completato");
            Console.WriteLine($"\nShared Resource: {Shared.SharedResource}"); // Expected: 0 o -1

            Console.ReadKey();
        }
    }
    
}
