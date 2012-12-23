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
    public partial class AspnetUsers
    {
        // Place custom code here.

        #region Metadata
        // For more information about how to use the metadata class visit:
        // http://www.plinqo.com/metadata.ashx
        [CodeSmith.Data.Audit.Audit]
        internal class Metadata
        {
             // WARNING: Only attributes inside of this class will be preserved.

            public System.Guid ApplicationId { get; set; }

            public System.Guid UserId { get; set; }

            [Required]
            public string UserName { get; set; }

            [Required]
            public string LoweredUserName { get; set; }

            public string MobileAlias { get; set; }

            public bool IsAnonymous { get; set; }

            public System.DateTime LastActivityDate { get; set; }

            public AspnetMembership AspnetMembership { get; set; }

            public AspnetProfile AspnetProfile { get; set; }

            public AspnetApplications AspnetApplications { get; set; }

            public EntitySet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUserList { get; set; }

            public EntitySet<AspnetUsersInRoles> AspnetUsersInRolesList { get; set; }

        }

        #endregion
    }
}