using mkr1.LightHTML.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr1.LightHTML.Classes
{
    public class LightElementNode : LightNode, INodeNumerator
    {
        private string TagName { get; }
        private bool IsBlock { get; }
        private bool IsSelfClosing { get; }
        private List<string> CssClasses { get; }
        private List<LightNode> children;
        private bool reverseDirection = false;
        private Dictionary<string, List<Action>> _eventMap = new();

        public LightElementNode(string tagName, bool isBlock = true, bool isSelfClosing = false)
        {
            TagName = tagName;
            IsBlock = isBlock;
            IsSelfClosing = isSelfClosing;
            CssClasses = new List<string>();
            children = new List<LightNode>();
        }

        public void AddClass(string Сlass)
        {
            CssClasses.Add(Сlass);
        }
        public void AppendChild(LightNode one)
        {
            if (IsSelfClosing)
                throw new InvalidOperationException("Self-closing tags cannot have children!");

            children.Add(one);
        }


        public override string GetInner()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var child in children)
            {
                sb.Append(child.Render());
            }
            return sb.ToString();
        }

        public override string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<{TagName}");

            if (CssClasses.Count > 0)
            {
                sb.Append($" class=\"{string.Join(" ", CssClasses)}\"");
            }

            if (IsSelfClosing)
            {
                sb.Append(" />\n");
            }
            else
            {
                sb.Append($">{GetInner()}</{TagName}>\n");
            }

            return sb.ToString();
        }

        public List<LightNode> GetChildren() => children;

        public void ReverseDirection()
        {
            reverseDirection = !reverseDirection;
        }

        public IEnumerator GetEnumerator()
        {
            return new LightNodeIterator(this, reverseDirection);
        }

        public BreadthIterator CreateBreadthIterator()
        {
            return new BreadthIterator(this);
        }
        public DepthIterator CreateDepthIterator()
        {
            return new DepthIterator(this);
        }
        public string RenderFormatted(int indentLevel = 0)
        {
            var indent = new string(' ', indentLevel * 2);
            var sb = new StringBuilder();

            sb.Append($"{indent}<{TagName}");
            if (CssClasses.Count > 0)
                sb.Append($" class=\"{string.Join(" ", CssClasses)}\"");

            if (IsSelfClosing)
            {
                sb.Append(" />\n");
            }
            else
            {
                sb.Append(">\n");
                foreach (var child in children)
                {
                    sb.Append(child.RenderFull(indentLevel + 1));
                }
                sb.Append($"{indent}</{TagName}>\n");
            }

            return sb.ToString();
        }

        public void On(string eventType, Action callback)
        {
            if (!_eventMap.ContainsKey(eventType))
                _eventMap[eventType] = new List<Action>();

            _eventMap[eventType].Add(callback);
        }

        public void Dispatch(string eventType)
        {
            if (_eventMap.TryGetValue(eventType, out var handlers))
            {
                foreach (var action in handlers)
                {
                    action.Invoke();
                }
            }
        }

    }
}
