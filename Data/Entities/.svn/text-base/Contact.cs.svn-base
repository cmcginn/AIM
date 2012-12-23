using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using CodeSmith.Data.Attributes;
using CodeSmith.Data.Rules;

namespace AIM.Data
{
    public partial class Contact
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [CodeSmith.Data.Audit.Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public System.Guid Id { get; set; }

            public System.Guid ClientId { get; set; }

            public System.Xml.Linq.XElement ContactElement { get; set; }

            [Now(EntityState.New)]
            [CodeSmith.Data.Audit.NotAudited]
            public System.DateTime Created { get; set; }

            public System.DateTime? Updated { get; set; }

            public Client Client { get; set; }

        }

        #endregion
    }
}