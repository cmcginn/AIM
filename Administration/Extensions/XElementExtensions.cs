using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AIM.Administration.Extentions
{
    internal static class XElementExtensions
    {

        public static XElement AddElement(this XElement input, XElement element)
        {
            if (input != null && element != null)
            {
                input.Add(element);
            }
            return input;
        }

        public static XElement SetElementValue(this XElement input, object value)
        {
            if (input != null && value != null)
            {
                input.SetValue(value);
            }
            return input;
        }

        public static string EmitXml(this XElement input)
        {
            return string.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n{0}", input);
        }

        public static XElement GetElement(this XElement input, string name, XNamespace ns)
        {
            IEnumerable<XElement> elements = input.Descendants(ns + name);
            if (elements.Count() != 1)
            {
                return null;
            }
            return elements.SingleOrDefault();
        }

        public static XAttribute GetAttribute(this XElement input, string name)
        {
            return input.Attribute(name);
        }

        public static string GetValue(this XElement input)
        {
            return input == null ? null : input.Value;
        }
        public static string GetValue(this XAttribute input)
        {
            return input == null ? null : input.Value;
        }
    }
}