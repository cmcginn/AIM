using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIM.Common;
using System.Xml;
using System.Xml.Serialization;
namespace AIM.Common.Types.AllClients
{
    [XmlRoot(Namespace = "http://www.aimscrm.com/schema/2011/webform")]
    public class AllClientsWebform
    {
        public AllClientsWebform()
        {
        }       

        AllClientsAccount _Account;

        public AllClientsAccount Account
        {
            get { return _Account; }
            set{_Account = value;}      
        }

        public Enumerations.WebformType WebformType { get; set; }
        public string FormName { get; set; }
        string _FormKey;

        public string FormKey
        {
            get { return _FormKey; }
            set { _FormKey = value; }           
        }

        public bool IsValid()
        {
            bool result = false;
            result = (WebformType != null & !
                String.IsNullOrEmpty(FormKey) &&
                Account != null);
                
            return result;                
                
        }
    }
}
