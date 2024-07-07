using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    public class Node
    {
        public List<Edge> edges;
        public readonly string name;

        public Node(string name)
        {
            edges = new List<Edge>();
            this.name = name;
        }

        public override string ToString()
        {
            return "(" + name + ")";
        }
    }
}
