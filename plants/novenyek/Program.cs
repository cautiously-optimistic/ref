using TextFile;
using static System.IO.StreamWriter;

namespace novenyek
{
    public class Program
    {
        static void Main(string[] args)
        {
            //beolvasas
            Console.WriteLine("Fajl neve: ");
            string filename = Console.ReadLine();

            TextFileReader reader = new TextFileReader(filename);
            List<Noveny> novenyek = new List<Noveny>();
            string line = reader.ReadLine();
            int napok = int.Parse(line);

            while(reader.ReadLine(out line))
            {
                String[] components = line.Split(' ');
                string nev = components[0];
                char fajta = char.Parse(components[1]);
                int tapanyag = int.Parse(components[2]);

                Noveny? noveny = null;
                switch (fajta)
                {
                    case 'p':
                        noveny = new Puffancs(nev, tapanyag);
                        break;
                    case 'd':
                        noveny = new Deltafa(nev, tapanyag);
                        break;
                    case 'b':
                        noveny = new Parabokor(nev, tapanyag);
                        break;
                }
                if(noveny != null)
                {
                    novenyek.Add(noveny);
                }
            }

            //bolygo letrehozasa, ellenorzese

            Bolygo bolygo = new Bolygo(novenyek);
            Console.WriteLine("\nNapok szama: {0}", napok);
            Console.WriteLine("Kiindulo helyzet:");
            bolygo.Kiir();

            //szimulacio

            Console.WriteLine("\n-- Szimulacio kezdete --\n");

            for(int i = 0; i < napok; i++)
            {
                bolygo.Szimulacio();
                Console.WriteLine("\n" + (i+1).ToString() + ". nap:");
                bolygo.Kiir();
            }

            (bool l, Noveny? legerosebb) = bolygo.Legerosebb();
            if (l)
            {
                Console.WriteLine("\nA legerosebb noveny: " + legerosebb);
            } else
            {
                Console.WriteLine("\nNincs legerosebb (minden noveny halott)");
            }
        }
    }
}
