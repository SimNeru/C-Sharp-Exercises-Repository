namespace WaitAndPulse
{
    static class Shared
    {
        // Lock object to be used by both Producer and Consumer threads
        public static object LockObject = new object();
        // Buffer to store int data values
        public static Queue<int> Buffer = new Queue<int>();
        public const int BufferCapacity = 5; // maximum capacity of the buffer (queue)

        public static void Print()
        {
            //O/P: Buffer: 1,2,3,4,5
            Console.WriteLine("Buffer: ");
            foreach (int item in Buffer)
            {
                Console.WriteLine($"{item}, ");
            }
            Console.WriteLine();
        }
    }
    class Producer
    {
        public void Produce()
        {
            Console.WriteLine($"Producer: Generating data");

            for (int i = 0; i < 10; i++)
            {
                lock (Shared.LockObject)
                {
                    Console.WriteLine("Producer: Generating data");
                    Thread.Sleep(7000); // 7 secs
                    if (Shared.Buffer.Count == Shared.BufferCapacity)
                    {
                        // Buffer is full
                        Console.WriteLine("Buffer is full. Waiting for signal from consumer");
                        Monitor.Wait(Shared.LockObject); // wait signal from consumer thread
                    }

                    Shared.Buffer.Enqueue(i);
                    Console.WriteLine($"Producer produced: {i} ");
                    Shared.Print();

                    Monitor.Pulse(Shared.LockObject); // Wake-up consume thread
                }
            }
            Console.WriteLine($"Production Completed");
        }
    }

    class Consumer
    {
        public void Consume()
        {
            Console.WriteLine($"Consumer: Consumption started");

            for (int i = 0; i < 10; i++)
            {

                lock (Shared.LockObject)
                {
                    if (Shared.Buffer.Count == 0)
                    {
                        Console.WriteLine("Buffer is empty. Waiting for signal from producer");
                        // Wait signal from any other thread (like producer)
                        Monitor.Wait(Shared.LockObject);
                    }
                }

                Thread.Sleep(2500); // 2.5 secs delay

                lock (Shared.LockObject)
                {
                    int res = Shared.Buffer.Dequeue();
                    Console.WriteLine($"Consumed: {res}");

                    // Signal the producer that there is a space in the buffer
                    Monitor.Pulse(Shared.LockObject);
                }
            }

            Console.WriteLine($"Consumption Completed");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Producer producer = new Producer();
            Consumer consumer = new Consumer();

            Thread threadProducer = new Thread(producer.Produce);
            Thread threadConsumer = new Thread(consumer.Consume);

            threadProducer.Start();
            threadConsumer.Start();

            threadProducer.Join();
            threadConsumer.Join();

            Console.ReadKey();
        }
    }
}
