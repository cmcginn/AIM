using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AIM.Administration.Extentions {
    public static class XDocumentExtensions {
        public static XElement GetElement(this XDocument document, string name, XNamespace ns) {
            IEnumerable<XElement> elements = document.Descendants(ns + name);
            if (elements.Count() != 1) {
                return null;
            }
            return elements.SingleOrDefault();
        }
    }
}