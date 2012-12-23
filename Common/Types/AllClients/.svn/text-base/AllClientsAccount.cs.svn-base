using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIM.Common.Types.AllClients
{
    public class AllClientsAccount
    {

        public string ClientName { get; set; }
        public string Group { get; set; }
        public bool Active { get; set; }
        public int AccountId { get; set; }
        public string APIKey { get; set; }

        public bool IsValid()
        {
            bool result = false;
            result = (!String.IsNullOrEmpty(ClientName) &&
                AccountId > 0 &!
                String.IsNullOrEmpty(APIKey) &&
                Active);
            return result;
        }
        
    }
}
