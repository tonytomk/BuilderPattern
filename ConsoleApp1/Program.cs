using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ConsoleApp1
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;
        public HtmlElement()
        {

        }

        public HtmlElement(string name, string text)
        {
            this.Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            this.Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new String(' ', indentSize* indent);
            sb.AppendLine($"{i}<{Name}>");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new String(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }
            foreach (var e in Elements)
            {
                sb.Append(e.ToStringImpl(indent + 1));
            }
            sb.AppendLine($"{i}</{Name}>");
            return sb.ToString();
                
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        //public void AddChild(string childName, string childText)
        //{
        //    var e = new HtmlElement(childName, childText);
        //    root.Elements.Add(e);
        //}
        /// <summary>
        /// FLuent
        /// </summary>
        /// <param name="childName"></param>
        /// <param name="childText"></param>
        /// <returns></returns>
        public HtmlBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }
        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement() { Name = rootName };
        }
    }


    
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var hello = "Hello";
        //    var sb = new StringBuilder();
        //    sb.Append("<p>");
        //    sb.Append(hello);
        //    sb.Append("</p>");
        //    WriteLine(sb);

        //    var words = new[] { "hello", "world" };
        //    sb.Clear();
        //    sb.Append("<ul>");
        //    foreach (var word in words)
        //    {
        //        sb.AppendFormat("<li>{0}</li>", word);
        //    }
        //    sb.Append("</ul>");
        //    WriteLine(sb);



        //    //var builder = new HtmlBuilder("ul");
        //    //builder.AddChild("li", "hello");
        //    //builder.AddChild("li", "world");


        //    var builder = new HtmlBuilder("ul");
        //    builder.AddChild("li", "hello").AddChild("li", "world");
        //    WriteLine(builder.ToString());

        //    var builder1 = new HtmlBuilder("p");
        //    builder1.AddChild("p","hello world sdfsd");
        //    WriteLine(builder1.ToString());
        //}
    }
}
