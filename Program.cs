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
            h1.AppendChild(new LightTextNode("Це демонстрація шаблонного методу."));
            root.AppendChild(h1);

            var p = new LightElementNode("p");
            p.AppendChild(new LightTextNode("Текст усередині параграфа."));
            root.AppendChild(p);

            root.On("click", () => Console.WriteLine("Клік на <div>!"));

            // Рендер з шаблонним методом
            Console.WriteLine("----- RenderWithLifecycle (Template Method) -----");
            Console.WriteLine(root.RenderWithLifecycle());

            Console.WriteLine("----- Standard State (RenderFull) -----");
            root.SetRenderBehavior(new StandardRender());
            Console.WriteLine(root.RenderFull());

            Console.WriteLine("----- NoRender State -----");
            root.SetRenderBehavior(new NoRender());
            Console.WriteLine(root.RenderFull());

            root.Trigger("click");
        }
    }
}