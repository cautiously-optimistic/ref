using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    public class Node : Element
    {
        public List<Edge> edges;

        public Node(string name) : base(name)
        {
            edges = new List<Edge>();
        }

        public override string ToString()
        {
            return "(" + name + ")";
        }
    }
}
