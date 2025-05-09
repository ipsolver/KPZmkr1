using mkr1.LightHTML.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace mkr1.LightHTML.Classes
{
    public class LightTextNode : LightNode
    {
        public string text { get; }

        public LightTextNode(string text)
        {
            this.text = text;
        }

        public override string Render() => text;
        public override string GetInner()
        {
            return text;
        }

        protected override string OnRenderContent(int indent) => new string(' ', indent * 2) + text + "\n";
    }
}