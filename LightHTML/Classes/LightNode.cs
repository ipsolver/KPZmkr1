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
        public virtual string RenderWithLifecycle(int indent = 0)
        {
            StringBuilder sb = new();
            sb.Append(OnBeforeRender());
            sb.Append(OnRenderContent(indent));
            sb.Append(OnAfterRender());
            return sb.ToString();
        }

        protected virtual string OnBeforeRender() => string.Empty;
        protected virtual string OnAfterRender() => string.Empty;
        protected abstract string OnRenderContent(int indent);

        public abstract string Render();
        public abstract string GetInner();
        public abstract void Accept(ILightNodeVisitor visitor);

    }
}