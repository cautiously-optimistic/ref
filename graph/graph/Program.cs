using System.Text.RegularExpressions;

namespace graph
{
    internal class Program
    {
        static Graph ConstructGraph() //beolvasás
        {
            Console.WriteLine("Üdv!\nEz a program arra szolgál, hogy egy adott gráfról megmondja, van-e benne Euler-séta, illetve Hamilton-kör.");
            Console.WriteLine("Először létre kell hozni a gráfot.\nEhhez először létrehozzuk és elnevezzük a csúcsokat, majd megadjuk az éleket.");
            Console.WriteLine("A nevek szükségesek ahhoz, hogy az éleknél meg tudd adni, melyik csúcsokhoz kapcsolódnak, illetve hogy az utak kiírásakor meg lehessen különböztetni a csúcsokat/éleket. Kérlek, egyedi neveket válassz.");

            Console.WriteLine("Hány csúcsa legyen a gráfnak?");

            int ncount = int.Parse(Console.ReadLine());
            List<Node> nodes = new List<Node>();

            Console.WriteLine("Kérlek, add meg a csúcsok neveit enterrel elválasztva.");
            string str;
            for (int i = 0; i < ncount; i++)
            {
                str = Console.ReadLine();
                nodes.Add(new Node(str));
            }

            Graph graph = new Graph(nodes);

            Console.WriteLine("Hány élt szeretnél hozzáadni?");

            ncount = int.Parse(Console.ReadLine());

            Console.WriteLine("Kérlek add meg az élek nevét, és a csúcsok nevét, amelyekhez kapcsolódnak, élenként enterrel, soron belül szóközökkel elválasztva, minta:");
            Console.WriteLine("{él neve} {egyik csúcs neve} {másik csúcs neve}");
            Console.WriteLine("pl.:");
            Console.WriteLine("e1 v1 v2");
            Console.WriteLine("e2 v1 v3");
            Console.WriteLine("e3 v2 v3");
            Console.WriteLine("élek:");

            while (graph.edgeCount < ncount)
            {
                string[] lines = Console.ReadLine().Split(" ");
                int j = 0;
                while (j < graph.nodes.Count && graph.nodes[j].name != lines[1] && graph.nodes[j].name != lines[2])
                {
                    j++;
                }
                int k = j + 1;
                while (k < graph.nodes.Count && graph.nodes[k].name != lines[1] && graph.nodes[k].name != lines[2])
                {
                    k++;
                }
                if (j < graph.nodes.Count && k < graph.nodes.Count)
                {
                    graph.AddEdge(graph.nodes[j], graph.nodes[k], lines[0]);
                } else
                {
                    Console.WriteLine("Valamelyik csúcs neve helytelen volt. Kérlek, próbáld újra!");
                }
            }

            return graph;
        }

        static int Main(string[] args)
        {
            Graph graph = ConstructGraph();

            Console.WriteLine("Kész a gráf! Az eredmény:");

            (bool l, List<Element>? list) = graph.HasEuler();
            if(l)
            {
                Console.WriteLine("Van Euler-séta.");
                Console.Write("Az Euler-séta útvonala:");
                foreach(Element element in list)
                {
                    Console.Write(" " +  element.ToString());
                }
                Console.WriteLine();
            } else
            {
                Console.WriteLine("Nincs Euler-séta.");
            }

            (l, List<Element>? path) = graph.HasHamilton();

            if (l)
            {
                Console.WriteLine("Van Hamilton-kör.");
                Console.Write("A Hamilton-kör útvonala:");
                foreach (Element element in path)
                {
                    Console.Write(" " + element.ToString());
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Nincs Hamilton-kör.");
            }

            return 0;
        }
    }
}
