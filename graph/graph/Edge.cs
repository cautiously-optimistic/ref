using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    public class Edge
    {
        public readonly Node n1;
        public readonly Node n2;
        public readonly string name;

        public Edge(Node n1, Node n2, string name)
        {
            this.n1 = n1;
            this.n2 = n2;
            //n1.edges.Add(this);
            //n2.edges.Add(this);
            //graph.edgeCount++;
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
