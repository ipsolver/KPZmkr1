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
            var div = new LightElementNode("div");
            var h1 = new LightElementNode("h1");
            var text = new LightTextNode("Hello!");

            var invoker = new Invoker();

            invoker.ExecuteCommand(new AddClassCommand(div, "container"));
            invoker.ExecuteCommand(new AppendChildCommand(h1, text));
            invoker.ExecuteCommand(new AppendChildCommand(div, h1));

            Console.WriteLine("\nRender with Command:");
            Console.WriteLine(div.Render());
        }
    }
}