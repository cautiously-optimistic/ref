using System.Text.RegularExpressions;

namespace graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Üdv!\nEz a program arra szolgál, hogy egy adott gráfról megmondja, van-e benne Euler-séta, illetve Hamilton-kör.");
            Console.WriteLine("Először létre kell hozni a gráfot.\nEhhez először létrehozzuk és elnevezzük a csúcsokat, majd megadjuk az éleket.");
            Console.WriteLine("A nevek szükségesek ahhoz, hogy az éleknél meg tudd adni, melyik csúcsokhoz kapcsolódnak, illetve hogy az utak kiírásakor meg lehessen különböztetni a csúcsokat/éleket. Kérlek, egyedi neveket válassz.");
            
            Console.WriteLine("Hány csúcsa legyen a gráfnak?");

            int ncount = int.Parse(Console.ReadLine());
            List<Node> nodes = new List<Node>();

            Console.WriteLine("Kérlek, add meg a csúcsok neveit enterrel elválasztva.");
            string str;
            for(int i = 0; i < ncount; i++)
            {
                str = Console.ReadLine();
                nodes.Add(new Node(str));
            }

            Graph graph = new Graph(nodes);

            Console.WriteLine("Hány élt szeretnél hozzáadni?");

            ncount = int.Parse(Console.ReadLine());

            Console.WriteLine("Kérlek add meg az élek nevét, és a csúcsok nevét, amelyekhez kapcsolódnak, élenként enterrel, soron belül szóközökkel elválasztva, minta:");
            Console.WriteLine("{él neve} {egyik csúcs neve} {másik csúcs neve}");
            Console.WriteLine("e1 v1 v2");
            Console.WriteLine("e2 v1 v3");
            Console.WriteLine("e3 v2 v3");

            for (int i = 0; i < ncount; i++)
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
                if(j < graph.nodes.Count && k < graph.nodes.Count)
                {
                    graph.AddEdge(graph.nodes[j], graph.nodes[k], lines[0]);
                }
            }

            Console.WriteLine("Kész a gráf! Az eredmény:");

            (bool l, List<Edge>? list) = graph.HasEuler();
            if(l)
            {
                Console.WriteLine("Van Euler-séta.");
                Console.Write("Az Euler-séta útvonala:");
                foreach(Edge edge in list)
                {
                    Console.Write(" " +  edge.ToString());
                }
                Console.WriteLine();
            } else
            {
                Console.WriteLine("Nincs Euler-séta.");
            }

            (l, List<Node>? path) = graph.HasHamilton();

            if (l)
            {
                Console.WriteLine("Van Hamilton-kör.");
                Console.Write("A Hamilton-kör útvonala:");
                foreach (Node node in path)
                {
                    Console.Write(" " + node.ToString());
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Nincs Hamilton-kör.");
            }


            //próbagráfok
            /*
            //van Euler-séta, nincs Hamilton-kör
            Node n1 = new Node("n1");
            Node n2 = new Node("n2");
            Node n3 = new Node("n3");
            Node n4 = new Node("n4");
            Node n5 = new Node("n5");

            Graph graph = new Graph([n1, n2, n3, n4, n5]);

            graph.AddEdge(n1, n2, "a");
            graph.AddEdge(n2, n3, "b");
            graph.AddEdge(n3, n4, "c");
            graph.AddEdge(n2, n4, "d");
            graph.AddEdge(n5, n2, "e");
            graph.AddEdge(n5, n4, "f");*/

            /*
            //nincs Euler-séta, van Hamilton-kör
            Node v1 = new Node("v1");
            Node v2 = new Node("v2");
            Node v3 = new Node("v3");
            Node v4 = new Node("v4");

            Graph graph = new Graph([v1, v2, v3, v4]);

            graph.AddEdge(v1, v2, "v1-2");
            graph.AddEdge(v1, v3, "v1-3");
            graph.AddEdge(v1, v4, "v1-4");
            graph.AddEdge(v2, v3, "v2-3");
            graph.AddEdge(v2, v4, "v2-4");
            graph.AddEdge(v3, v4, "v3-4");*/
        }
    }
}
