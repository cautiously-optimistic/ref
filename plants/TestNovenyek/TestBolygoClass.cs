using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using novenyek;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace TestNovenyek
{
    [TestClass]
    public class TestBolygoClass
    {
        [TestMethod]
        public void TestConstr()
        {
            Bolygo b = new Bolygo(new List<Noveny>());

            List<Noveny> l = new List<Noveny>();
            l.Add(new Puffancs("puffancs1", 5));
            l.Add(new Deltafa("deltafa1", 6));
            l.Add(new Puffancs("puffancs2", 10));
            l.Add(new Parabokor("parabokor1", 3));
            l.Add(new Parabokor("parabokokor2", 7));

            b = new Bolygo(l);

            //novenyek es sugarzas ellenorzese
            StringWriter output = new StringWriter();
            Console.SetOut(output);
            b.Kiir();

            String[] lines = output.ToString().Split("\r\n");
            for(int i = 0; i < l.Count; i++)
            {
                Assert.AreEqual(l[i].ToString(), lines[i]);
            }
            Assert.AreEqual(Nincs.Instance().ToString(), lines[lines.Length - 2]);
        }

        [TestMethod]
        public void TestKiir()
        {
            List<Noveny> l = new List<Noveny>();
            l.Add(new Puffancs("puff", 1));
            l.Add(new Deltafa("del", 6));
            l.Add(new Parabokor("para", 4));

            Bolygo b = new Bolygo(l);

            StringWriter output = new StringWriter();
            Console.SetOut(output);
            b.Kiir();

            String[] lines = output.ToString().Split("\r\n");
            Assert.AreEqual("puff (puffancs): 1", lines[0]);
            Assert.AreEqual("del (deltafa): 6", lines[1]);
            Assert.AreEqual("para (parabokor): 4", lines[2]);
            Assert.AreEqual("Nincs sugarzas", lines[3]);
        }

        [TestMethod]
        public void TestSzimNincs()
        {
            List<Noveny> l = new List<Noveny>();
            l.Add(new Puffancs("puffancs1", 5));
            l.Add(new Deltafa("deltafa1", 6));
            l.Add(new Puffancs("puffancs2", 10));
            l.Add(new Parabokor("parabokor1", 3));
            l.Add(new Parabokor("parabokor2", 7));

            Bolygo b = new Bolygo(l);
            AlfaJel.Instance().Nullazas();
            DeltaJel.Instance().Nullazas();

            //nincs sugarzas

            b.Szimulacio();

            StringWriter output = new StringWriter();
            Console.SetOut(output);

            b.Kiir();

            String[] lines = output.ToString().Split("\r\n");

            Assert.AreEqual("puffancs1 (puffancs): 4", lines[0]);
            Assert.AreEqual("deltafa1 (deltafa): 5", lines[1]);
            Assert.AreEqual("puffancs2 (puffancs): 9", lines[2]);
            Assert.AreEqual("parabokor1 (parabokor): 2", lines[3]);
            Assert.AreEqual("parabokor2 (parabokor): 6", lines[4]);
            Assert.AreEqual(Alfa.Instance().ToString(), lines[5]);
        }

        [TestMethod]
        public void TestSzimAlfa()
        {
            List<Noveny> l = new List<Noveny>();
            l.Add(new Puffancs("puffancs1", 5));
            l.Add(new Deltafa("deltafa1", 6));
            l.Add(new Puffancs("puffancs2", 10));
            l.Add(new Parabokor("parabokor1", 3));
            l.Add(new Parabokor("parabokor2", 7));

            Bolygo b = new Bolygo(l);
            AlfaJel.Instance().Nullazas();
            DeltaJel.Instance().Nullazas();
            AlfaJel.Instance().JeletFogad(100);

            b.Szimulacio();
            /*
            p1: 4
            d1: 5
            p2: 9
            b1: 2
            b2: 6
            sugarzas: alfa
            */

            //alfa sugarzas

            b.Szimulacio();

            StringWriter output = new StringWriter();
            Console.SetOut(output);

            b.Kiir();

            String[] lines = output.ToString().Split("\r\n");

            Assert.AreEqual("puffancs1 (puffancs): 6", lines[0]);
            Assert.AreEqual("deltafa1 (deltafa): 2", lines[1]);
            Assert.AreEqual("puffancs2 (puffancs): 11", lines[2]);
            Assert.AreEqual("parabokor1 (parabokor): 3", lines[3]);
            Assert.AreEqual("parabokor2 (parabokor): 7", lines[4]);
            Assert.AreEqual(Alfa.Instance().ToString(), lines[5]);
        }

        [TestMethod]
        public void TestSzimDelta()
        {
            List<Noveny> l = new List<Noveny>();
            l.Add(new Puffancs("puffancs1", 5));
            l.Add(new Deltafa("deltafa1", 6));
            l.Add(new Puffancs("puffancs2", 10));
            l.Add(new Parabokor("parabokor1", 3));
            l.Add(new Parabokor("parabokor2", 7));

            Bolygo b = new Bolygo(l);
            AlfaJel.Instance().Nullazas();
            DeltaJel.Instance().Nullazas();
            DeltaJel.Instance().JeletFogad(100);

            b.Szimulacio();
            /*
            p1: 4
            d1: 5
            p2: 9
            b1: 2
            b2: 6
            sugarzas: delta
            */

            //delta sugarzas

            b.Szimulacio();

            StringWriter output = new StringWriter();
            Console.SetOut(output);

            b.Kiir();

            String[] lines = output.ToString().Split("\r\n");

            Assert.AreEqual("puffancs1 (puffancs): 2", lines[0]);
            Assert.AreEqual("deltafa1 (deltafa): 9", lines[1]);
            Assert.AreEqual("puffancs2 (puffancs): 7", lines[2]);
            Assert.AreEqual("parabokor1 (parabokor): 3", lines[3]);
            Assert.AreEqual("parabokor2 (parabokor): 7", lines[4]);
            Assert.AreEqual(Alfa.Instance().ToString(), lines[5]);
        }

        [TestMethod]
        public void TestUjsug()
        {
            AlfaJel.Instance().Nullazas();
            DeltaJel.Instance().Nullazas();

            Bolygo b = new Bolygo(new List<Noveny>());

            //->nincs
            b.Szimulacio();

            StringWriter output = new StringWriter();
            Console.SetOut(output);

            b.Kiir();
            String[] lines = output.ToString().Split("\r\n");

            Assert.AreEqual(Nincs.Instance().ToString(), lines[0]);
            Assert.AreEqual(0, AlfaJel.Instance().GetJel());
            Assert.AreEqual(0, DeltaJel.Instance().GetJel());

            //->alfa

            AlfaJel.Instance().JeletFogad(100);
            DeltaJel.Instance().JeletFogad(97);
            b.Szimulacio();
            output = new StringWriter();
            Console.SetOut(output);

            b.Kiir();
            lines = output.ToString().Split("\r\n");

            Assert.AreEqual(Alfa.Instance().ToString(), lines[0]);
            Assert.AreEqual(0, AlfaJel.Instance().GetJel());
            Assert.AreEqual(0, DeltaJel.Instance().GetJel());

            //->delta

            DeltaJel.Instance().JeletFogad(100);
            AlfaJel.Instance().JeletFogad(97);
            b.Szimulacio();
            output = new StringWriter();
            Console.SetOut(output);
            b.Kiir();
            lines = output.ToString().Split("\r\n");

            Assert.AreEqual(Delta.Instance().ToString(), lines[0]);
            Assert.AreEqual(0, AlfaJel.Instance().GetJel());
            Assert.AreEqual(0, DeltaJel.Instance().GetJel());
        }

        [TestMethod]
        public void TestEros()
        {
            List<Noveny> l = new List<Noveny>();
            l.Add(new Puffancs("puffancs1", 5));
            l.Add(new Deltafa("deltafa1", 6));
            l.Add(new Puffancs("puffancs2", 10));
            l.Add(new Parabokor("parabokor1", 3));
            l.Add(new Parabokor("parabokor2", 7));

            Bolygo b = new Bolygo(l);
            Assert.AreEqual(b.Legerosebb(), (true, l[2]));

            l = new List<Noveny>();
            l.Add(new Puffancs("puffancs1", 5));
            l.Add(new Deltafa("deltafa1", 6));
            l.Add(new Puffancs("puffancs2", 11));
            l.Add(new Parabokor("parabokor1", 3));
            l.Add(new Parabokor("parabokor2", 7));

            b = new Bolygo(l);
            Assert.AreEqual(b.Legerosebb(), (true, l[4]));

            l = new List<Noveny>();
            l.Add(new Puffancs("puffancs1", 0));
            l.Add(new Deltafa("deltafa1", -2));
            l.Add(new Puffancs("puffancs2", 11));
            l.Add(new Parabokor("parabokor1", 0));
            l.Add(new Parabokor("parabokor2", -1));

            b = new Bolygo(l);
            Assert.AreEqual(b.Legerosebb(), (false, null));
        }
    }
}
