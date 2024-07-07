using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace novenyek
{
    public class Bolygo
    {
        private List<Noveny> novenyek;
        private Sugarzas sugarzas;

        public Bolygo(List<Noveny> novenyek)
        {
            this.novenyek = novenyek;
            sugarzas = Nincs.Instance();
        }

        public void Szimulacio()
        {
            foreach(Noveny n in novenyek)
            {
                sugarzas.Hat(n);
                n.Jelez();
            }
            UjSugarzas();
        }

        private void UjSugarzas()
        {
            AlfaJel a = AlfaJel.Instance();
            DeltaJel d = DeltaJel.Instance();
            if(a.GetJel() >= d.GetJel() + 3)
            {
                sugarzas = Alfa.Instance();
            }
            else
            {
                if(d.GetJel() >= a.GetJel() + 3)
                {
                    sugarzas = Delta.Instance();
                } else
                {
                    sugarzas = Nincs.Instance();
                }
            }
            a.Nullazas();
            d.Nullazas();
        }

        public void Kiir()
        {
            foreach(Noveny n in novenyek)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine(sugarzas);
        }

        public (bool, Noveny?) Legerosebb()
        {
            bool l = false;
            Noveny maxnoveny = null;
            int maxtap = 0;
            foreach(Noveny n in novenyek)
            {
                if(n.EletbenVan() && n.GetTapanyag() > maxtap)
                {
                    if (!l)
                    {
                        l = true;
                    }
                    maxnoveny = n;
                    maxtap = n.GetTapanyag();
                }
            }
            return (l, maxnoveny);
        }
    }
}
