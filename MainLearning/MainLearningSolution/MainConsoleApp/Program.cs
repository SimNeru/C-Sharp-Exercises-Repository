namespace MainConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer c; //sarà null

            //questi oggetti di seguito non hanno nome, quindi non hanno modo di essere acceduti
            new Customer(); //sarà storato nella heap, oggetto 1 
            new Customer(); //sarà storato nella heap, oggetto 2

            //questi oggetti diversamente possiedono una variabile di riferimento
            Customer c1, c2;
            c1 = new Customer();
            c2 = new Customer();
        }
    }
}