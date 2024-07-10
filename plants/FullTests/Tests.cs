using novenyek;

namespace FullTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test1()
        {
            //novenyek, bolygo letrehozasa

            StreamReader reader = new StreamReader("input1.txt");
            List<Noveny> novenyek = new List<Noveny>();
            string line = reader.ReadLine();
            int napok = int.Parse(line);

            while ((line = reader.ReadLine()) != null)
            {
                String[] components = line.Split(' ');
                string nev = components[0];
                char fajta = char.Parse(components[1]);
                int tapanyag = int.Parse(components[2]);

                Noveny? noveny = null;
                switch (fajta)
                {
                    case 'p':
                        noveny = new Puffancs(nev, tapanyag);
                        break;
                    case 'd':
                        noveny = new Deltafa(nev, tapanyag);
                        break;
                    case 'b':
                        noveny = new Parabokor(nev, tapanyag);
                        break;
                }
                if (noveny != null)
                {
                    novenyek.Add(noveny);
                }
            }
            reader.Close();

            Bolygo bolygo = new Bolygo(novenyek);

            //szimulacio
            for (int i = 0; i < napok; i++)
            {
                bolygo.Szimulacio();
            }

            //tesztek
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            bolygo.Kiir();

            String[] lines = output.ToString().Split("\r\n");

            Assert.AreEqual("bokor1 (parabokor): 4", lines[0]);
            Assert.AreEqual("puff1 (puffancs): 4", lines[1]);
            Assert.AreEqual("del1 (deltafa): 7", lines[2]);
            Assert.AreEqual("del2 (deltafa): 3", lines[3]);
            Assert.AreEqual("bokor2 (parabokor): 7", lines[4]);
            Assert.AreEqual("del3 (deltafa): 4", lines[5]);
            Assert.AreEqual("bokor3 (parabokor): 2", lines[6]);
            Assert.AreEqual("del4 (deltafa): 1", lines[7]);
            Assert.AreEqual(Delta.Instance().ToString(), lines[8]);

            (bool l, Noveny? n) = bolygo.Legerosebb();
            Assert.AreEqual(true, l);
            Assert.AreEqual("del1 (deltafa): 7", n.ToString());

            output.Close();
        }

        [TestMethod]
        public void Test2()
        {
            //novenyek, bolygo letrehozasa
            StreamReader reader = new StreamReader("input2.txt");
            List<Noveny> novenyek = new List<Noveny>();
            string line = reader.ReadLine();
            int napok = int.Parse(line);

            while ((line = reader.ReadLine()) != null)
            {
                String[] components = line.Split(' ');
                string nev = components[0];
                char fajta = char.Parse(components[1]);
                int tapanyag = int.Parse(components[2]);

                Noveny? noveny = null;
                switch (fajta)
                {
                    case 'p':
                        noveny = new Puffancs(nev, tapanyag);
                        break;
                    case 'd':
                        noveny = new Deltafa(nev, tapanyag);
                        break;
                    case 'b':
                        noveny = new Parabokor(nev, tapanyag);
                        break;
                }
                if (noveny != null)
                {
                    novenyek.Add(noveny);
                }
            }
            reader.Close();

            Bolygo bolygo = new Bolygo(novenyek);

            //szimulacio
            for (int i = 0; i < napok; i++)
            {
                bolygo.Szimulacio();
            }

            //tesztek
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            bolygo.Kiir();

            String[] lines = output.ToString().Split("\r\n");

            Assert.AreEqual("puff1 (puffancs): 8", lines[0]);
            Assert.AreEqual("del1 (deltafa): -1", lines[1]);
            Assert.AreEqual("puff2 (puffancs): 11", lines[2]);
            Assert.AreEqual("bokor1 (parabokor): 4", lines[3]);
            Assert.AreEqual("bokor2 (parabokor): 8", lines[4]);
            Assert.AreEqual(Alfa.Instance().ToString(), lines[5]);

            (bool l, Noveny? n) = bolygo.Legerosebb();
            Assert.AreEqual(true, l);
            Assert.AreEqual("puff1 (puffancs): 8", n.ToString());

            output.Close();
        }

        [TestMethod]
        public void Test3()
        {
            //novenyek, bolygo letrehozasa
            StreamReader reader = new StreamReader("input3.txt");
            List<Noveny> novenyek = new List<Noveny>();
            string line = reader.ReadLine();
            int napok = int.Parse(line);

            while ((line = reader.ReadLine()) != null)
            {
                String[] components = line.Split(' ');
                string nev = components[0];
                char fajta = char.Parse(components[1]);
                int tapanyag = int.Parse(components[2]);

                Noveny? noveny = null;
                switch (fajta)
                {
                    case 'p':
                        noveny = new Puffancs(nev, tapanyag);
                        break;
                    case 'd':
                        noveny = new Deltafa(nev, tapanyag);
                        break;
                    case 'b':
                        noveny = new Parabokor(nev, tapanyag);
                        break;
                }
                if (noveny != null)
                {
                    novenyek.Add(noveny);
                }
            }

            reader.Close();

            Bolygo bolygo = new Bolygo(novenyek);

            //szimulacio
            for (int i = 0; i < napok; i++)
            {
                bolygo.Szimulacio();
            }

            //tesztek
            StringWriter output = new StringWriter();
            Console.SetOut(output);

            bolygo.Kiir();

            String[] lines = output.ToString().Split("\r\n");

            Assert.AreEqual("Falank (puffancs): 12", lines[0]);
            Assert.AreEqual("Sudar (deltafa): -1", lines[1]);
            Assert.AreEqual("Kopcos (parabokor): 0", lines[2]);
            Assert.AreEqual("Nyulank (deltafa): 0", lines[3]);
            Assert.AreEqual(Nincs.Instance().ToString(), lines[4]);

            (bool l, Noveny? n) = bolygo.Legerosebb();
            Assert.AreEqual(false, l);
            Assert.AreEqual(null, n);

            output.Close();
        }
    }
}