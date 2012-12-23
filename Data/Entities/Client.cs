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
    public partial class Client
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

            public int ImportTypeId { get; set; }

            [Now(EntityState.New)]
            [CodeSmith.Data.Audit.NotAudited]
            public System.DateTime Created { get; set; }

            public System.DateTime Updated { get; set; }

            public bool Active { get; set; }

            public System.Xml.Linq.XElement ClientParameters { get; set; }

            [Required]
            public int AccountId { get; set; }

            [Required]
            public string ApiKey { get; set; }

            public string Company { get; set; }

            public bool EnableUpdates { get; set; }

            public bool IsDeleted { get; set; }

            public ImportType ImportType { get; set; }

            public ClientProperties ClientProperties { get; set; }

            public EntitySet<Contact> ContactList { get; set; }

            public EntitySet<ClientFileImport> ClientFileImportList { get; set; }

        }

        #endregion
    }
}