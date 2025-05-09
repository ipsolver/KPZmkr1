using mkr1.LightHTML.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mrk1.LightHTML.Classes;

namespace mkr1.LightHTML.Classes
{
    public class BreadthIterator : Iterator
    {
        private Queue<LightNode> queue = new();
        private LightNode current;

        public BreadthIterator(LightNode root)
        {
            if (root != null)
                queue.Enqueue(root);
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
            if (queue.Count == 0)
                return false;

            current = queue.Dequeue();

            if (current is LightElementNode element)
            {
                foreach (var child in element.GetChildren())
                {
                    queue.Enqueue(child);
                }
            }

            return true;
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
