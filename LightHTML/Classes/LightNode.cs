using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr1.LightHTML.Classes
{
    public abstract class LightNode
    {
        protected IRenderBehavior _renderBehavior = new StandardRender();

        public void SetRenderBehavior(IRenderBehavior behavior)
        {
            _renderBehavior = behavior;
        }

        public string RenderFull(int indent = 0)
        {
            return _renderBehavior.Render(this, indent);
        }

        public void Trigger(string eventName)
        {
            _renderBehavior.Handle(this, eventName);
        }
        public abstract string Render();
        public abstract string GetInner();
    }
}