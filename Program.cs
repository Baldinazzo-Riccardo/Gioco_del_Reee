using GiocoRE;
namespace GiocoRE
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("GIOCO DEL RE");

            //var risultato = Gestione.Lettura();

            //Console.WriteLine("\nComandi eseguiti:");
            //int i = 1;

            string path = "gioco.txt";


            List<string> lines = new List<string>();

            (List<CSoldato>, List<CPedone>) all = (new List<CSoldato>(), new List<CPedone>());

            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            string nomeRe = lines[0];
            CRe re = new CRe(nomeRe);

            List<string> nomiSoldati = lines[1].Split(" ").ToList();
            foreach (string ns in nomiSoldati)
            {
                CSoldato soldato = new CSoldato(ns);
                all.Item1.Add(soldato);
                re.ReAttaccato += soldato.OnReAttaccato;
            }

            List<string> nomiPedoni = lines[2].Split(" ").ToList();
            foreach (string np in nomiPedoni)
            {
                CPedone pedone = new CPedone(np);
                all.Item2.Add(pedone);
                re.ReAttaccato += pedone.OnReAttaccato;
            }

            List<string> azioni = new List<string>();
            List<string> parti;
            string comando;
            string nome;

            for (int i = 3; i < lines.Count - 1; i++)
            {
                azioni.Add(lines[i]);
                parti = lines[i].Split(" ").ToList();

                comando = parti[0];
                nome = parti[1];

                if (comando.ToLower() == "cattura")
                {
                    var soldato = all.Item1.FirstOrDefault(s => s.Nome == nome);
                    if (soldato != null)
                    {
                        Console.WriteLine(((ICatturabile)soldato).Cattura());
                        all.Item1.Remove(soldato);
                        re.ReAttaccato -= soldato.OnReAttaccato;
                        continue;
                    }

                    var pedone = all.Item2.FirstOrDefault(p => p.Nome == nome);
                    if (pedone != null)
                    {
                        Console.WriteLine(((ICatturabile)pedone).Cattura());
                        all.Item2.Remove(pedone);
                        re.ReAttaccato -= pedone.OnReAttaccato;
                        continue;
                    }
                }
                else if (comando.ToLower() == "attacca")
                {
                    if (nome.ToLower() == "re")
                    {
                        Console.WriteLine(re.Attacca());

                        //Console.WriteLine(re.RisposteAttacco.Count);
                        foreach (string risposta in re.RisposteAttacco)
                            Console.WriteLine(risposta);

                        re.RisposteAttacco.Clear();
                    }
                }
            }


            int k = 1;

            foreach (string azione in azioni)
            {
                Console.WriteLine($"{k++} {azione}");
            }



        }
    }
}