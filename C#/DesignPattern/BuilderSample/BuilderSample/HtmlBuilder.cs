using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderSample.Html
{
    public sealed class HtmlElement
    {
        private const int IndentSize = 2;

        public string TagName { get; set; }
        public string Text { get; set; }
        public List<HtmlElement> Elements { get; } = new List<HtmlElement>();

        public HtmlElement(string name, string text)
        {
            this.TagName = name ?? throw new ArgumentNullException(paramName: " ");
            this.Text = text ?? throw new ArgumentNullException(paramName: " ");
        }

        private string ToStringImpl(int indent)
        {
            StringBuilder sb = new StringBuilder();

            //open tag
            string i = new string(' ', IndentSize * indent);
            sb.AppendLine($"{i}<{TagName}>");

            //text
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', IndentSize * (indent + 1)));
                sb.AppendLine($"{Text}");
            }

            //child
            foreach(var e in Elements)
            {
                sb.Append(e.ToStringImpl(IndentSize * (indent + 1)));
            }

            //close tag
            sb.AppendLine($"{i}</{TagName}>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }

    }


    public class HtmlBuilder
    {
        public HtmlElement RootElement { get; private set; }

        public HtmlBuilder(string rootName, string text="")
        {
            this.RootElement = new HtmlElement(rootName, text);
        }

        public HtmlBuilder AppendElement(HtmlElement element)
        { RootElement.Elements.Add(element);
            return this;
        }

        public HtmlBuilder AppendElement(string name, string text)
        {
            AppendElement(new HtmlElement(name, text));
            return this;
        }

        public override string ToString()
        {
            return RootElement.ToString();
        }
    }
}