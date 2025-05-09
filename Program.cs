using mkr1.LightHTML.Classes;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Threading;
namespace mkr1
{
    class Program
    {
        static void Main()
        {
            LightElementNode div = new LightElementNode("div");
            div.AddClass("container");

            LightElementNode header = new LightElementNode("h1", isBlock: true);
            header.AppendChild(new LightTextNode("Hello!"));
            div.AppendChild(header);

            LightElementNode ul = new LightElementNode("ul");
            ul.AddClass("list");

            for (int i = 1; i <= 5; i++)
            {
                LightElementNode li = new LightElementNode("li", isBlock: false);
                li.AppendChild(new LightTextNode($"Its item of list #{i}"));
                ul.AppendChild(li);
            }

            div.AppendChild(ul);

            //Обхід у ширину
            Console.WriteLine("\nBreadth Iterator:");
            var bfsIterator = div.CreateBreadthIterator();

            while (bfsIterator.MoveNext())
            {
                var node = bfsIterator.Current();
                Console.WriteLine($"[{node.GetType().Name}] {node.Render().Trim()}");
            }

            //Обхід у глибину
            Console.WriteLine("\nDepth Iterator:");
            var depth = div.CreateDepthIterator();
            while (depth.MoveNext())
            {
                var node = depth.Current();
                Console.WriteLine($"[{node.GetType().Name}] {node.Render().Trim()}");
            }

            Console.WriteLine("\nHTML Render:");
            Console.WriteLine(div.Render());
        }
    }
}