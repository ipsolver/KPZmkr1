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
            //Завдання 5
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
                li.AppendChild(new LightTextNode($"Its item of list"));
                ul.AppendChild(li);
            }

            div.AppendChild(ul);

            Console.WriteLine("\nLightHTML Output:");
            Console.WriteLine(div.Render());
        }
    }
}