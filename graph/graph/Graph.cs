using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    public class Graph
    {
        public List<Node> nodes;
        public int edgeCount;

        public Graph()
        {
            nodes = new List<Node>();
            edgeCount = 0;
        }

        public Graph(List<Node> nodes)
        {
            this.nodes = nodes;
            this.edgeCount = 0;
            foreach (Node node in nodes)
            {
                edgeCount += node.edges.Count();
            }
            edgeCount /= 2;
        }

        public void AddEdge(Node n1, Node n2, string name)
        {
            Edge e = new Edge(n1, n2, name);
            n1.edges.Add(e);
            n2.edges.Add(e);
            edgeCount++;
        }

        public (bool, List<Element>?) HasEuler()
        {
            List<Element> path = new List<Element>();
            bool l = false;
            int i = 0;
            while(!l &&  i < nodes.Count)
            {
                l = EulerRecursive(path, nodes[i]);
                i++;
            }
            if(l)
            {
                return (l, path);
            } else
            {
                return (l, null);
            }
        }

        private bool EulerRecursive(List<Element> path, Node from)
        {
            path.Add(from);
            if(path.Count/2 == edgeCount)
            {
                return true;
            }
            else
            {
                bool l = false;
                int i = 0;
                while(!l && i < from.edges.Count)
                {
                    Edge e = from.edges[i];
                    if (!path.Contains(e))
                    {
                        path.Add(e);
                        Node to = from == e.n1 ? e.n2 : e.n1;
                        l = EulerRecursive(path, to);
                        if(!l)
                        {
                            path.Remove(e);
                        }
                    }
                    i++;
                }
                if (!l)
                {
                    path.Remove(from);
                }
                return l;
            }
        }

        public (bool, List<Element>?) HasHamilton()
        {
            List<Element> path = new List<Element>();
            bool l = false;
            int i = 0;
            while (!l && i < nodes.Count)
            {
                path.Add(nodes[i]);
                l = HamiltonRecursive(path, nodes[i], nodes[i]);
                if (!l)
                {
                    path.Remove(nodes[i]);
                }
                i++;
            }
            if (l)
            {
                return (l, path);
            }
            else
            {
                return (l, null);
            }
        }

        public bool HamiltonRecursive(List<Element> path, Node from, Node startpoint)
        {
            if(path.Count/2 > nodes.Count)
            {
                return false;
            }
            {
                bool l = false;
                int i = 0;
                while (!l && i < from.edges.Count)
                {
                    Edge e = from.edges[i];
                    Node to = from == e.n1 ? e.n2 : e.n1;
                    if (!path.Contains(to))
                    {
                        path.Add(e);
                        path.Add(to);

                        l = HamiltonRecursive(path, to, startpoint);
                        if (!l)
                        {
                            path.Remove(e);
                            path.Remove(to);
                        }
                    }
                    else
                    {
                        if (path.Count/2+1 == nodes.Count && to == startpoint)
                        {
                            path.Add(e);
                            path.Add(to);
                            return true;
                        }
                    }
                    i++;
                }
                return l;
            }
        }

        /*public void AddNode(string name)
        {
            Node node = new Node(name);
            nodes.Add(node);
        }*/

        /*public void RemoveNode(Node node)
        {
            if(node != null && nodes.Contains(node))
            {
                foreach(Edge e in node.edges)
                {
                    RemoveEdge(e);
                }
                nodes.Remove(node);
            }
        }*/

        /*public void RemoveEdge(Edge edge)
        {
            edge.n1.edges.Remove(edge);
            edge.n2.edges.Remove(edge);
            edgeCount--;
        }*/
    }
}
