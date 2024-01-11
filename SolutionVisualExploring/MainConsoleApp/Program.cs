namespace MainConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            List<int> nomeLista = new List<int>();
            nomeLista.Add(1);
            nomeLista.Add(2);
            nomeLista.Add(3);

            ContoElementiLista(nomeLista);

            Console.ReadLine();
        }

        static void ContoElementiLista(List<int> lista) 
        {
            int risultato = lista.Count;
            Console.WriteLine($"La lista contiene {risultato}");
        }
    }
}