
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CodeSmith.Data.Rules;
using CodeSmith.Data.Rules.Validation;

namespace AIM.Data
{
    public partial class ContactManager
    {       
        #region Query
        // A private class for lazy loading static compiled queries.
        private static partial class Query
        {
            // Add your compiled queries here. 
        } 

        #endregion

        public IContact GetNewContact()
        {
            IContact result = new Contact
            {
                Id = Guid.NewGuid(),
                Created = System.DateTime.Now
            };
            Context.Contact.InsertOnSubmit(result as Contact);
            return result;
        }
    }
}