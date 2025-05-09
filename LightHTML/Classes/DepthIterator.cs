using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mrk1.LightHTML.Classes;

namespace mkr1.LightHTML.Classes
{
    public class DepthIterator : Iterator
    {
        private Stack<LightNode> stack = new();
        private LightNode current;

        public DepthIterator(LightNode root)
        {
            if (root != null)
                stack.Push(root);
        }

        public override LightNode Current()
        {
            return current;
        }

        public override int Key()
        {
            return -1;
        }

        public override bool MoveNext()
        {
            if (stack.Count == 0)
                return false;

            current = stack.Pop();

            if (current is LightElementNode element)
            {
                var children = element.GetChildren();
                for (int i = children.Count - 1; i >= 0; i--)
                {
                    stack.Push(children[i]);
                }
            }

            return true;
        }

        public override void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}
