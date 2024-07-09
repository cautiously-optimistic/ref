using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    public class Edge : Element
    {
        public readonly Node n1;
        public readonly Node n2;

        public Edge(Node n1, Node n2, string name) : base(name)
        {
            this.n1 = n1;
            this.n2 = n2;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
