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
    public partial class AspnetApplications
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [CodeSmith.Data.Audit.Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            [Required]
            public string ApplicationName { get; set; }

            [Required]
            public string LoweredApplicationName { get; set; }

            public System.Guid ApplicationId { get; set; }

            public string Description { get; set; }

            public EntitySet<AspnetMembership> AspnetMembershipList { get; set; }

            public EntitySet<AspnetPaths> AspnetPathsList { get; set; }

            public EntitySet<AspnetRoles> AspnetRolesList { get; set; }

            public EntitySet<AspnetUsers> AspnetUsersList { get; set; }

        }

        #endregion
    }
}