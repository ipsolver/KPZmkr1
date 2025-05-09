using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr1.LightHTML.Classes
{
    public interface IRenderBehavior
    {
        string Render(LightNode node, int indentLevel = 0);
        void Handle(LightNode node, string eventName);
    }
}
