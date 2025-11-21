using GiocoRE;
namespace GiocoRE
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("GIOCO DEL RE");

            var risultato = Gestione.Lettura();

            Console.WriteLine("\nComandi eseguiti:");
            int i = 1;

            foreach (string azione in risultato.azioni)
            {
                Console.WriteLine($"{i++} {azione}");
            }

            

        }
    }
}