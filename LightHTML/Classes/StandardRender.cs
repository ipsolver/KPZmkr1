using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr1.LightHTML.Classes
{
    public class StandardRender : IRenderBehavior
    {
        public string Render(LightNode node, int identLevel = 0)
        {
            if (node is LightElementNode el)
                return el.RenderFormatted(identLevel);
            return node.Render();
        }
        public void Handle(LightNode node, string eventName)
        {
            if (node is LightElementNode el)
                el.Dispatch(eventName);
        }
    }
}
