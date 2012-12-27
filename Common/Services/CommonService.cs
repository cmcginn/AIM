using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Messaging;
using Common.Messaging.Http;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using AIM.Common;
using AIM.Data;
namespace AIM.Common.Services
{
    public class CommonService
    {
        public const string AIMSCRM_SERVICE_URL = "https://www.aimscrm.com/api/2/";
        public const string AIMSCRM_FORMS_URL = "https://www.aimscrm.com/FormHTML.aspx";
        public static XElement AllClientsRequest(string requestName,int accountId,string apiKey)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("accountid", accountId.ToString());
            parameters.Add("apikey", apiKey);
            parameters.Add("getcategories", "1");
            parameters.Add("getflags", "1");
            return AllClientsRequest(requestName, parameters);
        }

        public static XElement AllClientsRequest(string requestName, Dictionary<string, string> parameters)
        {
            string url = String.Format("{0}{1}", AIMSCRM_SERVICE_URL, requestName);
            return XElement.Parse(HttpRequest(url, parameters));
        }
        public static string HttpRequest(string url, Dictionary<string,string> parameters)
        {
            string response = null;
            PostSubmitter submitter = new PostSubmitter();
          
            submitter.Type = PostTypeEnum.Post;
            submitter.PostEncoding = PostEncodingEnum.URLEncoded;
            submitter.Url = url;
            submitter.UserAgent = "Mozilla/5.0";
            parameters.ToList().ForEach(parameter =>
            {
                submitter.PostItems.Add(parameter.Key, parameter.Value);
            });

            response = submitter.Post();
            return response;
        }      

        public static XElement AllClientsFormPost(Dictionary<string,string> parameters)
        {            
            return XElement.Parse(HttpRequest(AIMSCRM_FORMS_URL, parameters));
        }
        public static XElement ToXml(Type type, Object instance)
        {
            XElement result;
            StringBuilder builder = new StringBuilder();
            using (XmlTextWriter writer = new XmlTextWriter(new StringWriter(builder)))
            {
                XmlSerializer serializer = new XmlSerializer(type);
                serializer.Serialize(writer, instance);
                result = XElement.Parse(builder.ToString());

            }
            return result;
        }
        public static Object FromXml( Type type, string source ) {
          return FromXml( type, source, new XmlSerializer( type ) );
        }
        public static Object FromXml(Type type, string source,XmlSerializer serializer)
        {
            object result;
            using (XmlReader reader = XElement.Parse(source).CreateReader())
            {
                object deserialized = serializer.Deserialize(reader) as object;
                result = deserialized;
            }
            return result;
        }
        public static List<string> Validate(XDocument document,string targetNamespace,FileInfo schemaFile)
        {
            List<string> result = new List<string>();
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(targetNamespace,schemaFile.FullName);
            document.Validate(schemas, (o, e) =>
            {
                result.Add(e.Message);
            });
            return result;
        }
        public static XElement Transform(XElement source, FileInfo xsltPath)
        {

            XElement result = null;
            XPathDocument xPathDocument = new XPathDocument(XDocument.Parse(source.ToString()).CreateReader());
            XslCompiledTransform transform = new XslCompiledTransform();

            StringBuilder builder = new StringBuilder();
            using (StringWriter stringWriter = new StringWriter(builder))
            using (XmlTextWriter textWriter = new XmlTextWriter(stringWriter))
            {
                XsltArgumentList arguments = new XsltArgumentList();
                transform.Load(xsltPath.FullName);
                transform.Transform(xPathDocument, textWriter);
                result = XElement.Parse(builder.ToString());
            }
            return result;
        }
        public static List<IClient> GetActiveClients()
        {
            var aimServiceConfiguration =
                System.Configuration.ConfigurationManager.GetSection("aimServiceConfigurationGroup/aimServiceConfiguration") as
                AIMServiceConfigurationSection;
            List<IClient> result = new List<IClient>();
            using (DomainContext ctx = new DomainContext())
            {
                Manager mgr = new Manager(ctx);
                ClientManager clientManager = new ClientManager(mgr);
                if (aimServiceConfiguration.ServiceConfiguration.TestClientId != Guid.Empty)
                    result =
                        clientManager.GetActive()
                                     .Where(x => x.Id == aimServiceConfiguration.ServiceConfiguration.TestClientId)
                                     .ToList();
                else
                    result = clientManager.GetActive().ToList();
            }
            return result;

        }

    }
}
