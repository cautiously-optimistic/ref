using System.Xml.Linq;
using graph;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGraph1()
        {
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
            graph.AddEdge(n5, n4, "f");

            (bool l, List<Element>? list) = graph.HasEuler();
            List<Element> expected = [n1, n1.edges[0], n2, n2.edges[1], n3, n3.edges[1], n4, n4.edges[1], n2, n2.edges[3], n5, n5.edges[1], n4];

            Assert.IsTrue(l);
            Assert.IsNotNull(list);
            Assert.AreEqual(expected.Count, list.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], list[i]);
            }

            (l, list) = graph.HasHamilton();
            Assert.IsFalse(l);
            Assert.IsNull(list);
        }

        [TestMethod]
        public void TestGraph2()
        {
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
            graph.AddEdge(v3, v4, "v3-4");

            (bool l, List<Element>? list) = graph.HasEuler();
            Assert.IsFalse(l);
            Assert.IsNull(list);

            (l, list) = graph.HasHamilton();
            List<Element> expected = [v1, v1.edges[0], v2, v2.edges[1], v3, v3.edges[2], v4, v4.edges[0], v1];

            Assert.IsTrue(l);
            Assert.IsNotNull(list);
            Assert.AreEqual(expected.Count, list.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], list[i]);
            }
        }

        [TestMethod]
        public void TestGraph3()
        {
            //nincs sem Euler-séta, sem Hamilton-kör
            Node v1 = new Node("v1");
            Node v2 = new Node("v2");
            Node v3 = new Node("v3");
            Node v4 = new Node("v4");
            Node v5 = new Node("v5");
            Node v6 = new Node("v6");
            Node v7 = new Node("v7");
            Node v8 = new Node("v8");

            Graph graph = new Graph([v1, v2, v3, v4, v5, v6, v7, v8]);

            graph.AddEdge(v1, v2, "e1");
            graph.AddEdge(v2, v4, "e2");
            graph.AddEdge(v4, v5, "e3");
            graph.AddEdge(v5, v1, "e4");
            graph.AddEdge(v2, v3, "e5");
            graph.AddEdge(v3, v6, "e6");
            graph.AddEdge(v7, v6, "e7");
            graph.AddEdge(v7, v8, "e8");
            graph.AddEdge(v5, v7, "e9");
            graph.AddEdge(v5, v6, "e10");
            graph.AddEdge(v8, v3, "e11");

            (bool l, List<Element>? list) = graph.HasEuler();
            Assert.IsFalse(l);
            Assert.IsNull(list);

            (l, list) = graph.HasHamilton();
            Assert.IsFalse(l);
            Assert.IsNull(list);
        }
    }
}