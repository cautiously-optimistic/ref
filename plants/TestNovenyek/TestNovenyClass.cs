using Microsoft.VisualStudio.TestPlatform.TestHost;
using novenyek;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace TestNovenyek
{
    [TestClass]
    public class TestNovenyClass
    {
        [TestMethod]
        public void TestConstr()
        {
            //exception vagy rossz tápanyagérték esetén hibás
            Noveny test1 = new Puffancs("test", 1);
            Noveny test2 = new Deltafa("test", 2);
            Noveny test3 = new Parabokor("test", 3);
            Assert.IsTrue(test1.GetTapanyag() == 1);
            Assert.IsTrue(test2.GetTapanyag() == 2);
            Assert.IsTrue(test3.GetTapanyag() == 3);
        }

        [TestMethod]
        public void TestPuffancsReag()
        {
            Puffancs test = new Puffancs("test", 5);
            Assert.IsTrue(test.EletbenVan());
            Assert.IsTrue(test.GetTapanyag() == 5);
            test.Reagal(Alfa.Instance());
            Assert.IsTrue(test.GetTapanyag() == 7);
            test.Reagal(Nincs.Instance());
            Assert.IsTrue(test.GetTapanyag() == 6);
            test.Reagal(Delta.Instance());
            Assert.IsTrue(test.GetTapanyag() == 4);

            test = new Puffancs("test", 0);
            Assert.IsFalse(test.EletbenVan());
            Assert.IsTrue(test.GetTapanyag() == 0);
            test.Reagal(Alfa.Instance());
            Assert.IsTrue(test.GetTapanyag() == 0);
            test.Reagal(Nincs.Instance());
            Assert.IsTrue(test.GetTapanyag() == 0);
            test.Reagal(Delta.Instance());
            Assert.IsTrue(test.GetTapanyag() == 0);

            test = new Puffancs("test", 11);
            Assert.IsFalse(test.EletbenVan());
            Assert.IsTrue(test.GetTapanyag() == 11);
            test.Reagal(Alfa.Instance());
            Assert.IsTrue(test.GetTapanyag() == 11);
            test.Reagal(Nincs.Instance());
            Assert.IsTrue(test.GetTapanyag() == 11);
            test.Reagal(Delta.Instance());
            Assert.IsTrue(test.GetTapanyag() == 11);
        }

        [TestMethod]
        public void TestDeltafaReag()
        {
            Deltafa test = new Deltafa("test", 5);
            Assert.IsTrue(test.EletbenVan());
            Assert.IsTrue(test.GetTapanyag() == 5);
            test.Reagal(Alfa.Instance());
            Assert.IsTrue(test.GetTapanyag() == 2);
            test.Reagal(Nincs.Instance());
            Assert.IsTrue(test.GetTapanyag() == 1);
            test.Reagal(Delta.Instance());
            Assert.IsTrue(test.GetTapanyag() == 5);

            test = new Deltafa("test", 0);
            Assert.IsFalse(test.EletbenVan());
            Assert.IsTrue(test.GetTapanyag() == 0);
            test.Reagal(Alfa.Instance());
            Assert.IsTrue(test.GetTapanyag() == 0);
            test.Reagal(Nincs.Instance());
            Assert.IsTrue(test.GetTapanyag() == 0);
            test.Reagal(Delta.Instance());
            Assert.IsTrue(test.GetTapanyag() == 0);
        }

        [TestMethod]
        public void TestParabokorReag()
        {
            Parabokor test = new Parabokor("test", 5);
            Assert.IsTrue(test.EletbenVan());
            Assert.IsTrue(test.GetTapanyag() == 5);
            test.Reagal(Alfa.Instance());
            Assert.IsTrue(test.GetTapanyag() == 6);
            test.Reagal(Nincs.Instance());
            Assert.IsTrue(test.GetTapanyag() == 5);
            test.Reagal(Delta.Instance());
            Assert.IsTrue(test.GetTapanyag() == 6);

            test = new Parabokor("test", 0);
            Assert.IsFalse(test.EletbenVan());
            Assert.IsTrue(test.GetTapanyag() == 0);
            test.Reagal(Alfa.Instance());
            Assert.IsTrue(test.GetTapanyag() == 0);
            test.Reagal(Nincs.Instance());
            Assert.IsTrue(test.GetTapanyag() == 0);
            test.Reagal(Delta.Instance());
            Assert.IsTrue(test.GetTapanyag() == 0);
        }

        [TestMethod]
        public void TestJelez()
        {
            AlfaJel a = AlfaJel.Instance();
            DeltaJel d = DeltaJel.Instance();

            Noveny test1 = new Puffancs("test", 5);
            Noveny test2a = new Deltafa("test", 2);
            Noveny test2b = new Deltafa("test", 6);
            Noveny test2c = new Deltafa("test", 11);
            Noveny test3 = new Parabokor("test", 5);

            Assert.IsTrue(a.GetJel() == 0);
            Assert.IsTrue(d.GetJel() == 0);

            test1.Jelez();
            Assert.IsTrue(a.GetJel() == 10);
            Assert.IsTrue(d.GetJel() == 0);

            test2a.Jelez();
            Assert.IsTrue(a.GetJel() == 10);
            Assert.IsTrue(d.GetJel() == 4);

            test2b.Jelez();
            Assert.IsTrue(a.GetJel() == 10);
            Assert.IsTrue(d.GetJel() == 5);

            test2c.Jelez();
            Assert.IsTrue(a.GetJel() == 10);
            Assert.IsTrue(d.GetJel() == 5);

            test3.Jelez();
            Assert.IsTrue(a.GetJel() == 10);
            Assert.IsTrue(d.GetJel() == 5);

            //cleanup
            a.Nullazas();
            d.Nullazas();
            
        }
    }
}
