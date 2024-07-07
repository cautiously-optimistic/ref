using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace novenyek
{
    public abstract class Jel
    {
        protected int jelek;

        public void JeletFogad(int n)
        {
            jelek += n;
        }

        public void Nullazas()
        {
            jelek = 0;
        }

        public int GetJel()
        {
            return jelek;
        }
    }

    public class AlfaJel : Jel
    {
        private static AlfaJel? instance;
        private AlfaJel()
        {
            jelek = 0;
        }

        public static AlfaJel Instance()
        {
            if(instance == null)
            {
                instance = new AlfaJel();
            }
            return instance;
        }
    }

    public class DeltaJel : Jel
    {
        private static DeltaJel? instance;
        private DeltaJel()
        {
            jelek = 0;
        }

        public static DeltaJel Instance()
        {
            if (instance == null)
            {
                instance = new DeltaJel();
            }
            return instance;
        }
    }
}
