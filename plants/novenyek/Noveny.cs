using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace novenyek
{
    public abstract class Noveny
    {
        protected string nev;
        protected int tapanyag;

        public Noveny(string nev, int tapanyag)
        {
            this.nev = nev;
            this.tapanyag = tapanyag;
        }

        public int GetTapanyag()
        {
            return tapanyag;
        }

        public virtual bool EletbenVan()
        {
            if(tapanyag > 0)
            {
                return true;
            }
            return false;
        }

        public virtual void Reagal(Alfa a) { }
        public virtual void Reagal(Delta d) { }
        public virtual void Reagal(Nincs n)
        {
            if(EletbenVan())
            {
                tapanyag--;
            }
        }

        public virtual void Jelez() { }
    }

    public class Puffancs : Noveny
    {
        public Puffancs(string nev, int tapanyag) : base(nev, tapanyag) { }
        public override bool EletbenVan()
        {
            if(tapanyag > 0 && tapanyag <= 10)
            {
                return true;
            }
            return false;
        }

        public override void Reagal(Alfa a)
        {
            if (EletbenVan())
            {
                tapanyag += 2;
            }
        }

        public override void Reagal(Delta a)
        {
            if (EletbenVan())
            {
                tapanyag -= 2;
            }
        }

        public override void Jelez()
        {
            if (EletbenVan())
            {
                AlfaJel.Instance().JeletFogad(10);
            }
        }

        public override string ToString()
        {
            return (nev + " (puffancs): " + tapanyag);
        }
    }

    public class Deltafa : Noveny
    {
        public Deltafa(string nev, int tapanyag) : base(nev, tapanyag) { }

        public override void Reagal(Alfa a)
        {
            if (EletbenVan())
            {
                tapanyag -= 3;
            }
        }

        public override void Reagal(Delta a)
        {
            if (EletbenVan())
            {
                tapanyag += 4;
            }
        }

        public override void Jelez()
        {
            if (EletbenVan())
            {
                if(tapanyag < 5)
                {
                    DeltaJel.Instance().JeletFogad(4);
                } else
                {
                    if( tapanyag <= 10)
                    {
                        DeltaJel.Instance().JeletFogad(1);
                    }
                }
            }
        }

        public override string ToString()
        {
            return (nev + " (deltafa): " + tapanyag);
        }
    }

    public class Parabokor : Noveny
    {
        public Parabokor(string nev, int tapanyag) : base(nev, tapanyag) { }

        public override void Reagal(Alfa a)
        {
            if (EletbenVan())
            {
                tapanyag++;
            }
        }

        public override void Reagal(Delta a)
        {
            if (EletbenVan())
            {
                tapanyag++;
            }
        }

        public override string ToString()
        {
            return (nev + " (parabokor): " + tapanyag);
        }
    }
}
