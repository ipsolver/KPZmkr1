using mkr1.LightHTML.Classes;
using System;

namespace mkr1
{
    class Program
    {
        static void Main()
        {
            var root = new LightElementNode("div");
            root.AddClass("main");

            var h1 = new LightElementNode("h1");
            h1.AppendChild(new LightTextNode("Це демонстрація шаблонного методу!"));
            root.AppendChild(h1);

            var p = new LightElementNode("p");
            p.AppendChild(new LightTextNode("Текст усередині параграфа"));
            root.AppendChild(p);

            root.On("click", () => Console.WriteLine("Клік на <div>!"));

            // Шаблонний метод
            Console.WriteLine("----- RenderWithLifecycle (Template Method) -----");
            Console.WriteLine(root.RenderWithLifecycle());

            // Стейт
            Console.WriteLine("----- Standard State (RenderFull) -----");
            root.SetRenderBehavior(new StandardRender());
            Console.WriteLine(root.RenderFull());

            Console.WriteLine("----- NoRender State -----");
            root.SetRenderBehavior(new NoRender());
            Console.WriteLine(root.RenderFull());

            root.Trigger("click");

            // Visitor: генерує HTML-файл
            Console.WriteLine("\n----- Visitor: Export to HTML File -----");
            var exportVisitor = new HtmlExportVisitor();
            root.Accept(exportVisitor);
            exportVisitor.ExportToFile("../../../answer.html");

            Console.WriteLine("HTML записано у файл: answer.html");
        }
    }
}
