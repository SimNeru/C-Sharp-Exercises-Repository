using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueueLesson
{
    class Student 
    { 
        public int Marks { get; set; }
        public int Rank { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             * STACK_COLLECTION
             * Contiene gruppi di elementi basati sulla regola della LIFO
             * LAST-IN-FIRST-OUT
             * Il processo di aggiungere elementi qua viene chiamato PUSH*
             * POP* è il processo di prendere l'ultimo elemento dallo stack
             */

            // Create object of Stack
            Stack<Student> marks = new Stack<Student>();

            Console.WriteLine("STACK");

            // Add
            marks.Push(new Student() { Marks = 45});
            marks.Push(new Student() { Marks = 65});
            marks.Push(new Student() { Marks = 80});

            // Pop
            Student stu = marks.Pop();
            Console.WriteLine("Pop: " + stu.Marks);

            int r = 1;

            foreach (Student s in marks)
            {
                s.Rank = r++;
                Console.WriteLine("Mark: " + s.Marks + ", Rank: " + s.Rank);
            }

            /* 
             * QUEUE_COLLECTION
             * Contiene gruppi di elementi basati sulla regola della FIFO
             * FIRST-IN-FIRST-OUT
             * Queue ha due apici, front e rear
             * Il processo di aggiungere elementi qua viene chiamato ENQUEUE*
             * DEQUEUE* è il processo di prendere l'ultimo elemento dallo stack
             */

            // Create object of Queue
            Queue<string> tasks = new Queue<string>();

            Console.WriteLine("\nQUEUE");

            // Enqueue (Add)
            tasks.Enqueue("Task 3");
            tasks.Enqueue("Task 5");
            tasks.Enqueue("Task 1");
            tasks.Enqueue("Task 4");
            tasks.Enqueue("Task 2");

            // Peek (Non lo rimuove)
            string pk = tasks.Peek();

            Console.WriteLine("\nPeeked " + pk);
            Console.WriteLine();

            // Foreach
            foreach (string item in tasks) 
            {
                Console.WriteLine(item);
            }

            // Dequeue (Remove)
            var res = tasks.Dequeue();
            Console.WriteLine("\nDequeued: " + res); 

            



            Console.ReadLine();
        }
    }
}
