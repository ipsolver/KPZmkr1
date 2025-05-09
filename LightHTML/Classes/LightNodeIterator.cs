using mkr1.LightHTML.Classes;
using mrk1.LightHTML.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr1.LightHTML.Classes
{
    public class LightNodeIterator : Iterator
    {
        private readonly LightElementNode element;
        private readonly List<LightNode> children;
        private readonly bool reverse;
        private int position;

        public LightNodeIterator(LightElementNode element, bool reverse = false)
        {
            this.element = element;
            children = element.GetChildren();
            this.reverse = reverse;
            position = reverse ? children.Count : -1;
        }

        public override LightNode Current()
        {
            return children[position];
        }

        public override int Key()
        {
            return position;
        }

        public override bool MoveNext()
        {
            int updated = position + (reverse ? -1 : 1);
            if (updated >= 0 && updated < children.Count)
            {
                position = updated;
                return true;
            }
            return false;
        }

        public override void Reset()
        {
            position = reverse ? children.Count - 1 : 0;
        }
    }
}
