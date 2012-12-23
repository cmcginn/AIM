using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIM.Common;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
namespace AIM.Common.Types.AllClients
{

    public class CustomElement
    {
        public string Value { get; set; }
        public string Name { get; set; }
    }
    
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Flag
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    [XmlRoot(Namespace = "http://www.aimscrm.com/schema/2011/common/contact")]    
    public class AllClientsContact
    {
        public bool IsTestMode()
        {
            bool result = true;
            if (System.Configuration.ConfigurationManager.AppSettings["TestMode"] != null && System.Configuration.ConfigurationManager.AppSettings["TestMode"].ToUpper() == "FALSE")
            {
                result = false;
            }
            return result;
        }
        string _FirstName;        
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                
                _FirstName = value;
            }
        }

        string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                
                _LastName = value;
            }
        }


        string _City;
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                
                _City = value;
            }
        }

        string _State;
        public string State
        {
            get
            {
                return _State;
            }
            set
            {
              
                _State = value;
            }
        }
        string _Zip;
        public string Zip
        {
            get
            {
                return _Zip;
            }
            set
            {
              
                _Zip = value;
            }
        }
        string _Email;
        [XmlElement(IsNullable=false)]        
        public string Email
        {
            get
            { 
                return _Email;
            }
            set
            {
                _Email = value;
                if (IsTestMode() &!string.IsNullOrEmpty(_Email))
                {
                    _Email = value.Replace("testtest","");
                    _Email = String.Format("testtest{0}", _Email);
                }
                
            }
        }
        string _Company;
        public string Company
        {
            get
            {
                return _Company;
            }
            set
            {
                
                _Company = value;
            }
        }
        string _Phone;
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {                
                _Phone = value;
            }
        }
        List<CustomElement> _Custom = new List<CustomElement>();
        public List<CustomElement> Custom
        {
            get { return _Custom; }
            set { _Custom = value; }
        }
        List<Category> _Categories = new List<Category>();

        
        public List<Category> Categories
        {
            get { return _Categories; }
            set { _Categories = value; }
        }
        List<Flag> _Flags = new List<Flag>();

        public List<Flag> Flags
        {
            get { return _Flags; }
            set { _Flags = value; }
        }
        
        public bool IsValid()
        {
            bool result = false;
            result = (!String.IsNullOrEmpty(FirstName) &!
                String.IsNullOrEmpty(LastName) &!
                String.IsNullOrEmpty(Email));
            return result;
        }
    }
}
