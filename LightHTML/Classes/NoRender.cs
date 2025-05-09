using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr1.LightHTML.Classes
{
    public class NoRender : IRenderBehavior
    {
        public string Render(LightNode node, int indentLevel = 0)
        {
            return "";
        }

        public void Handle(LightNode node, string eventName)
        {
            Console.WriteLine($"NoRender \"{eventName}\"");
        }
    }
}
