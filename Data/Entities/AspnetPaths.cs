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
    public partial class AspnetPaths
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

            public System.Guid PathId { get; set; }

            [Required]
            public string Path { get; set; }

            [Required]
            public string LoweredPath { get; set; }

            public AspnetPersonalizationAllUsers AspnetPersonalizationAllUsers { get; set; }

            public AspnetApplications AspnetApplications { get; set; }

            public EntitySet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUserList { get; set; }

        }

        #endregion
    }
}