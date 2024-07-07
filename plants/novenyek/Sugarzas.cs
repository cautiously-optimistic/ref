using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace novenyek
{
    public interface Sugarzas
    {
        public void Hat(Noveny n);
    }

    public class Alfa : Sugarzas
    {
        private static Alfa? instance;
        private Alfa() { }

        public static Alfa Instance()
        {
            if (instance == null)
            {
                instance = new Alfa();
            }
            return instance;
        }

        public void Hat(Noveny n)
        {
            n.Reagal(this);
        }

        public override string ToString()
        {
            return "Alfa sugarzas";
        }
    }

    public class Delta : Sugarzas
    {
        private static Delta? instance;
        private Delta() { }

        public static Delta Instance()
        {
            if (instance == null)
            {
                instance = new Delta();
            }
            return instance;
        }

        public void Hat(Noveny n)
        {
            n.Reagal(this);
        }

        public override string ToString()
        {
            return "Delta sugarzas";
        }
    }

    public class Nincs : Sugarzas
    {
        private static Nincs? instance;
        private Nincs() { }

        public static Nincs Instance()
        {
            if (instance == null)
            {
                instance = new Nincs();
            }
            return instance;
        }

        public void Hat(Noveny n)
        {
            n.Reagal(this);
        }

        public override string ToString()
        {
            return "Nincs sugarzas";
        }
    }
}
