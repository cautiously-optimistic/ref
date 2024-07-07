using Microsoft.VisualStudio.TestPlatform.TestHost;
using novenyek;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace TestNovenyek
{
    [TestClass]
    public class TestSugarzasClass
    {
        [TestMethod]
        public void TestInstance()
        {
            Alfa a = Alfa.Instance();
            Assert.IsNotNull(a);
            Assert.AreSame(Alfa.Instance(), a);
            Alfa b = Alfa.Instance();
            Assert.AreSame(Alfa.Instance(), b);
            Assert.AreSame(a, b);

            Delta d = Delta.Instance();
            Assert.IsNotNull(d);
            Assert.AreSame(Delta.Instance(), d);
            Delta e = Delta.Instance();
            Assert.AreSame(Delta.Instance(), e);
            Assert.AreSame(d, e);
        }

        [TestMethod]
        public void TestHat()
        {
            Noveny test1 = new Puffancs("test", 5);
            Noveny test2 = new Deltafa("test", 5);
            Noveny test3 = new Parabokor("test", 5);

            Assert.IsTrue(test1.GetTapanyag() == 5);
            Alfa.Instance().Hat(test1);
            Assert.IsTrue(test1.GetTapanyag() == 7);
            Delta.Instance().Hat(test1);
            Assert.IsTrue(test1.GetTapanyag() == 5);
            Nincs.Instance().Hat(test1);
            Assert.IsTrue(test1.GetTapanyag() == 4);

            Assert.IsTrue(test2.GetTapanyag() == 5);
            Alfa.Instance().Hat(test2);
            Assert.IsTrue(test2.GetTapanyag() == 2);
            Delta.Instance().Hat(test2);
            Assert.IsTrue(test2.GetTapanyag() == 6);
            Nincs.Instance().Hat(test2);
            Assert.IsTrue(test2.GetTapanyag() == 5);

            Assert.IsTrue(test3.GetTapanyag() == 5);
            Alfa.Instance().Hat(test3);
            Assert.IsTrue(test3.GetTapanyag() == 6);
            Delta.Instance().Hat(test3);
            Assert.IsTrue(test3.GetTapanyag() == 7);
            Nincs.Instance().Hat(test3);
            Assert.IsTrue(test3.GetTapanyag() == 6);
        }
    }
}
