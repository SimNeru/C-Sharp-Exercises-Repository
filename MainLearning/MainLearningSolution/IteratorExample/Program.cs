namespace IteratorExample
{
    public class Sample
    {
        private List<double> Prices {  get; set; } = new List<double>() { 90,34,12,80 };

        public IEnumerable<int> Method() 
        {
            Console.Write("Iterator method executes");

            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            yield return 10;
            
            Console.Write("Iterator method executes continued");
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            yield return 20;
        }

        public IEnumerable<double> Method2()
        {
            double sum = 0;
            foreach (double value in Prices) 
            {
                sum += value;
                yield return sum;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Sample s = new Sample();
            var enumerable1 = s.Method2();
            var enumerator1 = enumerable1.GetEnumerator();

            //enumerator1.MoveNext();
            //Console.WriteLine(" " + enumerator1.Current + "\n");

            //enumerator1.MoveNext();
            //Console.WriteLine(" " + enumerator1.Current + "\n");

            Console.Write("Printing numbers:\n");
            foreach (var item in enumerable1)
            {
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(300);
                    Console.Write(".");
                }
                enumerator1.MoveNext();
                Console.WriteLine(" " + enumerator1.Current);
                
            }
            Console.ReadKey();
        }
    }
}
