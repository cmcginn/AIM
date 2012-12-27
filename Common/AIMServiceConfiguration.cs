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

    public class AIMServiceConfigurationElement : ConfigurationElement
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
            set { this["allowExport"] = value; }
        }
        [ConfigurationProperty("mindBodyApiKey", DefaultValue = "", IsRequired = true)]
        public String MindBodyApiKey
        {
            get { return (String)this["mindBodyApiKey"]; }
            set { this["mindBodyApiKey"] = value; }
        }
        [ConfigurationProperty("mindBodySourceName", DefaultValue = "", IsRequired = true)]
        public String MindBodySourceName
        {
            get { return (String)this["mindBodySourceName"]; }
            set { this["mindBodySourceName"] = value; }
        }
        [ConfigurationProperty("testClientId", DefaultValue = "00000000-0000-0000-0000-000000000000", IsRequired = false)]
        public Guid TestClientId
        {
            get { return Guid.Parse(this["testClientId"].ToString()); }
            set { this["testClientId"] = value; }
        }
    }
}
