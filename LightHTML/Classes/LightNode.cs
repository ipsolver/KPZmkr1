using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr1.LightHTML.Classes
{
    public abstract class LightNode
    {
        public abstract string Render();
        public abstract string GetInner();
    }
}