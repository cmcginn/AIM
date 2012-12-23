using System;
using System.Xml.Serialization;

namespace AIM.Administration.Models
{
    public class StuffContact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [XmlElement(IsNullable = false)]
        public string Email { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
    }
}