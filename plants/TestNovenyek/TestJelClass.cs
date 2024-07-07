using Microsoft.VisualStudio.TestPlatform.TestHost;
using novenyek;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace TestNovenyek
{
    [TestClass]
    public class TestJelClass
    {
        [TestMethod]
        public void TestInstance()
        {
            Jel a = AlfaJel.Instance();
            Assert.IsNotNull(a);
            Assert.AreSame(AlfaJel.Instance(), a);
            Jel b = AlfaJel.Instance();
            Assert.AreSame(AlfaJel.Instance(), b);
            Assert.AreSame(a, b);
            Assert.IsTrue(AlfaJel.Instance().GetJel() == 0);

            Jel d = DeltaJel.Instance();
            Assert.IsNotNull(d);
            Assert.AreSame(DeltaJel.Instance(), d);
            Jel e = DeltaJel.Instance();
            Assert.AreSame(DeltaJel.Instance(), e);
            Assert.AreSame(d, e);
            Assert.IsTrue(DeltaJel.Instance().GetJel() == 0);
        }

        [TestMethod]
        public void TestAlfaMethods()
        {
            Jel a = AlfaJel.Instance();
            Jel b = AlfaJel.Instance();

            Assert.IsTrue(AlfaJel.Instance().GetJel() == 0);
            Assert.IsTrue(a.GetJel() == 0);
            Assert.IsTrue(b.GetJel() == 0);
            AlfaJel.Instance().JeletFogad(5);
            Assert.IsTrue(AlfaJel.Instance().GetJel() == 5);
            Assert.IsTrue(a.GetJel() == 5);
            Assert.IsTrue(b.GetJel() == 5);
            AlfaJel.Instance().Nullazas();
            Assert.IsTrue(AlfaJel.Instance().GetJel() == 0);
            Assert.IsTrue(a.GetJel() == 0);
            Assert.IsTrue(b.GetJel() == 0);
            a.JeletFogad(10);
            Assert.IsTrue(AlfaJel.Instance().GetJel() == 10);
            a.Nullazas();
            Assert.IsTrue(AlfaJel.Instance().GetJel() == 0);
            b.JeletFogad(15);
            Assert.IsTrue(AlfaJel.Instance().GetJel() == 15);
            b.Nullazas();
            Assert.IsTrue(AlfaJel.Instance().GetJel() == 0);

            //cleanup
            a.Nullazas();
        }

        [TestMethod]
        public void TestDeltaMethods()
        {
            Jel d = DeltaJel.Instance();
            Jel e = DeltaJel.Instance();

            Assert.IsTrue(DeltaJel.Instance().GetJel() == 0);
            Assert.IsTrue(d.GetJel() == 0);
            Assert.IsTrue(e.GetJel() == 0);
            DeltaJel.Instance().JeletFogad(5);
            Assert.IsTrue(DeltaJel.Instance().GetJel() == 5);
            Assert.IsTrue(d.GetJel() == 5);
            Assert.IsTrue(e.GetJel() == 5);
            DeltaJel.Instance().Nullazas();
            Assert.IsTrue(DeltaJel.Instance().GetJel() == 0);
            Assert.IsTrue(d.GetJel() == 0);
            Assert.IsTrue(e.GetJel() == 0);
            d.JeletFogad(10);
            Assert.IsTrue(DeltaJel.Instance().GetJel() == 10);
            d.Nullazas();
            Assert.IsTrue(DeltaJel.Instance().GetJel() == 0);
            e.JeletFogad(15);
            Assert.IsTrue(DeltaJel.Instance().GetJel() == 15);
            e.Nullazas();
            Assert.IsTrue(DeltaJel.Instance().GetJel() == 0);

            //cleanup
            d.Nullazas();
        }
    }
}
