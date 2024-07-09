using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    public abstract class Element
    {
        public readonly string name;

        public Element(string name)
        {
            this.name = name;
        }
    }
}
