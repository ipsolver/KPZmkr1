using System.Text;
using System.IO;

namespace mkr1.LightHTML.Classes
{
    public class HtmlExportVisitor : ILightNodeVisitor
    {
        private readonly StringBuilder sb = new();

        public void VisitText(LightTextNode textNode)
        {
            sb.Append(textNode.text);
        }

        public void VisitElement(LightElementNode elementNode)
        {
            sb.Append($"<{elementNode.TagName}");

            if (elementNode.CssClasses.Count > 0)
                sb.Append($" class=\"{string.Join(" ", elementNode.CssClasses)}\"");

            if (elementNode.IsSelfClosing)
            {
                sb.Append(" />");
            }
            else
            {
                sb.Append(">");
                foreach (var child in elementNode.GetChildren())
                {
                    child.Accept(this);
                }
                sb.Append($"</{elementNode.TagName}>");
            }
        }

        public void ExportToFile(string path)
        {
            string fullHtml = $"<html><head></head><body>{sb}</body></html>";
            File.WriteAllText(path, fullHtml);
        }
    }
}
