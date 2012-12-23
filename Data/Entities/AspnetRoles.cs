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
    public partial class AspnetRoles
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

            public System.Guid RoleId { get; set; }

            [Required]
            public string RoleName { get; set; }

            [Required]
            public string LoweredRoleName { get; set; }

            public string Description { get; set; }

            public AspnetApplications AspnetApplications { get; set; }

            public EntitySet<AspnetUsersInRoles> AspnetUsersInRolesList { get; set; }

        }

        #endregion
    }
}