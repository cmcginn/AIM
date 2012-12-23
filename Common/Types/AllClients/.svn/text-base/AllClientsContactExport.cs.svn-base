using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIM.Common.Types;
namespace AIM.Common.Types.AllClients
{
    public class AllClientsContactExport
    {
        AllClientsContact _Contact;

        public AllClientsContact Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
        }
        AllClientsAccount _Account;

        public AllClientsAccount Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        AllClientsWebform _AllClientsWebform;
        public AllClientsWebform AllClientsWebform
        {
            get { return _AllClientsWebform; }
            set { _AllClientsWebform = value; }
        }

        public bool IsValid()
        {
            bool result = false;
            result = (Contact != null &&
                Account != null &&
                Account == AllClientsWebform.Account &&
                Contact != null &&
                Account.IsValid() &&
                Contact.IsValid());
            return result;

        }
    }
}
