using System;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Xml;

namespace AIM.Common
{
    public class AIMServiceConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("serviceConfiguration")]
        public AIMServiceConfigurationElement ServiceConfiguration
        {
            get
            {
                return (AIMServiceConfigurationElement)this["serviceConfiguration"];
            }
            set
            {
                this["serviceConfiguration"] = value; 
            }
        }

    }

    public class AIMServiceConfigurationElement:ConfigurationElement
    {
        [ConfigurationProperty("importLimit", DefaultValue = "9999999", IsRequired = false)]
        public Int64 ImportLimit
        {
            get
            {
                return int.Parse(this["importLimit"].ToString());
            }
            set
            {
                this["importLimit"] = value;
            }
        }
        [ConfigurationProperty("allowExport", DefaultValue = "true", IsRequired = false)]
        public Boolean AllowExport
        {
            get
            {
                return (Boolean)this["allowExport"];
            }
        }
    }
}
