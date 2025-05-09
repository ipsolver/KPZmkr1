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
            var root = new LightElementNode("div");
            root.AddClass("main");

            var h1 = new LightElementNode("h1");
            h1.AppendChild(new LightTextNode("Its State pattern!"));
            root.AppendChild(h1);

            // Додаємо подію
            root.On("click", () => Console.WriteLine("DIV clicked"));

            Console.WriteLine("----- Standard State -----");
            Console.WriteLine(root.RenderFull());
            root.Trigger("click");

            root.SetRenderBehavior(new NoRender());

            Console.WriteLine("\n------ NoRender State ------");
            Console.WriteLine(root.RenderFull());
            root.Trigger("click");
        }
    }
}