using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using AIM.Administration.Extentions;
using AIM.Administration.Models;
using AIM.Common.Types.AllClients;
namespace AIM.Administration.Services
{
    public interface IRepository
    {
        Category GetCategory(string id);
        Flag GetFlag(string id);
        List<Category> GetAllCategories();
        List<Flag> GetAllFlags();
    }

    public class XmlRepository : IRepository
    {
        private readonly XDocument _document;
        public XmlRepository(string fileName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileName);

            var stream = File.OpenRead(fileName);
            var reader = XmlReader.Create(stream);

            _document = XDocument.Load(reader);
        }

        public Category GetCategory(string id)
        {
            var sectionsElement = _document.GetElement("Categories", "");
            var element = sectionsElement.Elements("Category")
                .Single(x => x.GetElement("Id","").GetValue() == id);

            return new Category { Id = element.GetElement("Id","").GetValue(), Name = element.GetElement("Name","").GetValue() };

        }

        public Flag GetFlag(string id)
        {
            Flag result = null;
            var sectionsElement = _document.GetElement("Flags", "");
            var element = sectionsElement.Elements("Flag")
                .SingleOrDefault(x => x.GetElement("Id","").GetValue() == id);
            if(element != null)
                result = new Flag() { Id = element.GetElement("Id","").GetValue(), Name = element.GetElement("Name","").GetValue() };
            return result;

        }


        public List<Category> GetAllCategories()
        {
            var sectionsElement = _document.GetElement("Categories", "");

            return sectionsElement.Descendants("Category").Select(element => new Category()
            {
                Id = element.GetElement("Id","").GetValue(),
                Name = element.GetElement("Name","").GetValue()
            }).ToList();   
        }
        public List<Flag> GetAllFlags()
        {
            var sectionsElement = _document.GetElement("Flags", "");

            return sectionsElement.Descendants("Flag").Select(element => new Flag()
                                                                             {
                                                                                 Id = element.GetElement("Id","").GetValue(),
                                                                                 Name = element.GetElement("Name","").GetValue()
                                                                             }).ToList();
        }
    }
}